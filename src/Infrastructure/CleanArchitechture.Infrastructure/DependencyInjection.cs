using CleanArchitechture.Application.Services.Auth;
using CleanArchitechture.Application.Services.Messages.Kafka;
using CleanArchitechture.Application.Services.Users;
using CleanArchitechture.Domain;
using CleanArchitechture.Infrastructure.Messages.Kafka;
using CleanArchitechture.Infrastructure.Messages.Kafka.Configurations;
using CleanArchitechture.Infrastructure.Persistence;
using CleanArchitechture.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitechture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Test");
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #region Mapping Configuration
            services.Configure<SendGridConfig>(configuration.GetSection("Sendgrid"));
            services.Configure<ConsumerSettings>(configuration.GetSection("Kafka:Consumer"));
            services.Configure<ProducerSettings>(configuration.GetSection("Kafka:Producer"));
            services.Configure<S3Config>(configuration.GetSection("S3Config"));
            services.Configure<TokenConfig>(configuration.GetSection("jwt"));
            #endregion
            #region Register Services
            services.AddScoped<IProducer, Producer>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IS3Service, S3Service>();
            services.AddScoped<ITokenService, TokenService>();
            #endregion
            // services.AddHostedService<Consumer>();
            return services;
        }

        public static void ConfigureInfra(this IApplicationBuilder app )
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }
        }
    }
}
