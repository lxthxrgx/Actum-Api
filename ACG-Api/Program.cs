using Microsoft.EntityFrameworkCore;
using Actum_Api.service;
using Actum_Api.model.XPath;
using Actum_Api.service.AutoDocService.sublease.fop;
using Actum_Api.service.AutoDocService.sublease.tov;
using Microsoft.Extensions.Options;
using Actum_Api.config;
using Actum_Api.Database;
using Models.model;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF CORE CONNECTON

builder.Services.AddDbContext<DatabaseModel>(options =>
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

//PATH TO FOLDER FOR SAVE AGREEMENTS
builder.Services.Configure<PathSettings>(
    builder.Configuration.GetSection("PathToSaveAgreements"));

//FOR USING SETTINGS FROM APPSETTINGS.JSON
ConfigHelper.Configuration = builder.Configuration;

//Denpendency Injections
// builder.Services.AddScoped<GuardService>();
builder.Services.AddScoped<Groups>();

builder.Services.AddTransient<Func<string, XPathProcessor>>(provider =>
{
    var options = provider.GetRequiredService<IOptions<PathSettings>>();
    return path => new XPathProcessor(path);
});
builder.Services.AddTransient<SubleseTovDog>();
builder.Services.AddTransient<SubleaseTovTermination>();
builder.Services.AddTransient<SubleaseFopDogAct>();
builder.Services.AddTransient<SubleaseFopReturnAct>();
builder.Services.AddTransient<SubleaseFopTermination>();
builder.Services.AddTransient<SubleaseTovReturnAct>();

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
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173","http://localhost:3000", "http://10.10.110.105:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
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

// app.UseStaticFiles(new StaticFileOptions
// {
//     FileProvider = new PhysicalFileProvider(staticFilesPath),
//     RequestPath = "/pdf",
// });

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
