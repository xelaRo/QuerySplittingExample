using Microsoft.EntityFrameworkCore;
using QuerySplittingExample.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(options => 
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MyDbConnectionString"), 
        options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
        );
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine, LogLevel.Information);
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
