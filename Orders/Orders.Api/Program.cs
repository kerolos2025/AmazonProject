using MassTransit;
using Microsoft.EntityFrameworkCore;
using Orders.Application.Commands;
using Orders.Application.Consumer;
using Orders.Application.Mappers;
using Orders.Core.Repositories;
using Orders.Infrastructure.Data.Contexts;
using Orders.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Order API",
        Version = "v1",
        Description = "The Order Microservice API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Kerolos",
            Email = "kero.gpt@gmail.com"
        }
    });
});



builder.Services.AddOpenApi();



builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies
                                                                    (
                                                                    Assembly.GetExecutingAssembly(),
                                                                    Assembly.GetAssembly(typeof(CreateOrderCommand))
                                                                    )
                           );

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
   builder.Configuration.GetConnectionString("OrderConnectionString"),
    sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    ));


builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<BasketCheckoutConsumer>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<BasketCheckoutConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("basket-checkout-queue", e =>
        {
            e.ConfigureConsumer<BasketCheckoutConsumer>(context);
        });
      
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
