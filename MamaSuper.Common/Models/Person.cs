namespace MamaSuper.Common.Models
{
    /// <summary>
    /// A person in the world
    /// </summary>
    public class Person
    {
        public Person(string name, int bodyTemperature, bool hasMask, bool shouldIsolate)
        {
            Name = name;
            BodyTemperature = bodyTemperature;
            HasMask = hasMask;
            ShouldIsolate = shouldIsolate;
        }

        /// <summary>
        /// The person's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The person's body temperature in c° degree 
        /// </summary>
        public int BodyTemperature { get; set; }

        /// <summary>
        /// Is the person wear mask
        /// </summary>
        public bool HasMask { get; set; }

        /// <summary>
        /// Is the person should be isolated duo to coronavirus
        /// </summary>
        public bool ShouldIsolate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}