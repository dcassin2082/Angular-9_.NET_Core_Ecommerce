using JungleApi.Web.Models;
using JungleApi.Web.Services;
using JungleApi.Web.Configuration;
using JungleApi.Web.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace JungleApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string _corsPolicy = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                    (resolver as DefaultContractResolver).NamingStrategy = null;
            });

            var connSection = Configuration.GetSection("ConnectionStrings");
            services.Configure<ConnectionSettings>(connSection);
            var connSettings = connSection.Get<ConnectionSettings>();

            var appSection = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(appSection);
            var appSettings = appSection.Get<ApplicationSettings>();
            var key = Encoding.UTF8.GetBytes(appSettings.ClientSecret);

            services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(connSettings.IdentityConnection));
            services.AddDbContext<JungleDbContext>(options => options.UseSqlServer(connSettings.JungleDbConnection));

            // Add default identity 
            services.AddIdentity<ApplicationUser, IdentityRole>().
                AddEntityFrameworkStores<AuthenticationContext>().
                AddDefaultTokenProviders();

            // configure identity options to override default options            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });

            AuthorizationHelper.AddAuthentication(services, key);

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IChartService, ChartService>();
            services.AddTransient<ICustomerOrderService, CustomerOrderService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
