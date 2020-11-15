namespace _04.WildFarm.Models.Animals
{
    public abstract class Memmal : Animal
    {
        protected Memmal(string name, double weight , string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion; 
        }

        public string LivingRegion { get;}

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
