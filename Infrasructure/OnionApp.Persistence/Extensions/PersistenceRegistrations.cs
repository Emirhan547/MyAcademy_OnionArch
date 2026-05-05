using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application.AI.Services;
using OnionApp.Application.Contracts;
using OnionApp.Domain.Entities;
using OnionApp.Persistence.AI;
using OnionApp.Persistence.Concrete;
using OnionApp.Persistence.Context;
namespace OnionApp.Persistence.Extensions
{
    public static class PersistenceRegistrations
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.SectionName));
            services.Configure<MlNetOptions>(configuration.GetSection(MlNetOptions.SectionName));
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(connectionString);
            });

            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<AppRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
            services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            services.AddScoped<IUserEventPublisher, RabbitMqUserEventPublisher>();
            services.AddScoped<IRecommendationService, MlNetUserInsightService>();
            services.AddScoped<IChurnPredictionService, MlNetUserInsightService>();
            services.AddScoped<IPriceSuggestionService, MlNetUserInsightService>();
            services.AddScoped<ISentimentAnalysisService, MlNetUserInsightService>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }

    }
}