using System.Text;
using FinanzasBE.Converters;
using FinanzasBE.Data;
using FinanzasBE.Entities;
using FinanzasBE.Helpers;
using FinanzasBE.Services;
using FinanzasBE.ServicesImpl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace FinanzasBE
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

            // Configuración de los objetos
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            // Configuración de jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            // Configuración de injección de dependencias
            // Servicios
            services.AddScoped<IUserService, UserServiceImpl>();
            services.AddScoped<IPymeService, PymeServiceImpl>();
            services.AddScoped<IBillService, BillServiceImpl>();
            services.AddScoped<IBankService, BankServiceImpl>();
            services.AddScoped<IDiscountPoolService, DiscountPoolServiceImpl>();
            services.AddScoped<IDiscountService, DiscountServiceImpl>();
            services.AddScoped<ICostService, CostServiceImpl>();

            // Convertidores
            services.AddScoped<BillConverter>();
            services.AddScoped<PymeConverter>();
            services.AddScoped<DiscountConverter>();
            services.AddScoped<CreateDiscountPoolConverter>();
            services.AddScoped<DiscountPoolOutputConverter>();


            services.AddDbContext<FinanzasContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresqlConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Global cors policy
            // Permitir cualquier origen
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Utilizar autenticación
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}