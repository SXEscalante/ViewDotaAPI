using FullStackAuth_WebAPI.Data;
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

        // GET: api/<AccountCommentController>/myAccountsComments
        [HttpGet("myAccountsComments"), Authorize]
        public IActionResult Get()
        {
            try
            {
                string userId = User.FindFirstValue("id");
                var comments = _context.AccountComments.Where((c) => c.RecipientUserId.Equals(userId));
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
                comment.RecipientUserId = userId;

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
