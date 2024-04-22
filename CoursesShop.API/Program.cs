using CoursesShop.Data.Identity;
using ECommerceCourse.DataAccess.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CoursesShop.Infrastructure;
using CoursesShop.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext Dependecies
builder.Services.AddDbContext<CoursesShopDbContext>(x =>
               x.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceCourseDbConnectionString")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
}
).AddEntityFrameworkStores<CoursesShopDbContext>();
#endregion

#region Dependecies Injection
builder.Services.AddInfrastructureDependacies();
builder.Services.AddServiceDependacies();
builder.Services.AddCoreDependacies();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
