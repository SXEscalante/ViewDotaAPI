namespace FullStackAuth_WebAPI.Models
{
    public class AccountFriendsList
    {
        public Friendslist friendslist { get; set; }
    }

    public class Friendslist
    {
        public Friend[] friends { get; set; }
    }

    public class Friend
    {
        public string steamid { get; set; }
        public string relationship { get; set; }
        public int friend_since { get; set; }
    }


}
