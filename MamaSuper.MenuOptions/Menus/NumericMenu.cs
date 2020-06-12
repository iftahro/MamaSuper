using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;

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
            string userInput = Console.ReadLine();
            Console.WriteLine();
            if (!int.TryParse(userInput, out int userChoice))
            {
                Console.WriteLine($"'{userInput}' is not a valid number!\nTry again..\n");
                return;
            }

            int maxOptions = _menuOptions.Count + 1;
            if (userChoice > maxOptions || userChoice <= 0)
            {
                Console.WriteLine($"{userChoice} is out of choice range!\nTry again..\n");
                return;
            }

            if (userChoice == maxOptions)
            {
                _running = false;
                return;
            }

            _menuOptions[userChoice - 1].Action();
        }
    }
}