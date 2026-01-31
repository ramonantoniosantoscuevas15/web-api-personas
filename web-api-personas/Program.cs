using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using web_api_personas;

var builder = WebApplication.CreateBuilder(args);
//var origenespermitidos =  builder.Configuration.GetValue<string>("origenespermitidos")!.Split(",");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnetion");
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseNpgsql(connectionString));


builder.Services.AddOutputCache(opciones =>
{
    opciones.DefaultExpirationTimeSpan = TimeSpan.FromSeconds(60);

    
});
var origenesPermitidos = builder.Configuration.GetValue<string>("origenesPermitos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod()
        .WithExposedHeaders("cantidadTotalRegistros");

    });
   
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
