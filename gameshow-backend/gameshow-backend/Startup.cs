using gameshow_backend.Services;
using gameshow_core.BusinessLogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshow_backend
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

            services.AddCors(options => {
                options.AddPolicy("CORSPolicy", policy => policy.WithOrigins("http://localhost:4200")
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            services.AddSingleton<ILogger>(x => new LoggerFactory().CreateLogger("BusinessLogic"));
            services.AddSingleton(typeof(IConfigProvider), typeof(ConfigProvider));
            services.AddSingleton(typeof(IDeserializationHelper), typeof(DeserializationHelper));
            services.AddSingleton(typeof(IDataAdapter), typeof(FileSystemDataAdapter));
            services.AddScoped(typeof(IPushAPI), typeof(PushAPI));
            services.AddSingleton(typeof(GameManager)); 
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "gameshow_backend", Version = "v1" });
            });
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "gameshow_backend v1"));
            }
            app.UseCors("CORSPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "DefaultApi",
                pattern: "api/{controller}/{action}/{id?}"
                );
                endpoints.MapHub<PushAPI>("/push");
            });
        }
    }
}
