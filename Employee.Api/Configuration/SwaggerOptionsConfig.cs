using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace EmployeeManagement.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerDefaultValues>();
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach(var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
            return app;
        }
    }

    public class SwaggerOptionsConfig : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider _provider;
        public SwaggerOptionsConfig(IApiVersionDescriptionProvider provider) => this._provider = provider;
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            };
        }

        static OpenApiInfo CreateInfoForApiVersion (ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "EmployeeManagement.Api",
                Version = description.ApiVersion.ToString(),
                Description = "Essa Api é responsável pela inserção, obtençao e remocão de funcionários",
                Contact = new OpenApiContact() { Name= "Danilo Gutierrez Figueiredo", Email="danilogfigueiredo@gmail.com"},
                TermsOfService= new Uri ("https://opensource.org/licenses/MIT"),
                License = new OpenApiLicense() { Name="MIT", Url= new Uri("https://opensource.org/licenses/MIT") }
            };

            if(description.IsDeprecated)
            {
                info.Description += "Está versão não está mais em uso";
            }

            return info;
        }
    }
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            operation.Deprecated = apiDescription.IsDeprecated();

            if (operation.Parameters == null)
            {
                return;
            }

            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                if (parameter.Description == null)
                {
                    parameter.Description = description.ModelMetadata?.Description;
                }

                parameter.Required |= description.IsRequired;
            }
        }
    }
}
