using System;
using DoctorsAgenda.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DoctorsAgenda.Areas.Identity.IdentityHostingStartup))]
namespace DoctorsAgenda.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DoctorsAgendaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DoctorsAgendaContextConnection")));

                services.AddDefaultIdentity<DoctorsAgenda.Areas.Identity.Data.DoctorsAgendaUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DoctorsAgendaContext>();
            });
        }
    }
}