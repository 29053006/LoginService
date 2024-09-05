using LoginService.Core.Conection;
using LoginService.Core.Configuraciones;
using LoginService.Repositories;
using LoginService.Services;
using LoginService.Services.jwt;
using LoginService.Services.Notifications;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<IRepositories, Repositories>();
builder.Services.AddTransient<INotifiServices, NotifiServices>();
builder.Services.AddTransient<IConfigurations, Configurations>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddSingleton<DapperContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
