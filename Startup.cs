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
                                
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
              // ligação local

            //var connection = "Server=localhost\\MSSQLSERVER03;Database=catalogo;Trusted_Connection=True;"; 
            
            //Ligação AZURE
            var connection = "Server=tcp:sic-catalogo.database.windows.net,1433;Initial Catalog=catalogo;Persist Security Info=False;User ID=gestor;Password=arqsis@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<ClosetContext> (options => options.UseSqlServer (connection)); 

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
