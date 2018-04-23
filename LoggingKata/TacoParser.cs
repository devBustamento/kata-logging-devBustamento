using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("IM WORKING GIVE ME A MINUTE");

            if (string.IsNullOrEmpty(line)) { logger.LogFatal("Yo, this line is empty"); return null; }

            var cells = line.Split(',');//.Split returns an array 
            if (cells.Length < 2) { logger.LogError("Well, the string was the wrong size after being .Split"); return null; }

            try
            {
                var lon = double.Parse(cells[0]);
                double lat = double.Parse(cells[1]);
                if (Math.Abs(lat) > Point.MaxLat || Math.Abs(lon) > Point.MaxLon)
                {
                    logger.LogWarning("Latitude/Longitude out of range");
                    return null;
                }

                var name = cells.Length > 2 ? cells[2] : null;
                return new TacoBell
                {//This TacoBells location and name is .....
                    Location = new Point { Longitude = lon, Latitude = lat },
                    Name = name
                };
            }
            catch (Exception e)
            {
                logger.LogError("Something messed up with the parsing process, man. You got crazy numbers");
                Console.WriteLine(e);
                Console.ReadKey();
                return null;
            }
        }
    }
}