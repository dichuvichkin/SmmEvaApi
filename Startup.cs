using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using SmmEvaApi.Models.User;
using SmmEvaApi.Models.User.Builders;
using SmmEvaApi.Services.UserService.Builders;
using SmmEvaApi.Services.UserService.Editors;
using UserContext = SmmEvaApi.Context.UserContext;

namespace SmmEvaApi
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
            var connectionString = Configuration.GetConnectionString("SmmDatabaseContext");

            services
                .AddEntityFrameworkNpgsql()
                .AddDbContext<UserContext>(options => options.UseNpgsql(connectionString));

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCoursesClient",
                    builder => builder.WithOrigins("http://localhost:3000")
                );
            });

            services.AddScoped<IUserBuilder, UserBuilder>();
            services.AddScoped<IUserEditor, UserEditor>();
            services.AddScoped<IEditUserBuilder, EditUserBuilder>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}