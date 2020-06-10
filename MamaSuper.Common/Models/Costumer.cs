namespace MamaSuper.Common.Models
{
    public class Costumer : Person
    {
        public Costumer(string name, int bodyTemperature, bool hasMask, bool shouldIsolate) : base(name,
            bodyTemperature, hasMask, shouldIsolate)
        {
        }
    }
}