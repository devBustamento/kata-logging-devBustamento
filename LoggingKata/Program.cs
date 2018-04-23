using System.Linq;
using System.IO;
using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();

        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            ITrackable a = null;
            ITrackable b = null;
            double distance = 0;

            foreach (var LocA in locations)
            {
                var origin = new GeoCoordinate
                {
                    Latitude = LocA.Location.Latitude,
                    Longitude = LocA.Location.Longitude
                };
                
                foreach (var LocB in locations)
                {
                    var destination = new GeoCoordinate
                    {
                         Latitude = LocB.Location.Latitude,
                        Longitude = LocB.Location.Longitude
                    };

                    double newDistance = origin.GetDistanceTo(destination);
                    if (newDistance > distance)
                    {
                        a = LocA;
                        b = LocB;
                        distance = newDistance;
                    }
                }
            }

            Console.WriteLine($"The two tacobells that are farthest apart are: {a.Name} and {b.Name}");
            Console.WriteLine($"These two locations are {distance} meters apart");
            Console.ReadLine();
        }
    }
}