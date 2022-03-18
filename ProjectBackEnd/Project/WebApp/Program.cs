using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using App.BLL;
using App.Contracts.BLL;
using App.DAL;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using App.Domain.Identity;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("NpgsqlConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddIdentity<AppUser, AppRole>(options => { options.SignIn.RequireConfirmedAccount = false; })
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
builder.Services.AddScoped<IAppBLL, AppBLL>();
builder.Services.AddAutoMapper(
    typeof(App.DAL.DTO.MappingProfiles.AutoMapperProfile),
    typeof(App.BLL.DTO.MappingProfiles.AutoMapperProfile),
    typeof(App.DTO.MappingProfiles.AutoMapperProfile)
);



JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


builder.Services
    .AddAuthentication()
    .AddCookie(options => { options.SlidingExpiration = true; })
    .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidAudience = builder.Configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        }
    );

var supportedCultures = builder
    .Configuration
    .GetSection("SupportedCultures")
    .GetChildren()
    .Select(x => new CultureInfo(x.Value))
    .ToArray();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    // datetime and currency support
    options.SupportedCultures = supportedCultures;
    // UI translated strings
    options.SupportedUICultures = supportedCultures;

    // if nothing is found, use this
    options.DefaultRequestCulture =
        new RequestCulture(
            builder.Configuration["DefaultCulture"],
            builder.Configuration["DefaultCulture"]);

    options.SetDefaultCulture(builder.Configuration["DefaultCulture"]);

    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        // Order is important, its in which order they will be evaluated
        new QueryStringRequestCultureProvider(),
        new CookieRequestCultureProvider()
    };
});



builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

// //swagger cannot handle same name objects
// builder.Services.AddSwaggerGen(options =>
// {
//     options.CustomSchemaIds(type => $"{type.Name}_{System.Guid.NewGuid()}");
//
// });















var app = builder.Build();
AppDataHelper.SetupAppData(app, app.Environment, app.Configuration);

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{apiVersionDescription.GroupName}/swagger.json",
            apiVersionDescription.GroupName.ToUpperInvariant()
        );
    }
});



app.UseStaticFiles();

app.UseRouting();
app.UseRequestLocalization(options: app.Services.GetService<IOptions<RequestLocalizationOptions>>()?.Value!);


app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();