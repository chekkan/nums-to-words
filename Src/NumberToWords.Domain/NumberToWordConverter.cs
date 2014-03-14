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
            {40, "fourty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"},
            {100, "hundred"}
        };

        public string Convert(int number)
        {
            var strNumber = number.ToString();
            var size = strNumber.Length;

            if (size <= 2 && numberword.ContainsKey(number))
            {
                return numberword[number];
            }

            string tens = strNumber[size - 2].ToString();
            string hundreds = "0";
            string unit = strNumber.Last().ToString();

            if (size >= 3)
            {
                hundreds = strNumber[size - 3].ToString();
            }

            var stringBuilder = new StringBuilder();

            if (hundreds != "0")
                stringBuilder.Append(numberword[Int32.Parse(hundreds)] + " hundred");

            if (hundreds != "0" && (tens != "0" || unit != "0"))
                stringBuilder.Append(" and ");

            if (tens != "0")
                stringBuilder.Append(numberword[Int32.Parse(tens + "0")]);

            if (tens != "0" && unit != "0")
                stringBuilder.Append(" ");

            if(unit != "0")
                stringBuilder.Append(numberword[Int32.Parse(unit)]);

            return stringBuilder.ToString();
        }
    }
    
}
