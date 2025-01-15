using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Text2Int
{
    /// <summary>
    /// This converts text to numbers up to a trillion
    /// </summary>
    public class Mechanism
    {
        private Dictionary<string, int> digitpairDict = new Dictionary<string, int>()
        {
            {"ZERO"  ,  0}, {"ONE"   ,  1}, {"TWO"     ,  2}, {"THREE"   ,  3}, {"FOUR"   ,  4}, {"FIVE"   ,  5}, {"SIX"      ,  6}, {"SEVEN"   ,  7}, {"EIGHT"   , 8}, {"NINE", 9}, {"TEN", 10},
            {"ELEVEN", 11}, {"TWELVE", 12}, {"THIRTEEN", 13}, {"FOURTEEN", 14}, {"FIFTEEN", 15}, {"SIXTEEN", 16}, {"SEVENTEEN", 17}, {"EIGHTEEN", 18}, {"NINETEEN", 19},
            {"TWENTY", 20}, {"THIRTY", 30}, {"FORTY"   , 40}, {"FIFTY"   , 50}, {"SIXTY"  , 60}, {"SEVENTY", 70}, {"EIGHTY"   , 80}, {"NINETY"  , 90}
        };

        private string[] parseValue;

        /// <param name="value">this parameter passes the string of text that you need to convert.</param>
        public Mechanism(string value) => parseValue = value.ToUpper().Split();
        /// <summary>
        /// This is the main method that converts text to number
        /// </summary>
        /// <returns>It returns a long number as int can't hold up to trillion</returns>
        /// <exception cref="Exception">Checks if the spelling is correct</exception>
        public long Process()
        {
            List<long> values = new List<long>();
            for (int i = 0; i < parseValue.Length; ++i)  //counts the words in the string array
            {
                if (digitpairDict.ContainsKey(parseValue[i])) //checks if the text is found in the dictionary then if its found add it in the list
                {
                        values.Add(digitpairDict[parseValue[i]]);
                }
                else // if the text is not in the dictionary, it will then look at this. If it found one, it will multiply the multiplier to the element of the list before it.
                {
                        if (parseValue[i] == "HUNDRED"     && i > 0) values[values.Count - 1] *= 100;
                        if (parseValue[i] == "THOUSAND"    && i > 0) values[values.Count - 1] *= 1_000;
                        if (parseValue[i] == "MILLION"     && i > 0) values[values.Count - 1] *= 1_000_000;
                        if (parseValue[i] == "BILLION"     && i > 0) values[values.Count - 1] *= 1_000_000_000;
                        if (parseValue[i] == "TRILLION"    && i > 0) values[values.Count - 1] *= 1_000_000_000_000;
                        if (parseValue[i] == "QUADRILLION" && i > 0) values[values.Count - 1] *= 1_000_000_000_000_000;
                        if (parseValue[i] == "QUINTILLION" && i > 0) values[values.Count - 1] *= 1_000_000_000_000_000_000; 
                }
            }
               return values.Sum(); //sums all the values in the list.
        }
    }
}