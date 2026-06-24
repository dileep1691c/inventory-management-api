using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repository;
using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services;
using InventoryManagement.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);
var pemContent = File.ReadAllText(builder.Configuration["PublicKeyLocation"]);

//Initialize the RSA public key from the PEM content
var rsa = RSA.Create();
rsa.ImportFromPem(pemContent);

// Wrap it inside a RsaSecurityKey
var publicKey = new RsaSecurityKey(rsa);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection(nameof(JWTSettings)));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IInventoryManagementService<>), typeof(InventoryManagementService<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = publicKey
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine(context.Exception);
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1.0.0", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "InventoryManagement API",
        Description = "An ASP.NET Core Web API for managing inventory.",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
        Description = "Enter JWT token"
    });
    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow Inventory Management Frontend", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseCors("Allow Inventory Management Frontend");
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/1.0.0/swagger.json", "Inventory Management API"); });
app.MapControllers();
app.MapGet("/", () => "Welcome to Inventory Management API");
app.Run();