using Ans_Middleware.Models;
using Ans_Middleware.Repositories;
using Ans_Middleware.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ans_Middleware.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly CurrentHeader currentHeader;

        public HeaderMiddleware(RequestDelegate requestDelegate, IServiceScopeFactory serviceScopeFactory, CurrentHeader currentHeader)
        {
            this.requestDelegate = requestDelegate;
            this.serviceScopeFactory = serviceScopeFactory;
            this.currentHeader = currentHeader;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var headerRepository = scope.ServiceProvider.GetRequiredService<IHeaderRepository>();

                
                var headers = new Header
                {
                    RequestId = context.Request.Headers["X-Request-ID"],
                    Authorization = context.Request.Headers.Authorization,
                    CorrelationId = context.Request.Headers["X-Correlation-Id"],
                    UserAgent = context.Request.Headers.UserAgent,
                    Host = context.Request.Headers.Host
                };
                await headerRepository.SaveHeadersAsync(headers);
                currentHeader.SetHeaders(headers);
            }


            

            await requestDelegate(context);


        }   
    }
}
