using Microsoft.EntityFrameworkCore;
using SistemaMuseu.Infrastructure;
using SistemaMuseu.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Configuração da injeção de dependência
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDbContext<MuseuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllers();
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
