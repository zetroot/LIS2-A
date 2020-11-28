using LIS2A.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LIS2A.Test.Models
{
    public class HeaderTests
    {
        private readonly string minimalInput = @"H|\^&";
        private readonly string validHeader = @"H|\^&|MessageControlID|AccessPassword|SenderID|SenderStreetAddress|Reserved0|SenderTelephoneNumber|SenderCharacteristiucs|ReceiverID|Comment|P|VersionNUmber|19700101010203";

        [Fact]
        public void Parse_WhenCalledOn4CharString_Throws()
        {
            //arrange 
            var brokenInput = @"H|\^";

            //act & assert
            Assert.Throws<ArgumentException>(() => HeaderRecord.Parse(brokenInput.AsSpan()));
        }

        [Fact]
        public void Parse_WhenFirstCharIsNotH_Throws()
        {
            //arrange 
            var brokenInput = @"a|\^&";

            //act & assert
            Assert.Throws<ArgumentException>(() => HeaderRecord.Parse(brokenInput.AsSpan()));
        }

        [Fact]
        public void Parse_WhenInputIsEmpty_Throws()
        {
            //arrange 
            var brokenInput = string.Empty;

            //act & assert
            Assert.Throws<ArgumentException>(() => HeaderRecord.Parse(brokenInput.AsSpan()));
        }

        [Fact]
        public void Parse_WhenCalled_ParsesFieldDelimiter()
        {            
            //act
            var parsed = HeaderRecord.Parse(minimalInput);

            // assert
            Assert.Equal('|', parsed.Delimiters.FieldDelimiter);
        }

        [Fact]
        public void Parse_WhenCalled_ParsesRepeatDelimiter()
        {
            //act
            var parsed = HeaderRecord.Parse(minimalInput);

            // assert
            Assert.Equal('\\', parsed.Delimiters.RepeatDelimiter);
        }

        [Fact]
        public void Parse_WhenCalled_ParsesComponentDelimiter()
        {
            //act
            var parsed = HeaderRecord.Parse(minimalInput);

            // assert
            Assert.Equal('^', parsed.Delimiters.ComponentDelimiter);
        }

        [Fact]
        public void Parse_WhenCalled_ParsesEscapeCharacter()
        {
            //act
            var parsed = HeaderRecord.Parse(minimalInput);

            // assert
            Assert.Equal('&', parsed.Delimiters.EscapeCharacter);
        }

        [Fact]
        public void Parse_WhenCalled_ParsesFileds()
        {
            // arrange
            var input = @"H|\^&|MessageControlID|AccessPassword|SenderID|SenderStreetAddress|Reserved0|SenderTelephoneNumber|SenderCharacteristiucs|ReceiverID|Comment|P|VersionNUmber|19700101010203";

            //act
            var actual = HeaderRecord.Parse(input);

            // assert
            Assert.Equal("MessageControlID", actual.MessageControlID);
            Assert.Equal("AccessPassword", actual.AccessPassword);
            Assert.Equal("SenderID", actual.SenderID);
            Assert.Equal("SenderStreetAddress", actual.SenderStreetAddress);
            Assert.Equal("Reserved0", actual.Reserved0);
            Assert.Equal("SenderTelephoneNumber", actual.SenderTelephoneNumber);
            Assert.Equal("SenderCharacteristiucs", actual.SenderCharacteristics);
            Assert.Equal("ReceiverID", actual.ReceiverID);
            Assert.Equal("Comment", actual.Comment);
            Assert.Equal(ProcessingType.Production, actual.ProcessingID);
            Assert.Equal("VersionNUmber", actual.VersionNumber);
            Assert.NotNull(actual.MessageDateTime);
            Assert.Equal(new DateTime(1970, 01, 01, 01, 02, 03), actual.MessageDateTime.Value.DateTime);
        }
    }
}
