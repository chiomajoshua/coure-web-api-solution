using Autofac;
using Autofac.Extensions.DependencyInjection;
using CoureWebAPI.Core.Helpers.Autofac;
using CoureWebAPI.Data.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(new WebApplicationOptions
    {
        ApplicationName = typeof(Program).Assembly.FullName,
        ContentRootPath = Directory.GetCurrentDirectory()
    });

    builder.Host.UseSerilog((ctx, lc) => lc
       .WriteTo.Console()
       .WriteTo.Seq("http://localhost:5341")
       .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.RegisterDatabaseService();
    builder.Services.AddMemoryCache();
    builder.Services.AddResponseCaching();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("pol",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    });
    builder.Services.AddRouting(opt => opt.LowercaseUrls = true);


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacContainerModule());
        });

    var app = builder.Build();
    app.UseSerilogRequestLogging();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseCors("pol");
    app.UseHttpsRedirection();
    app.UseResponseCaching();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}