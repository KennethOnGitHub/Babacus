using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Babacus
{
    public static class Sanitiser
    {

        public static string Sanitise(string uncleanedString)
        {

            string sanitisedString = "";

            foreach (char c in uncleanedString)
            {
                if (c == ' ') continue;

                if (charIsValid(c))
                {
                    sanitisedString += c;
                }else
                {
                    throw new Exception(string.Format("{0} is not a valid character", c));
                }
            }

            return sanitisedString;
        }

        static bool charIsValid(char c)
        {
            char[] validChars =
            {
                '&',
                '|',
                '(',
                ')',
                '¬',
                '1',
                '0',
            };

            return char.IsLetter(c) || Array.IndexOf(validChars, c) >= 0;

        }
    }
}
