using System;
using hospital_administration.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(hospital_administration.Areas.Identity.IdentityHostingStartup))]
namespace hospital_administration.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<hospital_administrationIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("hospital_administrationIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<hospital_administrationIdentityDbContext>();
            });
        }
    }
}