using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Mail;
using Infrastructure.Mail.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtService, JwtService>();
            services.AddTransient<IMailSender, MailService>();
            services.Configure<MailSenderOptions>(configuration.GetSection("MailSender"));
            return services;
        }
    }
}
