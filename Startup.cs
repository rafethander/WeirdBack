using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeirdBack.Models;
using WeirdBack.Services;

namespace WeirdBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string _izinVerdigimKaynaklar = "izinVerdigimKaynaklar";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<WeirdBackDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("WeirdBackDb")));

            services.AddControllersWithViews()
                        .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IExamService, ExamServices>();
            services.AddTransient<IQuestionService, QuestionService>();


            services.AddCors(opt =>
            {
                opt.AddPolicy(_izinVerdigimKaynaklar, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
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

            app.UseRouting();

            app.UseCors(_izinVerdigimKaynaklar);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
