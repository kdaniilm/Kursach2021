using Application.Infrastructure;
using AutoMapper;
using BLL.Interfaces;
using BLL.Providers;
using BLL.Servises;
using Core.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Users\User\Documents\GitHub\Kursach2021\Application\Domain\appsettings\appsettrings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("devCon"), migrations => migrations.MigrationsAssembly("Core")));

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailConfirmationProviderOption>(op => op.TokenLifespan = TimeSpan.FromHours(2));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<ApplicationContext>()
            .AddDefaultTokenProviders().AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation");

            services.AddTransient<AuthService>();
            services.AddTransient<ProductService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAuthentication().AddCookie(op => op.LoginPath = "/Login");

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddControllersWithViews();
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

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
