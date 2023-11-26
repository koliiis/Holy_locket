using Holy_locket.BLL;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Abstracts;
using Holy_locket.DAL.Models;
using Holy_locket.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HolyLocketContext>();
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<ISpecialityService, SpecialityService>();
builder.Services.AddTransient<IHospitalService, HospitalService>();
builder.Services.AddTransient<IAppointmentService, AppointmentService>();
builder.Services.AddAutoMapper(typeof(ConfigurationMapper));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Issuer"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
       };
   });
builder.Services.AddMvc();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();
var Date = "27.11.2023";
var Time = "00:00-01:00";
DateTime date = DateTime.ParseExact(Date, "dd/MM/yyyy", null);
DateTime currentDateTime = DateTime.Now;
if (currentDateTime.Date > date || (currentDateTime.Date > date && CheckTime(Time) >= 0))
{
    Console.WriteLine(true);
}
static int CheckTime(string timeRangeString)
{
    string[] parts = timeRangeString.Split('-');
    try
    {
        var endTime = DateTime.ParseExact(parts[1], "HH:mm", null); ;
        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        return currentTime.CompareTo(endTime.TimeOfDay);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return 0;
    }
}