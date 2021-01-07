using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using project_hospital_admin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using project_hospital_admin.Models;

namespace project_hospital_admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseNpgsql(
                    Configuration.GetConnectionString("PatientDbContextConnection")));
             services.AddDatabaseDeveloperPageExceptionFilter();
            
            /*services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PatientDbContextConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();*/

            // services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //     .AddEntityFrameworkStores<ApplicationDbContext>();
            // services.AddControllersWithViews();
            //  services.AddRazorPages();
             
             services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                 .AddRoleManager<RoleManager<IdentityRole>>()
                 .AddDefaultUI() 
                 .AddDefaultTokenProviders()
                  .AddEntityFrameworkStores<ApplicationDbContext>();
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            
            Roles(serviceProvider);
        }
        
        private void Roles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            Task<bool> var = roleManager.RoleExistsAsync("Patient");
            var.Wait();
            Task<bool> var2 = roleManager.RoleExistsAsync("Doctor");
            var2.Wait();
            Task<bool> var1 = roleManager.RoleExistsAsync("Admin");
            var1.Wait();

            if (var.Result)
            {
                var roleResult = roleManager.CreateAsync(new IdentityRole("Patient"));
                roleResult.Wait();
            }
            
            if (var2.Result)
            {
                var roleResult = roleManager.CreateAsync(new IdentityRole("Doctor"));
                roleResult.Wait();
            }
            
            if (var1.Result)
            {
                var roleResult = roleManager.CreateAsync(new IdentityRole("Admin"));
                roleResult.Wait();
                
                var newUser = new ApplicationUser();
                newUser.Email = "corina@gmail.com";
                newUser.UserName = "corina@gmail.com";
                newUser.Cnp = "2999999999999";
                newUser.Sex = "F";
                newUser.FirstName = "Corina";
                newUser.LastName = "Corina";
                newUser.PhoneNumber = "0777777777";
                newUser.Role = "Admin";
                

                Task<IdentityResult> task = userManager.CreateAsync(newUser, "Parola99!");
                task.Wait();
                
                if (task.Result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, "Admin").Wait(); 
                    
                }
                
            }

        }
  
    }
}

