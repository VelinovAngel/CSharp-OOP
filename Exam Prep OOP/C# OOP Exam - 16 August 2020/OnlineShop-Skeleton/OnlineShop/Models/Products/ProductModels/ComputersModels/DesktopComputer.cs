namespace OnlineShop.Models.Products.ProductModels.ComputersModels
{
    public class DesktopComputer : Computer
    {

        private const int NEW_OVERALL_VALUE = 10;

        public DesktopComputer(int id, string manufacturer, string model, decimal price)
            : base(id, manufacturer, model, price, NEW_OVERALL_VALUE)
        {
        }
    }
}
