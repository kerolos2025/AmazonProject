using Shepping.Application.Mappers;
using Shepping.Application.Queries;
using Shepping.Core.Repositories;
using Shepping.Infrastructure.Data.Contexts;
using Shepping.Infrastructure.Data.SeedData;
using Shepping.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Shipping API",
        Version = "v1",
        Description = "The Shipping Microservice API",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Kerolos",
            Email = "kero.gpt@gmail.com"
        }
    });
});
builder.Services.AddOpenApi();




builder.Services.AddAutoMapper(typeof(ShippingProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies
                                                                    (
                                                                    Assembly.GetExecutingAssembly(),
                                                                    Assembly.GetAssembly(typeof(GetShippingByNameQuery))
                                                                    )
                           );


builder.Services.AddScoped<IShippingContext, ShippingContext>();
builder.Services.AddScoped<IShippingRepository, ShippingRepository>();


// Register seeder
builder.Services.AddTransient<ShippingSeeder>();

var app = builder.Build();

// Run seeder in a scope before the app starts handling requests
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<ShippingSeeder>();
    try
    {
        await seeder.SeedAsync();
        app.Logger.LogInformation("Shipping seeding completed.");
        Console.WriteLine("Shipping seeding completed.");
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred while seeding the Shipping data.");
        Console.WriteLine("Shipping seeding Error.");

        throw;
    }
}

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
