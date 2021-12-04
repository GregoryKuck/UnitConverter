using UnitConverters;
using UnitConverters.Data;
using UnitConverters.Data.Repositories;
using UnitConverters.Options;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Controller setup
//builder.Services.AddApiVersioning();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Logging, DB and Config setup
builder.Services.AddLogging();  
builder.Services.AddDbContext<UnitConversionContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UnitConversionDBDatabase")));
builder.Services.Configure<ConverterOptions>(builder.Configuration.GetSection("ConverterOptions"));

//Add services
builder.Services.AddTransient<IConversionRatesRepo, ConversionRatesRepo>();
builder.Services.AddScoped<IConversionManager, DatatableConversionManager>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//NOTE: Remove this if you don't want it to create a DB on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<UnitConversionContext>();
        DbInitialiser.Initialise(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.Run();


