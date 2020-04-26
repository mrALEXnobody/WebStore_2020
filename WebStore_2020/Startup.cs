using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.DAL;
using WebStore_2020.Infrastructure;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Infrastructure.Services;

namespace WebStore_2020
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // ��������� ������ �� ���� ������������ � ���� ���� �������
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(SampleActionFilter));

            // �������������� ������� �����������
            //options.Filters.Add(new SampleActionFilter());
            //});

            services.AddDbContext<WebStoreContext>(options => options
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            // ��������� ���������� �����������
            // ����� ����� �������
            // Singleton - ����� ���� ��� ����� ����� �������
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            services.AddSingleton<IProductService, InMemoryProductService>();

            // Scoped - ����� ����� Http �������
            //services.AddScoped<IEmployeesService, InMemoryEmployeeService>();
            // Transient - ����������� ������ ��� ������ �������
            //services.AddTransient<IEmployeesService, InMemoryEmployeeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // ������������� ��������� �����������
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // ����� ��������� ������ 
            // "������������� ���������� ������� ��� ����������".
            UseSample(app);

            app.UseRouting();

            // ����������� ����������� mvc
            //app.UseMvcWithDefaultRoute();

            //var helloMsg = _configuration["CustomHelloWorld"];
            //helloMsg = _configuration["Logging:LogLevel:Default"];

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync(helloMsg);
                //});
            }); 
            
            app.UseWelcomePage();
            //app.UseWelcomePage("/welcome");

            // Run ����������� ��������� �������
            RunSample(app);
        }

        private void UseSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isError = false;
                //...
                if (isError)
                {
                    await context.Response
                        .WriteAsync("Error occured. You're in custom pipline module...");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

        private void RunSample(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("������ �� ��������� ��������� ������� (����� app.Run())");
            });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }
    }
}
