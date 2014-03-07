using System;
using System.Collections;
using System.Collections.Generic;
using NumberToWords.Domain;
using Xunit;
using Xunit.Extensions;

namespace NumbersToWords.UnitTests
{
    public class NumberToWordConverterTests
    {
        [Theory]
        [PropertyData("UniqueWordData")]
        public void SutReturnsWordForUniqueNumbers(int number, string word)
        {
                var harryandhissillyname = new NumberToWordConverter();
                var actual = harryandhissillyname.Convert(number);

                Assert.Equal(word, actual);
        }

        [Theory]
        [InlineData(21, "twenty one")]
        [InlineData(22, "twenty two")]
        [InlineData(31, "thirty one")]
        [InlineData(43, "fourty three")]
        [InlineData(56, "fifty six")]
        [InlineData(78, "seventy eight")]
        [InlineData(83, "eighty three")]
        [InlineData(91, "ninety one")]
        public void SutReturnsWordForTwoDigitNumbers(int number, string word)
        {
            var sut = new NumberToWordConverter();
            var actual = sut.Convert(number);
            Assert.Equal(word, actual);
        }

        [Theory]
        [InlineData(100, "one hundred")]
        [InlineData(108, "one hundred and eight")]
        [InlineData(200, "two hundred")]
        [InlineData(250, "two hundred and fifty")]
        [InlineData(299, "two hundred and ninety nine")]
        ///TODO: REFACTOR
        public void SutReturnsWordForThreeDigitNumbers(int number, string word)
        {
            var sut = new NumberToWordConverter();
            var actual = sut.Convert(number);
            Assert.Equal(word, actual);
        }

        public static IEnumerable<object[]> UniqueWordData
        {
            get
            {
                return new[]
                {
                    new object[] {1, "one"},
                    new object[] {2, "two"},
                    new object[] {3, "three"},
                    new object[] {4, "four"},
                    new object[] {5, "five"},
                    new object[] {6, "six"},
                    new object[] {7, "seven"},
                    new object[] {8, "eight"},
                    new object[] {9, "nine"},
                    new object[] {10, "ten"},
                    new object[] {11, "eleven"},
                    new object[] {12, "twelve"},
                    new object[] {13, "thirteen"},
                    new object[] {14, "fourteen"},
                    new object[] {15, "fifteen"},
                    new object[] {16, "sixteen"},
                    new object[] {17, "seventeen"},
                    new object[] {18, "eighteen"},
                    new object[] {19, "nineteen"},
                    new object[] {20, "twenty"}
                };
            }
        }
    }
}
