using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data; // Your namespace
using StudentRegistration.Services;
using System.Globalization; // Your namespace

var builder = WebApplication.CreateBuilder(args);
// Set default culture
builder.Services.Configure<RequestLocalizationOptions>(options => {
    options.SetDefaultCulture("en-US");
    options.AddSupportedCultures("en-US");
    options.AddSupportedUICultures("en-US");

    // Optional: Format settings
    var cultureInfo = new CultureInfo("en-US");
    cultureInfo.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
});
// Add services to the container
builder.Services.AddControllersWithViews();

// Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register your services
builder.Services.AddScoped<StudentService>();  // <-- Your service registration

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.Use(async (context, next) =>
    {
        try { await next(); }
        catch (Exception ex)
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred: {Message}", ex.Message);
            throw;
        }
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();