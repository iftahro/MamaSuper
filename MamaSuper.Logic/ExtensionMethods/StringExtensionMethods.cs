using System;

namespace MamaSuper.Logic.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Tries parsing a string into an integer
        /// </summary>
        /// <param name="input">The string to be parsed</param>
        /// <param name="result">The int object if succeeded</param>
        /// <returns>Is the string numeric</returns>
        public static bool TryParseToInt(this string input, out int result)
        {
            bool isNumeric = int.TryParse(input, out result);
            if (!isNumeric) Console.WriteLine($"'{input}' is not a valid number!\nTry again..\n");

            return isNumeric;
        }

        /// <summary>
        /// Tries parsing a string into a boolean
        /// </summary>
        /// <param name="input">The string to be parsed</param>
        /// <param name="result">The bool object if succeeded</param>
        /// <returns>Is the string boolean</returns>
        public static bool TryParseToBool(this string input, out bool result)
        {
            bool isBoolean = bool.TryParse(input, out result);
            if (!isBoolean) Console.WriteLine($"'{input}' is not a true/false answer!\nTry again..\n");

            return isBoolean;
        }
    }
}