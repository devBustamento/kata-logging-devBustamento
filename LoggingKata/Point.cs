using System.ComponentModel.DataAnnotations;

namespace LoggingKata
{
    public struct Point //Point because of a point on earth
    {
        public static readonly double MaxLon = 180;
        public static readonly double MaxLat = 85.05112878; //This is to define my acceptable range of Lat & Lon
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}