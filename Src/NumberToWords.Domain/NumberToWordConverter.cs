using System.Collections.Generic;

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
            {100, "one hundred"},
            {200, "two hundred"},
            {250, "two hundred and fifty"},
            {299, "two hundred and ninety nine"},

        };

        public string Convert(int number)
        {
            if (numberword.ContainsKey(number))
            {
                return numberword[number];
            }
            else 
            {
                var units = number%10;
                var tens = number - units;
                if (tens < 100)
                {
                    return string.Format("{0} {1}", numberword[tens], numberword[units]);
                }
                else
                {
                    return string.Format("{0} and {1}", numberword[tens], numberword[units]);
                }
            }
        }
    }
    
}
