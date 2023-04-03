using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using PB.IdentityAPI.Data;
using PB.IdentityAPI.Extensions;
using PB.IdentityAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//appSettingSection
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);


var appSettings = appSettingSection.Get<AppSettings>();
if (appSettings == null)
{
    appSettings = new AppSettings() { Secret = "0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn" };
}
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

//swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Identity API PB Rede Social",
        Description = "API de cadastro de usuario para o Projeto de Bloco .NET",
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/mit/") }, Version = "v1"
    });
} );

//Context
string connectionString = builder.Configuration.GetConnectionString("Identity");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

//Identity
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


//JWT - Authmodel // COLOCAR OAUTH
builder.Services.AddAuthentication(opt =>
{

    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(bearearOpt =>
    {
        bearearOpt.RequireHttpsMetadata = true;
        bearearOpt.SaveToken = true;
        bearearOpt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = appSettings.Audience,
            ValidIssuer = appSettings.Issuer
        };
    });


//dependency injection
builder.Services.AddScoped<TokenService, TokenService>();


//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
           
        });
});


//-----------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}



app.UseCors(opts =>
{
    opts.AllowAnyOrigin();
    opts.AllowAnyMethod();
    opts.AllowAnyOrigin();
    opts.AllowAnyHeader();
});


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
