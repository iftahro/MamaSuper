using System;

namespace MamaSuper.Logic.Utils
{
    public static class ConsoleUtils
    {
        public static string GetInputAfterOutput(string output)
        {
            Console.WriteLine(output);
            return Console.ReadLine();
        }
    }
}
