using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullStackAuth_WebAPI.Models
{
    public class AccountComment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        [ForeignKey("PostingUser")]
        public string PostingUserId { get; set; }
        public User PostingUser { get; set; }
        public string RecipientUserId { get; set; }
    }
}
