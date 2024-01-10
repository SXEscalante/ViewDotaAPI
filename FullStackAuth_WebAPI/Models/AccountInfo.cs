namespace FullStackAuth_WebAPI.Models
{

    public class AccountInfo
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public int status { get; set; }
        public int num_results { get; set; }
        public int total_results { get; set; }
        public int results_remaining { get; set; }
        public Match[] matches { get; set; }
    }

    public class Match
    {
        public long match_id { get; set; }
        public long match_seq_num { get; set; }
        public int start_time { get; set; }
        public int lobby_type { get; set; }
        public int radiant_team_id { get; set; }
        public int dire_team_id { get; set; }
        public Player[] players { get; set; }
    }

    public class Player
    {
        public long account_id { get; set; }
        public int player_slot { get; set; }
        public int team_number { get; set; }
        public int team_slot { get; set; }
        public int hero_id { get; set; }
    }

}
