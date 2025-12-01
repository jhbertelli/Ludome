using Ludome.Application.Middlewares;
using Ludome.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastuctureServices(builder.Configuration);

const string corsAllowOriginsString = "_corsAllowOrigins";

builder.Services.AddCors(options =>
    options.AddPolicy(corsAllowOriginsString,
        policy => policy
        .WithOrigins(builder.Configuration["ClientUrl"]!)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    )
);

var app = builder.Build();

await app.Services.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseDefaultFiles();
app.MapStaticAssets();

app.UseHttpsRedirection();

app.UseCors(corsAllowOriginsString);

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapFallbackToFile("/index.html");

await app.RunAsync();
