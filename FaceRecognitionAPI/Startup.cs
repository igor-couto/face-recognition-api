using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using FaceRecognitionApplication.Domain.Model.Recognizers;
using FaceRecognitionApplication.Domain.Model.Classifiers;
using FluentValidation;
using MediatR;

namespace FaceRecognitionAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddSwagger(services);
            services.AddSingleton<IRecognizer, Eigen>();
            services.AddSingleton<IClassifier, HaasCascade>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "FaceRecognition API",
                    Description = "ASP.NET Core Web API to provide functionality to Face Recognition Aplication",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "FaceRecognition",
                        Email = "igor.fcouto@gmail.com.br"
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        private static void AddMediatr(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("AccuScheduler.Application");

            // Validators.
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            // Behaviors
            var behaviorType = typeof(IPipelineBehavior<,>);
            var behaviors = assembly.DefinedTypes.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == behaviorType));
            foreach (var type in behaviors)
                services.Add(new ServiceDescriptor(behaviorType, type, ServiceLifetime.Scoped));

            services.AddMediatR(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Face Recognition API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
