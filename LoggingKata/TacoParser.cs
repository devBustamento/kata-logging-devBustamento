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
            logger.LogInfo("Begin parsing");

            if (string.IsNullOrEmpty(line)) { logger.LogError("Yo, this line is empty"); return null; }

            var cells = line.Split(',');//.Split returns an array 
            if (cells.Length < 3) { logger.LogError("Well, the string was the wrong size after being .Split"); return null; }
            
            var lon = double.Parse(cells[0]);
            var lat = double.Parse(cells[1]);
            var name = cells[2];
            try
            {
                if (lat > Point.MaxLat || lat < -Point.MaxLat) { logger.LogWarning("Latitude out of range"); return null; }
                if (lon > Point.MaxLon || lon < -Point.MaxLon) { logger.LogWarning("Longitude out of range"); return null;  }
            }
            catch (Exception e)
            {
                logger.LogError("Something messed up with the parsing process, man. You got crazy numbers");
                Console.WriteLine(e);
                return null;
            }

            return new TacoBell
            {//This TacoBells location and name is .....
                Location = new Point {Longitude = lon, Latitude = lat},
                Name = name
            };//why does this need a semi-colon?? 
        }
    }
}