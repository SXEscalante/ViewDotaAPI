using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using FullStackAuth_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("account/{steamAccountId}")]
        public async Task<IActionResult> GetAccountInfo(string steamAccountId)
        {
            AccountInfo accountInfo = await _steamService.GetSteamInfoAsync(steamAccountId);
            if(accountInfo != null)
            {
                return Ok(accountInfo);
            }
            else
            {
                return StatusCode(500, "Steam API error");
            }
        }

        [HttpGet("match/{matchId}")]
        public async Task<IActionResult> GetMatchDetails(string matchId)
        {
            MatchDetails matchDetails = await _steamService.GetMatchDetailsAsync(matchId);
            if (matchDetails != null)
            {
                return Ok(matchDetails);
            }
            else
            {
                return StatusCode(500, "Steam API error");
            }
        }

        [HttpGet("friendsList/{steamId}")]
        public async Task<IActionResult> GetFriendsList(string steamId)
        {
            List<FriendDetailsDTO> friendsList = new List<FriendDetailsDTO>();
            AccountFriendsList accountFriendsList = await _steamService.GetFriendsListAsync(steamId);
            if (accountFriendsList != null)
            {
                foreach(var friend in accountFriendsList.friendslist.friends)
                {
                    FriendSummary friendSummary = await _steamService.GetFriendsSummaryAsync(friend.steamid);
                    if (friendSummary != null)
                    {
                        FriendDetailsDTO friendDetails = new FriendDetailsDTO
                        {
                            personaname = friendSummary.response.players[0].personaname,
                            steamid = friendSummary.response.players[0].steamid
                        };

                        friendsList.Add(friendDetails);
                    }
                    else
                    {
                        return StatusCode(500, "Steam API error");
                    }
                }
                return Ok(friendsList);
            }
            else
            {
                return StatusCode(500, "Steam API error");
            }
        }
    }
}
