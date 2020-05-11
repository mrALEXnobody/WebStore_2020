using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
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

            // ����������� Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<WebStoreContext>()
                .AddDefaultTokenProviders();


            // �������������
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
            });

            // �������������
            services.ConfigureApplicationCookie(options =>
            {
                //    options.Cookie.HttpOnly = true;
                //    options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            // ��������� ���������� �����������
            // ����� ����� �������
            // Singleton - ����� ���� ��� ����� ����� �������
            services.AddSingleton<IEmployeesService, InMemoryEmployeeService>();
            //services.AddSingleton<IProductService, InMemoryProductService>();
            services.AddScoped<IProductService, SqlProductService >();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CookieCartService>();
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
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // ������������� ��������� �����������
            app.Map("/index", CustomIndexHandler);

            app.UseMiddleware<TokenMiddleware>();

            // ����� ��������� ������ 
            // "������������� ���������� ������� ��� ����������".
            UseSample(app);

            //app.UseRouting();

            // ����������� ����������� mvc
            //app.UseMvcWithDefaultRoute();

            //var helloMsg = _configuration["CustomHelloWorld"];
            //helloMsg = _configuration["Logging:LogLevel:Default"];

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

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
