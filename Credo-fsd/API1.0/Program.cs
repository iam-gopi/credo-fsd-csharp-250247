using System.Text;
using API1._0;
using API1._0.Controllers;
using API1._0.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mysqlx.Expect;
using Student = API1._0.Services.Student;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "server=localhost;user id=root;password=;database=fsdclass";

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

// builder.Services.AddAuthentication(o =>
// {
//     o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// }).AddJwtBearer(options =>
// {
//     options.RequireHttpsMetadata = false;
//     options.TokenValidationParameters = new TokenValidationParameters()
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateIssuerSigningKey =  true,
//         ValidIssuer = builder.Configuration.GetSection("Jwt")["Issuer"],
//         ValidAudience = builder.Configuration.GetSection("Jwt")["Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt")["Key"]))
//     };
// });

// builder.Services.AddAuthorization();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStudent, Student>();


var app = builder.Build();
//
// app.UseMiddleware<MyMiddleware>();
// app.UseMiddleware<ExceptionMiddleware>();
// app.Use(async (context, next) =>
// {
//     Console.WriteLine("middleware started 2");
//     await next();
//     Console.WriteLine("middleware ended 2");
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}