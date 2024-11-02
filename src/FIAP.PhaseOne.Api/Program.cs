using FIAP.PhaseOne.Infra;
using FIAP.PhaseOne.Api;
using FIAP.PhaseOne.Application.Shared;
using FIAP.PhaseOne.Api.Middleware;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddApiService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Services.CreateScope().ServiceProvider.UpdateMigrate();

app.Run();
