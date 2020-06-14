namespace MamaSuper.Common.Models
{
    /// <summary>
    /// A worker in the supermarket
    /// </summary>
    public class Worker : Person
    {
        public Worker(string name, int bodyTemperature, bool hasMask, bool shouldIsolate) :
            base(name, bodyTemperature, hasMask, shouldIsolate)
        {
        }
    }
}
