namespace MamaSuper.Common.Models
{
    public class Customer : Person
    {
        public Customer(string name, int bodyTemperature, bool hasMask, bool shouldIsolate, int money) : base(name,
            bodyTemperature, hasMask, shouldIsolate)
        {
            Money = money;
        }

        /// <summary>
        /// The customer money amount
        /// </summary>
        public int Money { get; set; }
    }
}