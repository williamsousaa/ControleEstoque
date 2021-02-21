using System;
using Estocando.Data;
using Estocando.Data.Repository;
using Estocando.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Estocando
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
            services.AddDbContext<EstocandoContexto>(optionsAction: options => 
            options.UseMySql(Configuration.GetConnectionString("EstocandoConnection")));

            services.AddControllers();

            // Swagger configuração
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                   Title = "Controle de Estoque API",
                    Description = "API responsável pelo manutenção de estoque",
                    Contact = new OpenApiContact() {Name = "William de Sousa Oliveira", Email = "sousa_william@hotmail.com" },
                    License = new OpenApiLicense() {Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT")}
                });  
            });

            // Injeção de dependencia
            services.AddScoped<IProdutoRepository,ProdutoRepository>();
            services.AddScoped<EstocandoContexto>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Swagger Configuração
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        

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
        }
    }
}
