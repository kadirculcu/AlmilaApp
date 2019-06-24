using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmilaApp.Business.Abstract;
using AlmilaApp.Business.Concrete;
using AlmilaApp.Core.DataAccess;
using AlmilaApp.Core.DataAccess.EntityFramework;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlmilaApp.MvcUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region DbContext

            services.AddTransient<DbContext, AlmilaContext>();
            services.AddScoped(typeof(IEntityRepository<>), typeof(efEntityRepositoryBase<>));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddDbContext<AlmilaContext>(options => options
            //        .UseSqlServer(Configuration.GetConnectionString("Default")),
            //        ServiceLifetime.Transient);

            #endregion

            services.AddMvc();
            services.AddTransient<ILessonService, LessonManager>();
            services.AddTransient<ILessonDal, efLessonDal>();

            services.AddTransient<IStudentService, StudentManager>();
            services.AddTransient<IStudentDal, efStudentDal>();

            services.AddTransient<INoteService, NoteManager>();
            services.AddTransient<INoteDal, efNoteDal>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
