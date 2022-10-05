using FTree.Configuration;
using FTree.Services.MongoService;

var builder = WebApplication.CreateBuilder(args);

string configFilePath = $"etc{Path.DirectorySeparatorChar}ftree-config.json";

DotNetEnv.Env.Load();

var configuration = new AppConfiguration();

builder.Configuration.AddJsonFile(configFilePath, true, true);
builder.Configuration.AddEnvironmentVariables("FTREE_");
builder.Configuration.Bind(configuration);

builder.Services.AddSingleton(configuration);

// Add services to the container.
builder.Services.AddSingleton<MongoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

if (string.IsNullOrEmpty(configuration.MongoConfig.ConnectionString))
{
    Console.WriteLine("Mongo connection string is not configured. Exiting ...");
    return;
}

app.Run();
