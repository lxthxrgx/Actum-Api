using Microsoft.EntityFrameworkCore;
using ACG_Api.Database;
using Microsoft.Extensions.FileProviders;
using System.Net;
using System.Security.Cryptography.X509Certificates;

// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF CORE CONNECTON

builder.Services.AddDbContext<NewDatabaseModel>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging(false);
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
        .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
        .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
});

// builder.Services.AddDbContext<NewDatabaseModel>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("NewDatabaseConnection"));
//     options.EnableSensitiveDataLogging(false);
//     options.UseLoggerFactory(LoggerFactory.Create(builder => builder
//         .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
//         .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
// });

// builder.Services.AddDbContext<DataBaseArchive>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("ArchiveConnection"));
//     options.UseLoggerFactory(LoggerFactory.Create(builder => builder
//         .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
//         .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
// });

// builder.Services.AddDbContext<DataBaseUser>(options =>
// {
//     options.UseSqlite(builder.Configuration.GetConnectionString("UserConnection"));
//     options.UseLoggerFactory(LoggerFactory.Create(builder => builder
//         .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
//         .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
// });

// builder.Services.AddDbContext<MemoryDb>(options =>
// {
//     options.UseInMemoryDatabase("InMemoryDb");
//     options.UseLoggerFactory(LoggerFactory.Create(builder => builder
//         .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
//         .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
// });

//TASKMANAGER CONECCTION TO DATABASE
//builder.Services.AddDbContext<TaskManager>(options =>
//{
//    options.UseSqlite(builder.Configuration.GetConnectionString("TaskManagerConnection"));
//    options.EnableSensitiveDataLogging(false);
//    options.UseLoggerFactory(LoggerFactory.Create(builder => builder
//        .AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)
//        .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.Warning)));
//});

//CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:3000", "http://localhost:5175")
//                                .AllowAnyMethod()
//                                .AllowAnyHeader();
//                      });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// CERTIFICATE HTTPS & HTTP SETTINGS
var certificatePath = builder.Configuration["CertificatePath"];
var certificatePassword = builder.Configuration["CertificatePassword"];
var cert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.MachineKeySet);

var httpsIP = IPAddress.Parse(builder.Configuration["HttpsIP"] ?? "0.0.0.0");
var staticIP = IPAddress.Parse(builder.Configuration["StaticIP"] ?? "0.0.0.0");
var staticPortHttps = int.Parse(builder.Configuration["StaticPortHttps"] ?? "5001");
var staticPortHttp = int.Parse(builder.Configuration["StaticPortHttp"] ?? "8080");

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(httpsIP, staticPortHttps, listenOptions =>
    {
        listenOptions.UseHttps(cert);
    });

    options.Listen(staticIP, staticPortHttp);
});

string staticFilesPath = builder.Configuration["StaticFilesPath"] ?? "u'r file path";

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//PATH TO PDF FILES
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(staticFilesPath),
    RequestPath = "/pdf",
});

app.UseHttpsRedirection();
//app.UseCors(MyAllowSpecificOrigins);
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
