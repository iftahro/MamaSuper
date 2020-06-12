using System.Collections.Generic;

namespace MamaSuper.Common.Interfaces
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
        /// <param name="failingMessage">Failing message if the adding action failed</param>
        /// <returns>Is the adding action was successful</returns>
        bool TryAddItem(T item, out string failingMessage);

        /// <summary>
        /// Moves out items from line
        /// </summary>
        /// <param name="count">The number of items to move out</param>
        /// <returns>The items that where moved out</returns>
        IEnumerable<T> MoveOutItems(int count);

        /// <summary>
        /// Gets all line items
        /// </summary>
        IEnumerable<T> GetLineItems();

        /// <summary>
        /// Counts the line items
        /// </summary>
        int CountLineItems();
    }
}
