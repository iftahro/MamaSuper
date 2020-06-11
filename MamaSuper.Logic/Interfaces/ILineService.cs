﻿using System.Collections.Generic;

namespace MamaSuper.Logic.Interfaces
{
    /// <summary>
    /// Generic line service for comfortable line management
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILineService<T>
    {
        /// <summary>
        /// Tries adding an item to the line
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <param name="failingMessage">The outcome message (failed/succeeded)</param>
        /// <returns>Is the adding was successful</returns>
        bool TryAddItemToLine(T item, out string failingMessage);

        /// <summary>
        /// Gets all line items
        /// </summary>
        IList<T> GetLineItems();

        /// <summary>
        /// Moves out items from line
        /// </summary>
        /// <param name="count">The number of items to move out</param>
        /// <returns>The items that where moved out</returns>
        IEnumerable<T> MoveItemsFromLine(int count);
    }
}
