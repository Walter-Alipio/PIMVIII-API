using Cadastro_Teleatendimento.Data.DAO;
using Cadastro_Teleatendimento.Data.DAO.Interface;
using Cadastro_Teleatendimento.Models;
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
builder.Services.AddScoped<IPessoaService, PessoaService>();
//DAO
builder.Services.AddScoped<IDatabaseObject<TelefoneTipo>, TipoDAO>();
builder.Services.AddScoped<IDatabaseObject<Telefone>, TelefoneDAO>();
builder.Services.AddScoped<IDatabaseObject<Endereco>, EnderecoDAO>();
builder.Services.AddScoped<IPessoaTelefone<Pessoa>, PessoaDAO>();

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
