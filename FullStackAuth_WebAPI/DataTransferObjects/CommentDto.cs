namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? recupientUserId { get; set; }
        public string text { get; set; }
        public UserComment User { get; set; }
    }
}
