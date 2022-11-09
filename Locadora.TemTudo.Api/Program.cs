using Locadora.TemTudo.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string[] origens;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

origens = builder.Configuration.GetValue<string>("AppSettings:OrigensPermitidas").Split(';', StringSplitOptions.RemoveEmptyEntries);

//Configuração necessária para ligação com DbContext e Banco de dados
// Pacotes necessários para utilizar o AddDtContext: EntityFrameworkCore
// UseSqlServer necessário instalar o EntityFrameworkCore.SqlServer
builder.Services.AddDbContext<LocadoraContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbLocadora"));
    opt.EnableSensitiveDataLogging(true);
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(opt => {
    opt.AllowAnyHeader();
    opt.AllowAnyMethod();
    opt.WithOrigins(origens);
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
