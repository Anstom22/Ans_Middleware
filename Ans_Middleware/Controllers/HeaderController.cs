using Ans_Middleware.Models;
using Ans_Middleware.Repositories;
using Ans_Middleware.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ans_Middleware.Controllers
{
    public class HeaderController : Controller
    {
        private readonly HeaderService headerService;

        //private readonly IHeaderRepository headerRepository;
        //private readonly CurrentHeader currentHeader;

        //public HeaderController(IHeaderRepository headerRepository,CurrentHeader currentHeader)
        //{
        //    this.headerRepository = headerRepository;
        //    this.currentHeader = currentHeader;
        //}

        public HeaderController(HeaderService headerService)
        {
            this.headerService = headerService;
        }
        //[HttpGet("headers/all)")]
        //public async Task<IActionResult> GetAllheaders()
        //{
        //    var headers = await headerRepository.GetHeadersAsync();
        //    return Ok(headers);
        //}

        //[HttpGet("headers/current)")]

        //public IActionResult GetCurrentHeader()
        //{
        //    var header = currentHeader.GetHeaders();
        //    if (header == null)
        //    {
        //        return NotFound("No Headers Found");
        //    }
        //    return Ok(header);
        //}

        [HttpGet("current")]
        public ActionResult<Header> GetHeaders()
        {
            
            var headers = headerService.GetHeaders();
            Console.WriteLine($"Controller Returning Headers: RequestId={headers.RequestId}, Authorization={headers.Authorization}, UserAgent={headers.UserAgent}, Host={headers.Host}, CorrelationId={headers.CorrelationId}");
            return Ok(headers);
        }

        
    }
}
