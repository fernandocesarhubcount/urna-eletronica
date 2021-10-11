using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using API_VOTOS.Context;
using API_VOTOS.Repository;

namespace API_VOTOS
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_VOTOS", Version = "v1" });
            });

            //Urna_Local Tipo de string -> @"Server=localhost;Initial Catalog=Urna;Integrated Security=True;";
            //Urna_UsuarioSenha Tipo de string ->  @"Server=localhost;Database=Urna;User Id=marcos;Password=marcos;";


            // [AUTH LOCAL]
            var connection = Configuration.GetConnectionString("Urna_Local");
            // [ ALTERAR NO ARQUIVO APP.SETTINGS COM O USUARIO E SENHA]
            //var connection = Configuration.GetConnectionString("Urna_UsuarioSenha");


            services.AddDbContext<UrnaContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<CandidatosRepository>();
            services.AddTransient<VotosRepository>();
            //services.AddSingleton<UrnaContext>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy",
                    policy =>
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_VOTOS v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowAnyCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
