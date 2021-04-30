using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Techverx.Test.Project.DataContext;
using Techverx.Test.Project.ProxyService;
using Techverx.Test.Project.Seeder;
using Techverx.Test.Project.Services.EmployeeRepositery;
using Techverx.Test.Project.Services.PaymentRepositery;

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
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProxyService,ProxyService.ProxyService>();
            services.AddScoped<IPaymentService, PaymentService>();
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
            services.AddDbContext<ContextClass>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
