using Baskets.Application.Commands;
using Baskets.Application.GrpcServices;
using Baskets.Application.Mappers;
using Baskets.Core.Repositories;
using Baskets.Infrastructure.Repositories;
using Discount.Grpc.Protos;
using Grpc.Net.Client.Web;
using MassTransit;
using StackExchange.Redis;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Basket API",
        Version = "v1",
        Description = "The Basket Microservice API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Kerolos",
            Email = "kero.gpt@gmail.com"
        }
    });
});

builder.Services.AddOpenApi();


builder.Services.AddAutoMapper(typeof(BasketProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies
                                                                    (
                                                                    Assembly.GetExecutingAssembly(),
                                                                    Assembly.GetAssembly(typeof(CreateBasketCommand))
                                                                    )
                           );



builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect("localhost:6379")
);

builder.Services.AddScoped<IBasketRepository,BasketRepository>();

builder.Services.AddScoped<DiscountGrpcService>();
//builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>
//    (cfg => cfg.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));



builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(o =>
    o.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]))
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var httpHandler = new HttpClientHandler();
        // Accept any server certificate (DEV ONLY). Remove for production.
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        // If you need gRPC-Web (IIS), wrap in GrpcWebHandler:
        return new GrpcWebHandler(GrpcWebMode.GrpcWeb, httpHandler);
    });


builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
       
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
