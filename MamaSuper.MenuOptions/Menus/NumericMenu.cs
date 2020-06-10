using System;
using System.Collections.Generic;
using MamaSuper.Logic.Interfaces;

namespace MamaSuper.MenuOptions.Menus
{
    /// <summary>
    /// This <inheritdoc cref="IMenuOption"/> is a menu, making it possible for nested menus
    /// This menu displays options by ascending numbers
    /// </summary>
    public class NumericMenu : IMenuOption
    {
        public string Description { get; }
        private readonly IList<IMenuOption> _menuOptions;
        private bool _running;

        public NumericMenu(string description, IList<IMenuOption> menuOptions)
        {
            Description = description;
            _menuOptions = menuOptions;
        }

        public void Action()
        {
            _running = true;
            while (_running)
            {
                _displayMenuOptions();
                _handleUserInput();
            }
        }

        /// <summary>
        /// Displays the menu options by ascending numbers
        /// </summary>
        private void _displayMenuOptions()
        {
            for (int i = 0; i < _menuOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_menuOptions[i].Description}");
            }

            Console.WriteLine($"{_menuOptions.Count + 1}. Exit");
        }

        /// <summary>
        /// Handles the user input to activate the chosen action
        /// </summary>
        private void _handleUserInput()
        {
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out int userChoice))
            {
                Console.WriteLine($"'{userInput}' is not a valid number!\nTry again..\n");
                return;
            }

            int maxOptions = _menuOptions.Count + 1;
            if (userChoice > maxOptions)
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