﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MorgenBuffet.Areas.Identity.Data;
using MorgenBuffet.Data;

[assembly: HostingStartup(typeof(MorgenBuffet.Areas.Identity.IdentityHostingStartup))]
namespace MorgenBuffet.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MorgenBuffetContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MorgenBuffetContextConnection")));

                services.AddDefaultIdentity<MorgenBuffetUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MorgenBuffetContext>();
            });
        }
    }
}