using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ClosetApi.Models;

namespace ClosetApi
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ClosetContext>(opt => 
                opt.UseInMemoryDatabase("ProductList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }

        // // This method gets called by the runtime. Use this method to add services to the container.
        // public void ConfigureServices(IServiceCollection services)
        // {
        //     services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        // }

        // // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        // {
        //     if (env.IsDevelopment())
        //     {
        //         app.UseDeveloperExceptionPage();
        //     }
        //     else
        //     {
        //         app.UseHsts();
        //     }

        //     app.UseHttpsRedirection();
        //     app.UseMvc();
        // }
    }
}
