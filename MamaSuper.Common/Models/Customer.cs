namespace MamaSuper.Common.Models
{
    public class Customer : Person
    {
        public Customer(string name, int bodyTemperature, bool hasMask, bool shouldIsolate) : base(name,
            bodyTemperature, hasMask, shouldIsolate)
        {
        }
    }
}