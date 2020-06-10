﻿using System.Collections.Generic;

namespace MamaSuper.Common.Models
{
    /// <summary>
    /// Generic queue-based super line 
    /// </summary>
    public class Line<T>
    {
        private readonly Queue<T> _queue;

        public Line(Queue<T> queue = null)
        {
            _queue = queue ?? new Queue<T>();
        }

        /// <summary>
        /// Adds item T to the line tail
        /// </summary>
        public void AddToLine(T item)
        {
            _queue.Enqueue(item);
        }

        /// <summary>
        /// Removes item T from the line head
        /// </summary>
        public T RemoveFromLine()
        {
            return _queue.Dequeue();
        }

        /// <summary>
        /// Returns all the line items
        /// </summary>
        public IEnumerable<T> GetQueueItems()
        {
            foreach (T item in _queue)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Counts the items in the line
        /// </summary>
        public int CountLine()
        {
            return _queue.Count;
        }
    }
}