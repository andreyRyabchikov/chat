using chat.Repository;
using chat.WebAPI.AppConfiguration.ApplicationExtensions;
using chat.WebAPI.AppConfiguration.ServicesExtensions;
using chat.Services;
using Serilog;


var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json", optional: false)
.Build();  

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilogConfiguration(); //Add serilog
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddMapperConfiguration();
builder.Services.AddControllers(); //1
builder.Services.AddSwaggerConfiguration();
builder.Services.AddRepositoryConfiguration();
builder.Services.AddBusinessLogicConfiguration();



var app = builder.Build();

app.UseSerilogConfiguration(); //use serilog

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration(); //use swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}