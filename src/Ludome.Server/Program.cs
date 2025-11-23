var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string corsAllowOriginsString = "_corsAllowOrigins";

builder.Services.AddCors(options =>
    options.AddPolicy(corsAllowOriginsString,
        policy => policy
        .WithOrigins(builder.Configuration["ClientUrl"]!)
        .AllowAnyHeader()
        .AllowAnyMethod()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.MapStaticAssets();

app.UseHttpsRedirection();

app.UseCors(corsAllowOriginsString);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
