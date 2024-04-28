using EmployeeService.Helpers;
using EmployeeService.Repositories;
using EmployeeService.Services;
using System.Text.Json.Serialization;


{

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });





    builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    builder.Services.AddSingleton<DataContext>();
    builder.Services.AddScoped<DataContext>();
    builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddScoped<IEmployeeService, EmployeeService.Services.EmployeeService>();


    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();
        await context.Init();
    }

  

    
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();


    app.MapControllers();

    app.Run();
}