using Food4You.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Food4You.Model;
using Microsoft.EntityFrameworkCore;
using Food4You.Services.Database;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Food4You.Model.Requests;
using Food4You.Services.NarudzbaStateMachine;
using Microsoft.AspNetCore.Authentication;
using Food4You;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();  
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("basicAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "basic"
    });
    x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
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
builder.Services.AddScoped<IMeniService, MeniService>();
builder.Services.AddScoped<INarudzbaService, NarudzbaService>();
builder.Services.AddScoped<IRecenzijeService, RecenzijeService>();
builder.Services.AddScoped<IStatusNarudzbeService, StatusNarudzbeService>();
builder.Services.AddScoped<IStavkeNarudzbeService, StavkeNarudzbeService>();
builder.Services.AddScoped<IUplataService, UplataService>();


builder.Services.AddTransient<BaseState>();
builder.Services.AddTransient<AcceptedOrderState>();
builder.Services.AddTransient<CanceledOrderState>();
builder.Services.AddTransient<DeliveredOrderState>();
builder.Services.AddTransient<FinishedOrderState>();
builder.Services.AddTransient<InitialOrderState>();
builder.Services.AddTransient<InProgressOrderState>();


var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<Food4You.Mapper.Food4YouMapper>();

});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

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

app.UseAuthentication();

app.MapControllers();

app.Run();
