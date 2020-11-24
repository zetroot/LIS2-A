using LIS2A.Models;
using System.Collections.Generic;
using Xunit;

namespace LIS2A.Test.Models
{
    public class ProcessingTypeTests
    {
        public static IEnumerable<object[]> ParseData => new List<object[]>
        {
            new object[] { 'P', ProcessingType.Production },
            new object[] { 'T', ProcessingType.Training },
            new object[] { 'D', ProcessingType.Debugging },
            new object[] { 'Q', ProcessingType.QualityControl },
        };

        [Theory]
        [MemberData(nameof(ParseData))]
        public void Parse_WhenCalled_ParsesData(char input, ProcessingType expected)
        {
            //act
            var actual = ProcessingType.Parse(input);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
