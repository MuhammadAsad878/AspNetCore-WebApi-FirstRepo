using Microsoft.EntityFrameworkCore;
using FirstApiProj.Data;
using FluentValidation.AspNetCore;
using FirstApiProj.Repository;
using FirstApiProj.Repository.Interfaces;
using FirstApiProj.Service;
using FirstApiProj.Service.Interfaces;
using FluentValidation;
using FirstApiProj.Validators;
using FirstApiProj.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Fluent-Validations setup
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<DtoCreateStudent>, ValidatorCreateStudent>();
builder.Services.AddScoped<IValidator<DtoStudentUpdate>, ValidatorUpdateStudent>();
builder.Services.AddScoped<IValidator<DtoRegister>, ValidatorRegisterUser>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>(); // Assuming you have a StudentService that implements IStudentService

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
