using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneContact.EFRepository;

namespace PhoneContact.API.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddPhoneContactContext(this IServiceCollection services, string connectionString)
        {
            return services.AddEntityFrameworkSqlServer()
                    .AddDbContext<PhoneContactContext>(contextOptions =>
                    {
                        contextOptions.UseSqlServer(connectionString,
                    serverOptions =>
                    {
                        serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                    });
                    });
        }
    }
}