using System;

namespace MamaSuper.Common.Utils
{
    /// <summary>
    /// Console utils
    /// </summary>
    public static class ConsoleUtils
    {
        /// <summary>
        /// Gets user input based on a specific output
        /// </summary>
        public static string GetInputByOutput(string output)
        {
            Console.WriteLine(output);
            return Console.ReadLine();
        }
    }
}