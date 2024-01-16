using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZstdSharp.Unsafe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MatchCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/<MatchCommentController>/5
        [HttpGet("{matchId}")]
        public IActionResult Get(string matchId)
        {

            try
            {
                var commentObjs = _context.MatchComments.Where(c => c.MatchId == matchId);

                var comments = commentObjs.Select(c => new CommentDto
                {
                    Id = c.Id,
                    text = c.Text,
                    User = new UserComment
                    {
                        SteamAccountId = c.User.SteamAccountId,
                        Username = c.User.UserName
                    }
                }).ToList();
                return StatusCode(200, comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<MatchCommentController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Models.MatchComment comment)
        {
            string userId = User.FindFirstValue("id");
            try
            {
                if (string.IsNullOrEmpty(userId)) { return Unauthorized(); }
                comment.UserId = userId;

                _context.MatchComments.Add(comment);
                _context.SaveChanges();
                return StatusCode(201, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/<MatchCommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatchCommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string userId = User.FindFirstValue("id");
            try
            {
                MatchComment comment = _context.MatchComments.FirstOrDefault(c => c.Id == id);
                if(comment == null) { return NotFound(); }
                if(string.IsNullOrEmpty(userId)) { return Unauthorized(); }
                _context.MatchComments.Remove(comment);
                _context.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
