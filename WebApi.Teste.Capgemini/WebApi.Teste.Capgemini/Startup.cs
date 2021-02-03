using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Teste.Capgemini.DbContextCapgemini;
using Repository.Teste.Capgemini.Repository;
using Repository.Teste.Capgemini.Repository.Interface;
using Services.Teste.Capgemini.Service;
using Services.Teste.Capgemini.Service.Interface;

namespace WebApi.Teste.Capgemini
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

            services.AddDbContext<CapgeminiContext>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));
            services.AddScoped<IinitChargeService, InitChargeService>();
            services.AddScoped<IinitChargeRepository, InitChargeRepository>();
            services.AddScoped<IplanilhaService, PlanilhaService>();
            services.AddScoped<IplanilhaRepository, PlanilhaRepository>();

                      
            Mapper.Initialize(x => x.AddProfile<Repository.Teste.Capgemini.Mapping.MappingProfile>());

            services.AddCors(options => {
                options.AddPolicy("AllowDev",
                 builder => builder.WithOrigins("*").AllowAnyHeader()
                    .AllowAnyMethod()
                 );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowDev");
            }

        }
    }
}
