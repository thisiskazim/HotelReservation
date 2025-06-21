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
        public PriceBreakdown priceBreakdown { get; set; }
        //public List<string> photoUrls { get; set; }
        public string checkoutDate { get; set; }
        public string checkinDate { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int reviewCount { get; set; }
        public string reviewScoreWord { get; set; }
        public Checkin checkin { get; set; }
        public Checkout checkout { get; set; }
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

    public class PriceBreakdown
    {
        public GrossPrice grossPrice { get; set; }
        public ExcludedPrice excludedPrice { get; set; }
        public StrikethroughPrice strikethroughPrice { get; set; }
        public List<BenefitBadge> benefitBadges { get; set; }
    }

    public class GrossPrice
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class ExcludedPrice
    {
        public double value { get; set; }
        public string currency { get; set; }
    }

    public class StrikethroughPrice
    {
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class BenefitBadge
    {
        public string explanation { get; set; }
        public string variant { get; set; }
        public string text { get; set; }
        public string identifier { get; set; }
    }

    public class Checkin
    {
        public string fromTime { get; set; }
        public string untilTime { get; set; }
    }

    public class Checkout
    {
        public string fromTime { get; set; }
        public string untilTime { get; set; }
    }
}
