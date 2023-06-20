using Serilog;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.HttpOverrides;
using SwimmingStyleAPI.Extensions;
using SwimmingStyleAPI.Validation;
using SwimmingStyleAPI.Validation.StatsSwimmingstylevalidation;
using SwimmingStyleAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using SwimmingStyleAPI.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/swimmingstyle.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

/*builder.Logging.ClearProviders();
builder.Logging.AddConsole();*/

builder.Host.UseSerilog();



builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

// Add services to the container.

builder.Services
    .AddControllers(options =>
    {
        //options.RespectBrowserAcceptHeader = true;  // accept les en-têtes d’acceptation du navigateur
        options.ReturnHttpNotAcceptable = true;
    })
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SwimmingStyleContext>(dbContextOptions =>
{
    dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:SwimmingStyleDbConnectionString"]);
    //dbContextOptions.UseNpgsql(builder.Configuration.GetConnectionString("SwimmingStyleConnectionString"));
});
//  builder.Configuration.GetConnectionString("SwimmingStyleConnectionString")

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining<SwimmingStyleForCreationValidator>()
    .AddValidatorsFromAssemblyContaining<StatsSwimmingStyleForCreationValidator>();

builder.Services.AddScoped<ISwimmingStyleRepository, SwimmingStyleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthorization();

app.MapControllers();

app.Run();
