using InfosysTest.CartModels;
using InfosysTest.DBModel;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json;

namespace InfosysTest
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
            services.AddRazorPages();
            services.AddControllers();

            //services.AddAntiforgery(options =>
            //{
            //    options.HeaderName = "X-XSRF-TOKEN";
            //});
            
            services.AddHttpClient();
            //services.AddHttpClient("HTTP", (serviceProvider, httpClient) =>
            //{
            //    httpClient.BaseAddress = new Uri("https://localhost:44364/");
            //});
            services.AddDbContext<EmployeeCartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));
            services.AddEntityFrameworkSqlServer();
            //services.AddSwaggerGen();

            services.AddMemoryCache();
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPY", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CorsPY");

            //app.UseSwagger();
            //app.UseSwaggerUI();

            app.Use(async (context, next) =>
            {
              
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //app.UseExceptionHandler(options =>
            //{
            //    options.Run(async context =>
            //    {
            //        var a = context.Features.Get<IExceptionHandlerPathFeature>();

            //        await context.Response.WriteAsync(a.Path);
            //    });
            //});
            

            //app.Map("", app =>
            //{
            //    app.Use(async (a, b) => {
            //        b.Invoke();
            //    });
            //});
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute("", "{controller=customer}/{action=get}");
            });
        }
    }
}
