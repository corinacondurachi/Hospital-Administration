using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using project_hospital_admin.Areas.Identity.Data;
using project_hospital_admin.Models;

[assembly: HostingStartup(typeof(project_hospital_admin.Areas.Identity.IdentityHostingStartup))]
namespace project_hospital_admin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<project_hospital_adminIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("project_hospital_adminIdentityDbContextConnection")));

                /*services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<project_hospital_adminIdentityDbContext>();*/
            });
        }
    }
}