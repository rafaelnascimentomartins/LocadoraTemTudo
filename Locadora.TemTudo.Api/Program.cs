using Locadora.TemTudo.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Configuração necessária para ligação com DbContext e Banco de dados
// Pacotes necessários para utilizar o AddDtContext: EntityFrameworkCore
// UseSqlServer necessário instalar o EntityFrameworkCore.SqlServer
builder.Services.AddDbContext<LocadoraContext>(opt => 
opt.UseSqlServer(builder.Configuration.GetConnectionString("DbLocadora")));



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
