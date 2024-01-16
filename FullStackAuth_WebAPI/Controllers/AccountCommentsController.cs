using FullStackAuth_WebAPI.Data;
using FullStackAuth_WebAPI.DataTransferObjects;
using FullStackAuth_WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FullStackAuth_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AccountCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{steamAccountId}")]
        public IActionResult Get(string steamAccountId)
        {
            try
            {
                var commentObjs = _context.AccountComments.Where((c) => c.RecipientUserId.Equals(steamAccountId));

                var comments = commentObjs.Select(c => new CommentDto 
                {
                    Id = c.Id,
                    recupientUserId = c.RecipientUserId,
                    text = c.Text,
                    User = new UserComment
                    {
                        SteamAccountId = c.PostingUser.SteamAccountId,
                        Username = c.PostingUser.UserName
                    }
                }).ToList();
                return StatusCode(200, comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<AccountCommentController>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Models.AccountComment comment)
        {
            string userId = User.FindFirstValue("id");
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized();
                }
                comment.PostingUserId = userId;


                _context.AccountComments.Add(comment);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.SaveChanges();
                return StatusCode(201, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<AccountCommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountCommentController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            string userId = User.FindFirstValue("id");
            try
            {
                AccountComment comment = _context.AccountComments.FirstOrDefault(c => c.Id == id);
                if(comment == null) { return NotFound(); }
                if(string.IsNullOrEmpty(userId)) { return Unauthorized(); }
                _context.AccountComments.Remove(comment);
                _context.SaveChanges();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
