using Food4You.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Food4You.Model;
using Microsoft.EntityFrameworkCore;
using Food4You.Services.Database;
using Microsoft.OpenApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic"
    });
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[] { }
        }
    });

});

builder.Services.AddScoped<IDrzavaService, DrzavaService>();
builder.Services.AddScoped<IKorisniciService, KorisniciService>();
builder.Services.AddScoped<IUlogeService, UlogeService>();
builder.Services.AddScoped<IGradService, GradService>();
builder.Services.AddScoped<IKategorijaService, KategorijaService>();



var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<Food4You.Mapper.Food4YouMapper>();

});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddAutoMapper(typeof(Program));

//ConnectionString
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
var context = builder.Services.AddDbContext<Food4YouContext>(options =>
    options.UseSqlServer(connectionstring));

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
