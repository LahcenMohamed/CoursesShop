using CoursesShop.Core.Middleware;
using CoursesShop.Infrastructure;
using CoursesShop.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAny",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependecies Injection
builder.Services.AddRegisrationServices(builder.Configuration);
builder.Services.AddInfrastructureDependacies();
builder.Services.AddServiceDependacies();
builder.Services.AddCoreDependacies();
#endregion

var app = builder.Build();
app.UseCors("AllowAny");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
