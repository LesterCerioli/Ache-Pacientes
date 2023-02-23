using AchePacientes.Api.Configurations;
using AchePacientes.Application.Services.Pacientes.Contratos;
using AchePacientes.Application.Services.Pacientes.Implementations;
using AchePacientes.CrossCutting.DependecyInjector;
using AchePacientes.CrossCutting.HealthChecks;
using AchePacientes.CrossCutting.Middlewares;
using AchePacientes.Domain.Pacientes.Interfaces;
using AchePacientes.Domain.Token;
using AchePacientes.Infrastructure.Repositories.Pacientes;
using AchePacientes.Infrastructure.Repositories.Token;
using AutoMapper;
using MediatR;
using NetDevPack.Mediator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediator();
builder.Services.AddLogger();
builder.Services.AddTwilioServices();
builder.Services.AddHealthCheckConfigurations();
builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddDatabaseConfiguration(builder.Configuration);


var configuration = new MapperConfiguration(cfg =>
{
});

builder.Services.AddTransient<IPacienteService, PacienteService>();
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IPacienteRepository, PacienteRepository>();
builder.Services.AddTransient<IRequestTokenRepository, RequestTokenRepository>();
builder.Services.AddTransient<IMediatorHandler, MediatorHandler>();
builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());

builder.Services.AddCors(options =>
{
    options.AddPolicy("my-cors",
                          policy =>
                          {
                              policy
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}
//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("my-cors");

app.Run();
