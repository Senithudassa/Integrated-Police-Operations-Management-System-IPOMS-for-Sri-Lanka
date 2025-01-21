using Microsoft.EntityFrameworkCore;
using testproj.Data;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});





builder.Services.AddControllers();



// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SLTechieBoy@2005")),
        ValidIssuer = "your-issuer",
        ValidAudience = "your-audience"
    };
});





builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001");


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll"); // Apply CORS globally

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();


app.UseAuthentication(); // Add Authentication Middleware
app.UseAuthorization();  // Add Authorization Middleware


app.UseExceptionHandler(builder =>
{
    builder.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception != null)
        {
            await context.Response.WriteAsJsonAsync(new { message = exception.Message });
        }
    });
});









// Enable Swagger middleware only in Development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Serves the Swagger JSON document
    app.UseSwaggerUI(); // Serves the Swagger UI (interactive API documentation)
}


app.UseStaticFiles(); // Enables serving static files

app.MapControllers();

app.Run();