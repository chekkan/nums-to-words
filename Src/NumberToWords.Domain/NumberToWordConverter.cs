using System.Collections.Generic;

namespace NumberToWords.Domain
{
    public class NumberToWordConverter
    {
        public Dictionary<int, string> numberword = new Dictionary<int, string>()
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
            {20, "twenty"}
    };
 
        public string Convert(int number)
        {
            return numberword[number];
        }
    }
    
}
