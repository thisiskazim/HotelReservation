namespace HotelProjectWebUI.Dtos.FollowersDto
{
    public class ResultInstagramFollowersDto
    {


        public Data data { get; set; }


        public class Data
        {
            public int follow_friction_type { get; set; }
            public int follower_count { get; set; }
            public int following_count { get; set; }
        }
    }
}