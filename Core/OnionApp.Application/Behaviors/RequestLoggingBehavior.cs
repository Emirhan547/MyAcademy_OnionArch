using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Behaviors
{
    public sealed class RequestLoggingBehavior<TRequest, TResponse>(ILogger<RequestLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var domainArea = ResolveDomainArea(requestName);

            using var scope = logger.BeginScope(new Dictionary<string, object>
            {
                ["RequestName"] = requestName,
                ["DomainArea"] = domainArea
            });

            logger.LogInformation("Application request started for {RequestName} in {DomainArea} area", requestName, domainArea);

            try
            {
                var response = await next();
                logger.LogInformation("Application request completed for {RequestName}", requestName);
                return response;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Application request failed for {RequestName}", requestName);
                throw;
            }
        }

        private static string ResolveDomainArea(string requestName)
        {
            if (requestName.Contains("Reservation", StringComparison.OrdinalIgnoreCase)) return "Reservation";
            if (requestName.Contains("AppUser", StringComparison.OrdinalIgnoreCase) || requestName.Contains("User", StringComparison.OrdinalIgnoreCase)) return "User";
            if (requestName.Contains("Auth", StringComparison.OrdinalIgnoreCase) || requestName.Contains("Token", StringComparison.OrdinalIgnoreCase)) return "Authentication";
            if (requestName.Contains("Car", StringComparison.OrdinalIgnoreCase) || requestName.Contains("Rent", StringComparison.OrdinalIgnoreCase)) return "Fleet";
            if (requestName.Contains("Review", StringComparison.OrdinalIgnoreCase) || requestName.Contains("Comment", StringComparison.OrdinalIgnoreCase)) return "Engagement";

            return "General";
        }
    }
}