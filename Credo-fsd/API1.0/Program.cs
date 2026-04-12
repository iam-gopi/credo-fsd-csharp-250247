using API1._0;
using API1._0.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IStudent, Student>();


var app = builder.Build();

app.UseMiddleware<MyMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.Use(async (context, next) =>
{
    Console.WriteLine("middleware started 2");
    await next();
    Console.WriteLine("middleware ended 2");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}