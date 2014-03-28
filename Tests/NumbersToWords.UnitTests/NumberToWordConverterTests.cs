using System.Collections.Generic;
using NumberToWords.Domain;
using Xunit;
using Xunit.Extensions;

namespace NumbersToWords.UnitTests
{
    public class NumberToWordConverterTests
    {
        private readonly NumberToWordConverter sut;

        public NumberToWordConverterTests()
        {
            sut = new NumberToWordConverter();
        }

        [Theory]
        [PropertyData("UniqueWordData")]
        public void SutReturnsWordForUniqueNumbers(int number, string word)
        {
            var actual = sut.Convert(number);
            Assert.Equal(word, actual);
        }

        [Theory]
        [InlineData(21, "twenty one")]
        [InlineData(22, "twenty two")]
        [InlineData(31, "thirty one")]
        [InlineData(43, "forty three")]
        [InlineData(56, "fifty six")]
        [InlineData(78, "seventy eight")]
        [InlineData(83, "eighty three")]
        [InlineData(91, "ninety one")]
        public void SutReturnsWordForTwoDigitNumbers(int number, string word)
        {
            var actual = sut.Convert(number);
            Assert.Equal(word, actual);
        }

        [Theory]
        [InlineData(100, "one hundred")]
        [InlineData(108, "one hundred and eight")]
        [InlineData(200, "two hundred")]
        [InlineData(250, "two hundred and fifty")]
        [InlineData(299, "two hundred and ninety nine")]
        [InlineData(310, "three hundred and ten")]
        public void SutReturnsWordForThreeDigitNumbers(int number, string word)
        {
            var actual = sut.Convert(number);
            Assert.Equal(word, actual);
        }

        [Theory]
        [InlineData(1001, "one thousand and one")]
        [InlineData(2045, "two thousand and forty five")]
        //[InlineData(1013, "one thousand and thirteen")]
        //[InlineData(1103, "one thousand one hundred and three")]
        public void SutReturnsWordForFourDigitNumbers(int number, string word)
        {
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
