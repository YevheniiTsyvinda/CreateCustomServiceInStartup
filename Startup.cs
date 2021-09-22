using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Diagnostics;

namespace CreateCustomServiceInStartup
{
    public class Startup
    {
        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("conf.json")
            .AddInMemoryCollection(new Dictionary<string, string> { { "name", "Tom" }, { "age", "31" } }).AddConfiguration(configuration);
            Configuration = builder.Build();//configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // services.AddSingleton<ICounter,RandomCounter>();
            // services.AddSingleton<CountereService>();
            //services.AddTimeService();

            //services.AddTransient<IConfiguration>(provider => AppConfiguration);
            _services = services;
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseMiddleware<CounterMiddleware>();
            //var color = Configuration["color"];      // определен в файле conf.json
            //string text = Configuration["JAVA_HOME"]; // определен в переменных среды окружения
            // app.Use(async (context,next) => {
            //     context.Items["text"] = "My Text";
            //     await next.Invoke();
            // });

            // app.Use(async (context, next) =>
            // {
            //     Endpoint endpoint = context.GetEndpoint();
            //     if (endpoint != null)
            //     {
            //         var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;
            //         Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
            //         Debug.WriteLine($"Endpoint pattern: {routePattern}");
            //         await next();
            //     }
            //     else
            //     {
            //         Debug.WriteLine("Endpoint: null");
            //         await context.Response.WriteAsync("Endpoint is not defined");
            //     }
            // });

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/index", async context =>
            //     {
            //         await context.Response.WriteAsync("index");
            //     });
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Home");
            //     });
            // });

            // app.Run(async(context)=>{
            //     if(context.Request.Cookies.ContainsKey("name")){
            //         string name = context.Request.Cookies["name"];
            //         await context.Response.WriteAsync($"Hello {name}");
            //     }else{
            //         context.Response.Cookies.Append("name","Tom");
            //         await context.Response.WriteAsync("Hello World");
            //     }

            //     // context.Response.ContentType = "text/html; charset=utf-8";
            //     // await context.Response.WriteAsync($"Text: {context.Items["text"]}");

            //     // var sb = new StringBuilder();
            //     // sb.Append("<h1>All Services</h1>");
            //     // sb.Append("");
            //     // sb.Append("<table>");
            //     // sb.Append("<tr><th>Тип</th><th>Lifetime</th><th>Реализация</th></tr>");
            //     // foreach (var srv in _services)
            //     // {
            //     //     sb.Append("<tr>");
            //     //     sb.Append($"<td>{srv.ServiceType.FullName}</td>");
            //     //     sb.Append($"<td>{srv.Lifetime}</td>");
            //     //     sb.Append($"<td>{srv.ImplementationType?.FullName}</td>");
            //     //     sb.Append("</tr>");
            //     // }
            //     //     sb.Append("</table>");
            //     // context.Response.ContentType = "text/html;charset=utf-8";
            //     // await context.Response.WriteAsync(sb.ToString());
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
