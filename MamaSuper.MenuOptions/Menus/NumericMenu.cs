using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.Menus
{
    /// <summary>
    /// This <inheritdoc cref="IMenuOption"/> is a menu, making it possible for nested menus
    /// This menu displays options by ascending numbers
    /// </summary>
    public class NumericMenu : IMenuOption
    {
        private bool _running;
        private readonly IList<IMenuOption> _menuOptions;

        public NumericMenu(string description, IList<IMenuOption> menuOptions)
        {
            Description = description;
            _menuOptions = menuOptions;
        }

        public string Description { get; }

        public void Action()
        {
            _running = true;
            while (_running)
            {
                displayMenuOptions();
                handleUserInput();
            }
        }

        /// <summary>
        /// Displays the menu options by ascending numbers
        /// </summary>
        private void displayMenuOptions()
        {
            Console.WriteLine(Description);
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuOptions[i].Description}");
            }

            Console.WriteLine($"{_menuOptions.Count + 1}. Exit");
        }

        /// <summary>
        /// Handles the user input to activate the chosen action
        /// </summary>
        private void handleUserInput()
        {
            string userInput = ConsoleUtils.GetInputAfterOutput("Enter your choice:");
            Console.Clear();

            int maxOptions = _menuOptions.Count + 1;
            if (!MenuUtils.ValidateNumericMenuChoice(userInput, maxOptions, out int userChoice)) return;

            // Checks if the user choice is the last menu option (the exit option)
            if (userChoice == maxOptions)
            {
                _running = false;
                return;
            }

            // Preforms the action of the chosen menu option
            _menuOptions[userChoice - 1].Action();
        }
    }
}