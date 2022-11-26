using Cadastro_Teleatendimento.Data;
using Cadastro_Teleatendimento.Services;
using Cadastro_Teleatendimento.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//dependency injection
//services
builder.Services.AddScoped<ITelefoneTipoService, TelefoneTipoService>();
builder.Services.AddScoped<ITelefoneService, TelefoneService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
//DAO
builder.Services.AddScoped<TipoDAO, TipoDAO>();
builder.Services.AddScoped<TelefoneDAO, TelefoneDAO>();
builder.Services.AddScoped<EnderecoDAO, EnderecoDAO>();

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
