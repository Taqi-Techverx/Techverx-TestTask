using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Techverx.Test.Project.BaseModule.Managers.CallBack;
using Techverx.Test.Project.BaseModule.Managers.Employee;
using Techverx.Test.Project.BaseModule.Managers.Payment;
using Techverx.Test.Project.CoreApp.APIPaymentRequests.Manager;
using Techverx.Test.Project.CoreApp.Employees.Manager;
using Techverx.Test.Project.EntityFramework.DataContext;
using Techverx.Test.Project.EntityFramework.Seeder;

namespace Techverx.Test.Project
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


            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IProxyService, ProxyService.ProxyService>();
            services.AddScoped<IPaymentManager, PaymentManager>();
            services.AddTransient<IDBSeeder,DBSeeder>();
            services.AddCors(options =>
            {
	            options.AddPolicy(
		            name: "AllowOrigin",
		            builder => {
			            builder.AllowAnyOrigin()
				            .AllowAnyMethod()
				            .AllowAnyHeader();
		            });
            });
            services.AddDbContext<TestProjectDbContext>
            (options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.UseNetTopologySuite()
                ));
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentSoft", Version = "v1" });
            });
            services.AddMvcCore().AddXmlSerializerFormatters().AddApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaymentSoft v1"));
            }
            app.UseCors("AllowOrigin");

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
	            serviceScope.ServiceProvider.GetService<IDBSeeder>()?.Seed();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
