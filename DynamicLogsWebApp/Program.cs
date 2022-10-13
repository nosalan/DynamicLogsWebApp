using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(path: "config/logSettings.json", optional: true, reloadOnChange: true);

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

var log = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

Task.Run(async () =>
{
    await Task.Delay(TimeSpan.FromSeconds(2));
    while (true)
    {
        log.Verbose("This is a Verbose log message");
        log.Debug("This is a Debug log message");
        log.Information("This is an Information log message");
        log.Warning("This is a Warning log message");
        log.Error("This is an Error log message");
        log.Fatal("This is a Fatal log message");
        Console.WriteLine();
        await Task.Delay(1000);
    }
});

app.Run();