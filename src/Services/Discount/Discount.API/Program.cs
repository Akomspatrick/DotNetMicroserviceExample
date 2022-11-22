using Discount.API.Repositories;
using Discount.API.Repositories.Interfaces;
using Discount.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

//builder.Build().MigrateDatabaseTest();
//builder.MigrateDB<Program>();

// Add services to the container.
builder.Services.AddScoped<IDiscountRepository,DiscountRepository>();  
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//app.MigrateDatabase<Program>();

 app.ApplyMigrations<Program>(10);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
