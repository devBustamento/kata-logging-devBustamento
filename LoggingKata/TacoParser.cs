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
            if (cells.Length < 3) { logger.LogError("Well, the string was the wrong size after being .Split"); return null; }
            
            double lon;
            double lat;
            var name = cells[2];
            try
            {
                lon = double.Parse(cells[0]);
                lat = double.Parse(cells[1]);
                if (Math.Abs(lat) > Point.MaxLat || Math.Abs(lon) > Point.MaxLon) { logger.LogWarning("Latitude/Longitude out of range"); return null; }
            }
            catch (Exception e)
            {
                logger.LogError("Something messed up with the parsing process, man. You got crazy numbers");
                
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