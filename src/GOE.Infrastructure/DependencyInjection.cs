using GOE.Application.Common.Interfaces;
using GOE.Infrastructure.Identity;
using GOE.Infrastructure.Mail;
using GOE.Infrastructure.Mail.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GOE.Infrastructure
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
