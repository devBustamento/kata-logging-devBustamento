using System.Linq;
using System.IO;
using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog Logger = new TacoLogger();

        const string CsvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            Logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(CsvPath);

            Logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            ITrackable a = null;
            ITrackable b = null;
            double distance = 0;

            foreach (var locA in locations)
            {
                var origin = new GeoCoordinate( locA.Location.Latitude, locA.Location.Longitude );

                foreach (var locB in locations)
                {
                    var destination = new GeoCoordinate( locB.Location.Latitude, locB.Location.Longitude );

                    double newDistance = origin.GetDistanceTo(destination);
                    if (!(newDistance > distance)) { continue; }
                    a = locA;
                    b = locB;
                    distance = newDistance;
                }
            }

            Console.WriteLine($"The two tacobells that are farthest apart are:\n\t{a?.Name} and \n\t{b?.Name}");
            Console.WriteLine($"These two locations are {distance/3.28} feet apart");
            Console.ReadLine();
        }
    }
}