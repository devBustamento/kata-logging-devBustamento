using System;
using Xunit;
using LoggingKata;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
       

        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham/....")]
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
        public void ShouldFailParse(string line)
        {
            //Arrange -
            var parser = new TacoParser();
            ITrackable expected = null;
            //Act
            var actual = parser.Parse(line);
            //Assert
            Assert.Equal(actual, expected);
        }
    }
}
