using Microsoft.EntityFrameworkCore;
using vrumvrum.Context;
using vrumvrum.Interface;
using vrumvrum.Repository;
using vrumvrum.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("VrumDbConnection");
builder.Services.AddDbContext<VrumDbContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddScoped<IPilotoRepository, PilotoRepository>();
builder.Services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<ICorridaRepository, CorridaRepository>();

builder.Services.AddScoped<ICampeonatoService, CampeonatoService>();
builder.Services.AddScoped<ICorridaService, CorridaService>();
builder.Services.AddScoped<IPilotoService, PilotoService>();
builder.Services.AddScoped<IEquipeService, EquipeService>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
