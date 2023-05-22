using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using productscategories;
using productscategories.Data;
using productscategories.Middleware;
using productscategories.Reporters;
using productscategories.Repository;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectContext")));

using (var context = new ProjectContext(builder.Configuration))
{
    await context.Database.MigrateAsync();
}

builder.Services.AddScoped<IProductCategorieRepository, ProductCategorieSqlRepository>();
builder.Services.AddSingleton<MetricReporter>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "RedisDemo_";
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        SeedData.Initialize(builder.Configuration);
    }
    catch (Exception ex)
    {
        throw new Exception(ex.ToString());
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMetricServer();

app.UseMiddleware<ResponseMetricMiddleware>();

app.MapControllers();

app.Run();
