using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SteamAPIController : ControllerBase
    {
        private readonly SteamApiService _steamService;
        public SteamAPIController(SteamApiService steamService)
        {
            _steamService = steamService;
        }

        // GET api/<SteamAPIController>/5
        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccountInfo(string accountId)
        {
            AccountInfo accountInfo = await _steamService.GetSteamInfoAsync(accountId);
            if(accountInfo != null)
            {
                return Ok(accountInfo);
            }
            else
            {
                return StatusCode(500, "Steam API error");
            }
        }

    }
}
