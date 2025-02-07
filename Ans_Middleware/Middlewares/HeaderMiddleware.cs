using Ans_Middleware.Models;
using Ans_Middleware.Repositories;
using Ans_Middleware.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ans_Middleware.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        

        //private readonly RequestDelegate requestDelegate;
        //private readonly IServiceScopeFactory serviceScopeFactory;
        //private readonly CurrentHeader currentHeader;

        //public HeaderMiddleware(RequestDelegate requestDelegate, IServiceScopeFactory serviceScopeFactory, CurrentHeader currentHeader)
        //{
        //    this.requestDelegate = requestDelegate;
        //    this.serviceScopeFactory = serviceScopeFactory;
        //    this.currentHeader = currentHeader;
        //}

        public HeaderMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
            
        }

        public async Task InvokeAsync(HttpContext context, HeaderService headerService)
        {

            //using (var scope = serviceScopeFactory.CreateScope())
            //{
                //    var headerRepository = scope.ServiceProvider.GetRequiredService<IHeaderRepository>();
                //var headers = new Header
                //{
                //    RequestId = context.Request.Headers["X-Request-ID"],
                //    Authorization = context.Request.Headers.Authorization,
                //    CorrelationId = context.Request.Headers["X-Correlation-Id"],
                //    UserAgent = context.Request.Headers.UserAgent,
                //    Host = context.Request.Headers.Host
                //};
                //await headerRepository.SaveHeadersAsync(headers);
                //currentHeader.SetHeaders(headers);
                //}
                
                var headers = new Header
                {
                    RequestId = context.Request.Headers["X-Request-ID"],
                    Authorization = context.Request.Headers.Authorization,
                    CorrelationId = context.Request.Headers["X-Correlation-Id"],
                    UserAgent = context.Request.Headers.UserAgent,
                    Host = context.Request.Headers.Host
                };
                Console.WriteLine($"Extracted Headers: RequestId={headers.RequestId}, Authorization={headers.Authorization}, UserAgent={headers.UserAgent}, Host={headers.Host}, CorrelationId={headers.CorrelationId}");
                headerService.SetHeaders(headers);
            
            await requestDelegate(context);


        }   
    }
}
