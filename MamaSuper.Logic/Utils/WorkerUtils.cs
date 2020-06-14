using System;
using System.Collections.Generic;
using System.Text;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;

namespace MamaSuper.Logic.Utils
{
    public static class WorkerUtils
    {
        public static Worker ChooseWorker(List<Worker> workers)
        {
            Console.WriteLine("Workers:");
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {workers[i]}");
            }

            string userInput = ConsoleUtils.GetInputAfterOutput("Enter worker number:");
            if (!userInput.TryParseToInt(out int userChoice)) return null;

            if (userChoice < 1 || userChoice > workers.Count)
            {
                Console.WriteLine($"{userChoice} is Out of workers range!\nTry again..\n");
                return null;
            }

            return workers[userChoice - 1];
        }

        public static void PrintTraffic(Dictionary<Worker, DateTime?> traffic)
        {
            foreach ((Worker worker, DateTime? dateTime) in traffic)
            {
                if (dateTime == null)
                {
                    Console.WriteLine($"{worker}: None");
                    continue;
                }

                Console.WriteLine($"{worker}: {dateTime}");
            }
        }
    }
}
