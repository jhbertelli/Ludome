using Ludome.Domain;
using Ludome.Domain.Repositories;
using Ludome.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludome.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastuctureServices(this IServiceCollection services, ConfigurationManager appSettings)
        {
            services.AddDbContext<LudomeDbContext>(options =>
                options.UseNpgsql(
                    appSettings.GetConnectionString("LudomeDbConnectionString")
                )
            );

            services.ConfigureRepositories();

            services.ConfigureIdentity(appSettings);

            services.ConfigureSession();
        }

        public static async Task MigrateDatabase(this IServiceProvider appServices)
        {
            using var scope = appServices.CreateScope();
            using var dbContext = scope
                .ServiceProvider
                .GetRequiredService<LudomeDbContext>();

            await dbContext.Database.MigrateAsync();
            await Seeder.SeedAsync(dbContext);
        }

        private static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        private static void ConfigureIdentity(this IServiceCollection services, ConfigurationManager appSettings)
        {
            services
                .AddIdentityCore<User>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;
                })
                .AddTokenProvider<DataProtectorTokenProvider<User>>("Ludome")
                .AddEntityFrameworkStores<LudomeDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = appSettings["Jwt:Issuer"],
                        ValidAudience = appSettings["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(appSettings["Jwt:Key"]!)
                        )
                    });
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
