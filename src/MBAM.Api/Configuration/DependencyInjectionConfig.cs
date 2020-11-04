using MBAM.Api.Extensions;
using MBAM.Business.Interfaces;
using MBAM.Business.Interfaces.Repository;
using MBAM.Business.Interfaces.Services;
using MBAM.Business.Messages;
using MBAM.Business.Services;
using MBAM.Data.Context;
using MBAM.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MBAM.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyControlDbContext>();
            services.AddScoped<IMessenger, Messenger>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IArchiveRepository, ArchiveRepository>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IArchiveService, ArchiveService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
