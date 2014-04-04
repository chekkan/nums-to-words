using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToWords.Domain
{
    public class NumberToWordConverter
    {
// ReSharper disable once InconsistentNaming
        private readonly Dictionary<int, string> numberWang = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
            {20, "twenty"},
            {30, "thirty"},
            {40, "forty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"},
            {100, "hundred"}
        };

        public string Convert(int number)
        {
            var stringBuilder = new StringBuilder();
            var numberAsString = number.ToString();
            var size = numberAsString.Length;

            if (size <= 2 && numberWang.ContainsKey(number))
            {
                return numberWang[number];
            }

            string tens = numberAsString[size - 2].ToString();
            string hundreds = "0";
            string thousands = "0";
            string unit = numberAsString.Last().ToString();
            string tenThousands = "0";

            if (size >= 3)
            {
                var hundredIndex = size - 3;
                hundreds = numberAsString[hundredIndex].ToString();
            }
            if (size >= 4)
            {
                var thousandIndex = size - 4;
                thousands = numberAsString[thousandIndex].ToString();
            }
            if (size >= 5)
            {
                var tenThousandIndex = size - 5;
                tenThousands = numberAsString[tenThousandIndex].ToString();
            }

            if (tenThousands != "0")
                stringBuilder.Append(ConvertTwoDigits(tenThousands + thousands) + " thousand");

            if (thousands != "0" && tenThousands == "0")
                stringBuilder.Append(numberWang[int.Parse(thousands)] + " thousand");

            if (hundreds != "0")
            {
                if (size >= 4) stringBuilder.Append(" ");
                stringBuilder.Append(numberWang[int.Parse(hundreds)] + " hundred");
            }

            if (IsAndRequired(numberAsString))
                stringBuilder.Append(" and ");

            stringBuilder.Append(ConvertTwoDigits(tens + unit));

            return stringBuilder.ToString();
        }

        public bool IsAndRequired(string number)
        {
            if (number.Length == 3 && !number.Contains("00"))
                return true;

            if (number.Length > 4 && !number.EndsWith("00"))
                return true;

            return number.Contains("0") && number.Last() != '0' 
                   && number.Length != 3;
        }

        public string ConvertTwoDigits(string twoDigitNumberAsString)
        {
            if (numberWang.ContainsKey(int.Parse(twoDigitNumberAsString)))
                return numberWang[int.Parse(twoDigitNumberAsString)];

            var tens = twoDigitNumberAsString.First().ToString();
            var unit = twoDigitNumberAsString.Last().ToString();

            if (tens != "0")
                return (numberWang[int.Parse(tens + "0")] + " " + numberWang[int.Parse(unit)]);

            return "";
        }

        public enum Order
        {
            Thousand, 
            Hundred,
            Ten
        }
    }

}
