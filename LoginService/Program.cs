using LoginService.Core.Conection;
using LoginService.Core.Configuraciones;
using LoginService.Repositories;
using LoginService.Services;
using LoginService.Services.Hash;
using LoginService.Services.jwt;
using LoginService.Services.Notifications;
using MicroLogin.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LogConnection");
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
builder.Services.AddTransient<IHashingServices, HashingServices>();
builder.Services.AddTransient<PasswordHasher<string>, PasswordHasher<string>>();
builder.Services.AddSingleton<DapperContext>();

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.MSSqlServer(
                connectionString,
                sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" })
            .CreateLogger();

var host = builder.Configuration.GetValue<string>("Api.Root");
var key = builder.Configuration.GetValue<string>("JwtSettings:Key");
var keyBytes = Encoding.UTF8.GetBytes(key + host);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config => {
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomExceptionNoHeadersMiddleware>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
