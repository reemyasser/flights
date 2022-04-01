using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using flights.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("flightsContextConnection");
builder.Services.AddDbContext<flightsContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<flightsUser>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    options.SignIn.RequireConfirmedAccount = true;
}).
    AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<flightsContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("administrator"));
});
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection = builder.Configuration.GetSection("Authentication:Google");

       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   }).AddFacebook(
    FBoption =>
    {
        IConfigurationSection FacebookAuthNSection = builder.Configuration.GetSection("Authentication:Facebook");
        FBoption.AppId = FacebookAuthNSection["AppId"];
        FBoption.AppSecret = FacebookAuthNSection["AppSecret"];
    });



//builder.Services.AddAuthorization(options => { options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); });
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
          name: "FlightsAdmin",
    pattern: "{area}/{controller=Home}/{action=Index2}/{id?}");
   // pattern: "{ area: exists = Admin}/{ controller = Home}/{ action = Index}/{ id ?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Flights}/{controller=flight}/{action=show}/{id?}");
app.MapRazorPages();


app.Run();
