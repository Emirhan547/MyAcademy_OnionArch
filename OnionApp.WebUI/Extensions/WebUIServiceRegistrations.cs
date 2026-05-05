using OnionApp.WebUI.Services.AboutServices;
using OnionApp.WebUI.Services.AuthorServices;
using OnionApp.WebUI.Services.AuthServices;
using OnionApp.WebUI.Services.BannerServices;
using OnionApp.WebUI.Services.BlogServices;
using OnionApp.WebUI.Services.BrandServices;
using OnionApp.WebUI.Services.CarDescriptionServices;
using OnionApp.WebUI.Services.CarFeatureServices;
using OnionApp.WebUI.Services.CarPricingServices;
using OnionApp.WebUI.Services.CarServices;
using OnionApp.WebUI.Services.CategoryServices;
using OnionApp.WebUI.Services.CommentServices;
using OnionApp.WebUI.Services.ContactServices;
using OnionApp.WebUI.Services.FeatureServices;
using OnionApp.WebUI.Services.FooterAddressServices;
using OnionApp.WebUI.Services.LocationServices;
using OnionApp.WebUI.Services.PricingServices;
using OnionApp.WebUI.Services.RentACarServices;
using OnionApp.WebUI.Services.ReservationServices;
using OnionApp.WebUI.Services.ReviewServices;
using OnionApp.WebUI.Services.ServiceServices;
using OnionApp.WebUI.Services.SocialMediaServices;
using OnionApp.WebUI.Services.StatisticsServices;
using OnionApp.WebUI.Services.TagCloudServices;
using OnionApp.WebUI.Services.TestimonialServices;
using OnionApp.WebUI.Services.UserInsightServices;

namespace OnionApp.WebUI.Extensions
{
    public static class WebUIServiceRegistrations
    {
        public static void AddServiceExt(this IServiceCollection services)
        {
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAuthSessionService, AuthSessionService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICarPricingService, CarPricingService>();
            services.AddScoped<ICarFeatureService, CarFeatureService>();
            services.AddScoped<ICarDescriptionService, CarDescriptionService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRentACarService, RentACarService>();
            services.AddScoped<IFooterAddressService, FooterAddressService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IPricingService, PricingService>();
            services.AddScoped<ITagCloudService, TagCloudService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IUserInsightService, UserInsightService>();
        }
    }
}
