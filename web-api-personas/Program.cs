using Microsoft.EntityFrameworkCore;
using web_api_personas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnetion");
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseNpgsql(connectionString));
builder.Services.AddOutputCache(opciones =>
{
    opciones.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(10);
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllers();

app.Run();
