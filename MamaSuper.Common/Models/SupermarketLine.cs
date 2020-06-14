using System.Collections.Generic;

namespace MamaSuper.Common.Models
{
    /// <summary>
    /// Generic queue-based supermarket line 
    /// </summary>
    public class SupermarketLine<T>
    {
        private readonly Queue<T> _queue;

        public SupermarketLine(Queue<T> queue = null)
        {
            _queue = queue ?? new Queue<T>();
        }

        /// <summary>
        /// Adds item T to the line tail
        /// </summary>
        public void AddLineItem(T item)
        {
            _queue.Enqueue(item);
        }

        /// <summary>
        /// Removes item T from the line head
        /// </summary>
        public T RemoveLineItem()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Returns all the line items
        /// </summary>
        public IEnumerable<T> GetLineItems()
        {
            foreach (T item in _queue)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Counts the items in the line
        /// </summary>
        public int CountLineItems()
        {
            return _queue.Count;
        }
    }
}