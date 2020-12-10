namespace OnlineShop.Models.Products.ProductModels.ComputersModels
{
    public class Laptop : Computer
    {
        private const int NEW_OVERALL_VALUE = 10;

        public Laptop(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, NEW_OVERALL_VALUE)
        {
        }
    }
}
