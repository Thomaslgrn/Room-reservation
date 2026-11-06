using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();   // erreurs au format ProblemDetails (RFC 9457)
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();              // 500 générique, sans pile d'appels
app.UseStatusCodePages();               // corps ProblemDetails pour les 404 sans corps

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // /openapi/v1.json
    app.MapScalarApiReference();        // interface /scalar
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
