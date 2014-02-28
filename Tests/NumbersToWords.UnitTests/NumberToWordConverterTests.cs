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
        public void SutReturnsWordForTwoDigitNumbers(int number, string word)
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
