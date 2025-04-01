using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PirateTARpe23.ApplicationServices.Services;
using PirateTARpe23.Core.Domain;
using PirateTARpe23.Core.ServiceInterface;
using PirateTARpe23.Data;
using PirateTARpe23.Security;

namespace PirateTARpe23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IPiratesServices, PiratesServices>();
            builder.Services.AddScoped<IIslandsServices, IslandsServices>();
            builder.Services.AddScoped<IFileServices, FileServices>();
            builder.Services.AddScoped<IEmailsServices, EmailsServices>();
            builder.Services.AddScoped<IAccountsServices, AccountsServices>();
            builder.Services.AddScoped<IPlayerProfilesServices, PlayerProfilesServices>();


            builder.Services.AddDbContext<PirateTARpe23Context>
                (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 3;

                options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
                .AddEntityFrameworkStores<PirateTARpe23Context>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
                .AddDefaultUI();

            builder.Services.Configure<DataProtectionTokenProviderOptions>(
                options => options.TokenLifespan = TimeSpan.FromHours(5)
                );

            builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(
                options => options.TokenLifespan = TimeSpan.FromDays(3)
                );


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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
