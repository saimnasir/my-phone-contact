using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneContact.Services.Contracts;
using PhoneContact.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PhoneContact.Services.Extensions
{
   public static class DependenciesRegistration
    {
        public static IServiceCollection AddMappers(this IServiceCollection
      services)
        {
            services
            .AddSingleton<IContactMapper, ContactMapper>()
            //.AddSingleton<IGenreMapper, GenreMapper>()
            //.AddSingleton<IBookMapper, BookMapper>()
            ;
            return services;
        }
        public static IServiceCollection AddServices(this
        IServiceCollection services)
        {
            services
            .AddScoped<IContactService, ContactService>()
            //.AddScoped<IBookService, BookService>()
            //.AddScoped<IGenreService, GenreService>()
            ;
            return services;
        }
        public static IMvcBuilder AddValidation(this IMvcBuilder builder)
        {
            builder
            .AddFluentValidation(configuration =>
            configuration.RegisterValidatorsFromAssembly
            (Assembly.GetExecutingAssembly()));
            return builder;
        }
    }
}
