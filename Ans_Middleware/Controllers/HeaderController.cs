using Ans_Middleware.Models;
using Ans_Middleware.Repositories;
using Ans_Middleware.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ans_Middleware.Controllers
{
    public class HeaderController : Controller
    {
        private readonly IHeaderRepository headerRepository;
        private readonly CurrentHeader currentHeader;

        public HeaderController(IHeaderRepository headerRepository,CurrentHeader currentHeader)
        {
            this.headerRepository = headerRepository;
            this.currentHeader = currentHeader;
        }
        [HttpGet("headers/all)")]
        public async Task<IActionResult> GetAllheaders()
        {
            var headers = await headerRepository.GetHeadersAsync();
            return Ok(headers);
        }

        [HttpGet("headers/current)")]

        public IActionResult GetCurrentHeader()
        {
            var header = currentHeader.GetHeaders();
            if (header == null)
            {
                return NotFound("No Headers Found");
            }
            return Ok(header);
        }
    }
}
