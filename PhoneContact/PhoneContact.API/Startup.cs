using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using EventBus.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using PhoneContact.API.Extensions;
using PhoneContact.Domain.Repositories;
using PhoneContact.EFRepository.Extensions;
using PhoneContact.EFRepository.Repositories;
using PhoneContact.Services.Extensions;
using PhoneContact.EFRepository;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace PhoneContact.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }


        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                 .AddControllers()
                 .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddPhoneContactContext(Configuration.GetSection("DataSource:ConnectionString").Value)
            .AddScoped<IContactRepository, ContactRepository>()
            //.AddScoped<IAuthorRepository, AuthorRepository>()
            //.AddScoped<IGenreRepository, GenreRepository>()
            .AddIntegrationServices(Configuration)
            .AddEventBus(Configuration)
            .AddEventBusCustom(Configuration)
            .AddMappers()
            .AddServices()
            .AddControllers()
            .AddValidation();
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddPhoneContactContext(Configuration.GetSection("DataSource:ConnectionString").Value)
           .AddScoped<IContactRepository, ContactRepository>()
            //.AddScoped<IAuthorRepository, AuthorRepository>()
            //.AddScoped<IGenreRepository, GenreRepository>()
           .AddIntegrationServices(Configuration)
           .AddEventBus(Configuration)
           .AddEventBusCustom(Configuration)
           .AddMappers()
           .AddServices()
           .AddControllers()
           .AddValidation();

            builder.Populate(serviceCollection);
            // var serviceProvider = new AutofacServiceProvider(builder.Build());

            // Register your own things directly with Autofac, like:
            //   builder.RegisterModule(new MyApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ExecuteMigrations(app, env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ExecuteMigrations(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "Testing") return;

            var retry = Policy.Handle<SqlException>()
                .WaitAndRetry(new TimeSpan[]
                {
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(6),
                    TimeSpan.FromSeconds(12)
                });

            retry.Execute(() =>
                app.ApplicationServices.GetService<PhoneContactContext>().Database.Migrate());
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //  eventBus.Subscribe<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
            // eventBus.Subscribe<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();
        }
    }
}
