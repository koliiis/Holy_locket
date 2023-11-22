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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
    });

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();
