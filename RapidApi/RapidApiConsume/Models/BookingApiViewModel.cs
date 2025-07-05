using System.Collections.Generic;

namespace RapidApiConsume.Models
{
    public class BookingApiViewModel
        {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public BookingData data { get; set; }
    }

    public class BookingData
    {
        public List<Hotel> hotels { get; set; }
    }

    public class Hotel
    {
        public string hotel_id { get; set; }
        public string accessibilityLabel { get; set; }
        public Property property { get; set; }
        public string checkoutDate { get; set; }
        public string checkinDate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int reviewCount { get; set; }
        public string reviewScoreWord { get; set; }
   
    }

    public class Property
    {
        public int propertyClass { get; set; }
        public int accuratePropertyClass { get; set; }
        public double reviewScore { get; set; }
        public string name { get; set; }
        public List<string > photoUrls { get; set; }
        public bool isPreferred { get; set; }
    }

   
}
