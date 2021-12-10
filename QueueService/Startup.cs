﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QueueService
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        public Startup(IHostEnvironment env)
        {
            //just in case we want to add config later
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();            
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddCarter();

            var builder = new ContainerBuilder();
            builder.Populate(services);

            AutofacContainer = builder.Build();
            return new AutofacServiceProvider(AutofacContainer);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(builder => builder.MapCarter());
        }
    }
}
