using Ans_Middleware.Data;
using Ans_Middleware.Middlewares;
using Ans_Middleware.Models;
using Ans_Middleware.Repositories;
using Ans_Middleware.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);   

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlite("DataSource=file::memory:?cache=shared"));
//builder.Services.AddSingleton<CurrentHeader>();
//builder.Services.AddScoped<IHeaderRepository, SQLHeaderRepository>();
builder.Services.AddScoped<HeaderService>();

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    dbContext.InitializeDatabase();
//}


// Configure the HTTP request pipeline.

app.UseMiddleware<HeaderMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
