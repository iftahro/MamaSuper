﻿namespace MamaSuper.Common.Models
{
    /// <summary>
    /// A worker in the supermarket
    /// </summary>
    public class Worker : Person
    {
        public Worker(string name, int bodyTemperature = 37, bool hasMask = true, bool shouldIsolate = false) :
            base(name, bodyTemperature, hasMask, shouldIsolate)
        {
        }

        /// <summary>
        /// The worker's financial fine 
        /// </summary>
        public int Fine { get; set; } = 0;
    }
}