using System;
using System.IO;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Common.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Adds new costumers to the super line 
    /// </summary>
    public class CostumerAdder : IMenuOption
    {
        public string Description { get; }

        private readonly Line<Costumer> _costumersLine;

        public CostumerAdder(string description, Line<Costumer> costumersLine)
        {
            Description = description;
            _costumersLine = costumersLine;
        }

        public void Action()
        {
            try
            {
                string costumerName = ConsoleUtils.GetInputByOutput("Enter costumer name:");

                string bodyTemp = ConsoleUtils.GetInputByOutput($"Enter {costumerName}'s body temp (c° degree):");
                _checkBodyTemp(bodyTemp, out int bodyTemperature);

                string maskAnswer = ConsoleUtils.GetInputByOutput($"Does {costumerName} wear mask? (yes/no)");
                bool maskOn = _handleYesNoQuestions(maskAnswer);
                if (!maskOn)
                    throw new ArgumentException("We are not allowed to host maskless costumers!");

                string isolateAnswer =
                    ConsoleUtils.GetInputByOutput($"Does {costumerName} should be isolated? (yes/no)");
                bool shouldBeIsolated = _handleYesNoQuestions(isolateAnswer);
                if (shouldBeIsolated)
                    throw new ArgumentException("We are not allowed to host isolated costumers!");

                var costumer = new Costumer(costumerName, bodyTemperature, maskOn, shouldBeIsolated);
                _costumersLine.AddToLine(costumer);
                Console.WriteLine($"Added costumer {costumer.Name} to the line!\n");
            }

            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            catch (InvalidDataException)
            {
                Console.WriteLine("Try again..\n");
            }
        }

        private void _checkBodyTemp(string bodyTemp, out int bodyTemperature)
        {
            if (!int.TryParse(bodyTemp, out bodyTemperature))
            {
                Console.WriteLine($"'{bodyTemp}' is not a valid number!");
                throw new InvalidDataException();
            }

            if (bodyTemperature > 38)
            {
                throw new ArgumentException($"{bodyTemperature} is way too hot (try 38 or under)");
            }
        }

        private bool _handleYesNoQuestions(string answer)
        {
            answer = answer.ToLower();
            if (answer != "yes" && answer != "no")
            {
                Console.WriteLine($"'{answer}' is not a yes/no answer!");
                throw new InvalidDataException();
            }

            return answer == "yes";
        }
    }
}