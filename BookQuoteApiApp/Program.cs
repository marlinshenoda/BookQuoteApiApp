using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookQuoteApiApp.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BookQuoteApiAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookQuoteApiAppContext") ?? throw new InvalidOperationException("Connection string 'BookQuoteApiAppContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
