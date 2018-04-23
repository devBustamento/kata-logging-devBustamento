namespace LoggingKata
{
    public struct Point //Point because of a point on earth
    {
        public static readonly double MaxLon = 180;
        public static readonly double MaxLat = 90; //This is to define my acceptable range of Lat & Lon
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}