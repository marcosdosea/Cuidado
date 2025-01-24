using Core.Service;
using Core;
using Microsoft.EntityFrameworkCore;
using Service;
using CuidadoWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace CuidadoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var connectionString = builder.Configuration.GetConnectionString("CuidadoDatabase")
                ?? throw new InvalidOperationException(); ;
            builder.Services.AddDbContext<CuidadoContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            connectionString = builder.Configuration.GetConnectionString("IdentityDatabase")
                ?? throw new InvalidOperationException(); ;
            builder.Services.AddDbContext<IdentityContext>(
                options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddDefaultIdentity<UsuarioIdentity>(
                 options =>
                 {
                     // SignIn settings
                     options.SignIn.RequireConfirmedAccount = false;
                     options.SignIn.RequireConfirmedEmail = false;
                     options.SignIn.RequireConfirmedPhoneNumber = false;

                     // Password settings
                     options.Password.RequireDigit = true;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequiredLength = 6;

                     // Default User settings.
                     options.User.AllowedUserNameCharacters =
                             "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                     //options.User.RequireUniqueEmail = true;

                     // Default Lockout settings
                     options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                     options.Lockout.MaxFailedAccessAttempts = 5;
                     options.Lockout.AllowedForNewUsers = true;
                 }
            ).AddRoles<IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Identity/Autenticar";
                options.Cookie.Name = "CuidadoCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                //options.LoginPath = "/Identity/Autenticar";
                // ReturnUrlParameter requires 
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            // Block anonymous access by default on new controllers. E.g. do not
            // require to add [Authorize] on every controller.
            builder.Services.AddAuthorization(options => {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            builder.Services.AddTransient<ICuidadoService, CuidadoService>();
            builder.Services.AddTransient<IProdutoService, ProdutoService>();
            builder.Services.AddTransient<IFuncionarioService, FuncionarioService>();
            builder.Services.AddTransient<IVisitanteService, VisitanteService>();

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

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
