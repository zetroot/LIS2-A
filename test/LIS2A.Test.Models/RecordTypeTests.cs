using LIS2A.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace LIS2A.Test.Models
{
    public class RecordTypeTests
    {
        [Fact]
        public void Parse_OnEmptySpan_ThrowsArgumentException()
        {
            //arrange
            var emptyArr = new char[0];

            // act & assert
            Assert.Throws<ArgumentException>(() => RecordType.Parse(emptyArr.AsSpan()));
        }

        public static IEnumerable<object[]> ParseData => new List<object[]>
        {
            new object[] {'H', RecordType.MessageHeader },
            new object[] {'P', RecordType.PatientIdentifying },
            new object[] {'O', RecordType.TestOrder },
            new object[] {'R', RecordType.Result },
            new object[] {'C', RecordType.Comment },
            new object[] {'Q', RecordType.RequestInformation },
            new object[] {'S', RecordType.Scientific },
            new object[] {'M', RecordType.ManufacturerInformation },
            new object[] {'h', RecordType.MessageHeader },
            new object[] {'p', RecordType.PatientIdentifying },
            new object[] {'o', RecordType.TestOrder },
            new object[] {'r', RecordType.Result },
            new object[] {'c', RecordType.Comment },
            new object[] {'q', RecordType.RequestInformation },
            new object[] {'s', RecordType.Scientific },
            new object[] {'m', RecordType.ManufacturerInformation },
        };

        [Theory]
        [MemberData(nameof(ParseData))]
        public void Parse_WhenCalled_ParsesData(char input, RecordType expected)
        {
            //act
            var actual = RecordType.Parse(input);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
