using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repositories;
using Holy_locket.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
//builder.Services.AddTransient<IPatientService, PatientService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseCors("MyPolicy");

app.Run();
