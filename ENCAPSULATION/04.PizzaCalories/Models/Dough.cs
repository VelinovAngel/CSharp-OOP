using System;

using _04.PizzaCalories.ExeptionMSG;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BankingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                ValidationTypeFlour(value);

                this.flourType = value;
            }
        }

        public string BankingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                ValidationTypeBaking(value);

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalExeptions.OutSideRange);
                }

                this.weight = value;
            }
        }

        private void ValidationTypeFlour(string typeFlour)
        {
            string type = typeFlour.ToLower();
            if (type != "white" && type != "wholegrain")
            {
                throw new ArgumentException(GlobalExeptions.InvTypeDough);
            }
        }

        private void ValidationTypeBaking(string baking)
        {
            string type = baking.ToLower();
            if (type != "crispy" && type != "chewy" && type != "homemade")
            {
                throw new ArgumentException(GlobalExeptions.InvTypeDough);
            }
        }

        private double FlourModifier()
        {
            string type = this.FlourType.ToLower();
            if (type == "white")
            {
                return 1.5;
            }

            return 1.0;
        }

        private double BakingTecModifier()
        {
            string technic = this.BankingTechnique.ToLower();
            if (technic == "crispy")
            {
                return 0.9;
            }
            else if (technic == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1.0;
            }

        }

        public double DoughCalories()
        {
            //weighting 100 grams will have (2 * 100) * 1.5 * 1.1 = 330.00

            return (2 * this.Weight) * FlourModifier() * BakingTecModifier();
        }
    }
}
