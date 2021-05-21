
using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration (this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "29dc09aaa3af48b8abf3c60b6b9a5fe8";
                o.LogId = new Guid("8503488d-348f-4ba7-b0cf-359220f600cd");
            });

            services.AddLogging(builder =>
            {
                builder.AddElmahIo(o =>
                {
                    o.ApiKey = "29dc09aaa3af48b8abf3c60b6b9a5fe8";
                    o.LogId = new Guid("8503488d-348f-4ba7-b0cf-359220f600cd");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null,LogLevel.Warning);
            });

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration (this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
