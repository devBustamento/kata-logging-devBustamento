using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham")]
        [InlineData("-86.889051, 33.556383")]
        public void ShouldParse(string line)
        {
            //Arrange
            var parser = new TacoParser();
            //Act
            var result = parser.Parse(line);
            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234, 1234")] // Cannot parse arrays of length < 3.
        [InlineData("1234, 1234, Location, Other")] // Cannot parse arrays of Length > 3.
        [InlineData("ABCD, 1234, Location")] // Longitude must have numeric entry.  
        [InlineData("1234, ABCD, Location")] // Latitude must have numeric entry.
        [InlineData("-190.05, 85.50, Location")] // Longitude out of range.
        [InlineData("170.02, 100.20, Location")] // Latitude out of range.
        public void ShouldFailParse(string line)
        {
            //Arrange 
            var parser = new TacoParser();
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Null(actual);
        }
    }
}