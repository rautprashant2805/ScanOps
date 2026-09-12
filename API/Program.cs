using Application.Core;
using Application.Equipments.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
builder.Services.AddMediatR(x => 
    x.RegisterServicesFromAssemblyContaining<GetEquipmentList.Handler>());
//builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfiles).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.\
app.UseCors( x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:3000", "https://localhost:3000"));

app.MapControllers();

//Create a temporary, artificial request scope to safely access the database service at startup
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    //Get the configured DB context from the Dependency Injection container
    var context = services.GetRequiredService<AppDbContext>();

    //Automatically apply any pending EF Core migrations and create the database if it doesn't exist
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error occurred during migration.");
}

app.Run();
