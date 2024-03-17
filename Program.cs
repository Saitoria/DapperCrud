using DapperCrud.Data;
using DapperCrud.Interface;
using DapperCrud.Repository;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<DapperDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.WithOrigins("http://192.168.182.63:5000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials(); ;
}));
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

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
app.UseCors();
app.Run();
