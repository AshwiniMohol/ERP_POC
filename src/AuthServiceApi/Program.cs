using AuthServiceApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer( token =>
    {
        var key = builder.Configuration["Jwt:Key"] ?? "super_secret_key_123";
        token.TokenValidationParameters = new ()
        {
            ValidateIssuer = false,
            ValidateAudience   = false,
            ValidateIssuerSigningKey  = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateLifetime = true
        };
    });
builder.Services.AddCors(o =>
{
    o.AddPolicy("ui", p => p
          .WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new() { UserName = "admin", Password = "admin123", Role = "Admin" },
            new() { UserName = "manager", Password = "manager123", Role = "InventoryManager" },
            new() { UserName = "employee", Password = "employee123", Role = "Employee" }
        );
        db.SaveChanges();
    }
}

app.UseCors("ui");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

