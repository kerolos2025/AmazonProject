using Baskets.Application.Commands;
using Baskets.Application.Mappers;
using Baskets.Core.Repositories;
using Baskets.Infrastructure.Repositories;
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
