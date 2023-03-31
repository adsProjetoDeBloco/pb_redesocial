using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PB.Application.InversionOfControll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("pb_redesocial", new OpenApiInfo
    {
        Title = "API PB Rede Social",
        Description = "API De rede social, para acesso ao DB onde ocorre todas as inserções relativas a Rede Social",
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/mit/") }
    });
});


DependencyInjection.Inject(builder.Services, builder.Configuration);


builder.Services.AddMvc(opts => opts.SuppressAsyncSuffixInActionNames = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/pb_redesocial/swagger.json", "pb_redesocial");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
