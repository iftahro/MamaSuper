using System;
using MamaSuper.Logic.ExtensionMethods;

namespace MamaSuper.Logic.Utils
{
    public static class MenuUtils
    {
        /// <summary>
        /// Validates a user menu choice
        /// </summary>
        /// <param name="userInput">The user menu choice</param>
        /// <param name="maxOptions">The choice range</param>
        /// <param name="choice">The choice if valid</param>
        /// <returns>Is the choice valid</returns>
        public static bool ValidateNumericMenuChoice(string userInput, int maxOptions, out int choice)
        {
            // Checks if the user input numeric
            if (!userInput.TryParseToInt(out choice)) return false;

            // Checks if the user choice in range
            if (choice < 1 || choice > maxOptions)
            {
                Console.WriteLine($"{choice} is out of choice range!\nTry again..\n");
                return false;
            }

            return true;
        }
    }
}
