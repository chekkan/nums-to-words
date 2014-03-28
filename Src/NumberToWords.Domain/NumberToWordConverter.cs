using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToWords.Domain
{
    public class NumberToWordConverter
    {
        private readonly Dictionary<int, string> numberword = new Dictionary<int, string>()
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

            if (size <= 2 && numberword.ContainsKey(number))
            {
                return numberword[number];
            }

            string tens = numberAsString[size - 2].ToString();
            string hundreds = "0";
            string thousands = "0";
            string unit = numberAsString.Last().ToString();

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

            if (thousands != "0")
                stringBuilder.Append(numberword[ConvertToInt(thousands)] + " thousand");

            AndRequired(numberAsString, Order.Thousand, stringBuilder);

            //if (thousands != "0" && (hundreds != "0" || tens != "0" || unit != "0"))
            //    stringBuilder.Append(" and ");

            if (hundreds != "0")
                stringBuilder.Append(numberword[ConvertToInt(hundreds)] + " hundred");

            AndRequired(numberAsString, Order.Hundred, stringBuilder);

            //if (hundreds != "0" && (tens != "0" || unit != "0"))
            //   stringBuilder.Append(" and ");

            if (tens != "0")
                stringBuilder.Append(numberword[ConvertToInt(tens + "0")]);

            if (tens != "0" && unit != "0")
                stringBuilder.Append(" ");

            if(unit != "0")
                stringBuilder.Append(numberword[ConvertToInt(unit)]);

            return stringBuilder.ToString();
        }

        public void AndRequired(string number, Order order, StringBuilder sb)
        {
            if (order == Order.Hundred && number.Length == 3 && !number.Contains("00"))
            {
                sb.Append(" and ");
            }

            if (number.Contains("0") && number.Last() != '0')
            {
                if (order == Order.Thousand && number.Length != 3)
                    sb.Append(" and ");
            }
        }

        public int ConvertToInt(string number)
        {
            return Int32.Parse(number);
        }

        public enum Order
        {
            Thousand, 
            Hundred,
            Ten
        }
    }

}
