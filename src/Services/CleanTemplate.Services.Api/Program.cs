using CleanTemplate.Infrastructure.Core;
using CleanTemplate.Application.Core;
using CleanTemplate.Transversal.Core;
using CleanTemplate.Services.Api;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddTransversalServices();

string corsPolicy = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
