using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ExamApp.BLL.Abstract;
using ExamApp.BLL.Concrete;
using ExamApp.DAL.Abstract;
using ExamApp.DAL.Concrete.EntityFramework;

using ExamApp.WebUICore.Middlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamApp.WebUICore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

      
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IExamDal, EfExamDal>();

            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IQuestionDal, EfQuestionDal>();

            services.AddScoped<IOptionsService, OptionManager>();
            services.AddScoped<IOptionDal, EfOptionDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);
            services.AddSession();

                  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            app.UseSession();
            app.UseStaticFiles(); //wwwroot dışarıya açıldı
            app.CustomStaticFiles(); //Yazdığım middleware'i ekledim. node_modules klasörü dışarıya açıldı.
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
          
        }
    }
}
