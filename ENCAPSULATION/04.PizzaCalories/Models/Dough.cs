using System;

using _04.PizzaCalories.ExeptionMSG;

namespace _04.PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique , double weight)
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
                ValidationType(value);

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
                ValidationType(value);

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalExeptions.OutSideRange);
                }

                this.weight = value;
            }
        }

        private void ValidationType(string type)
        {

            if (type != "White" &&  type != "Wholegrain")
            {
                throw new ArgumentException(GlobalExeptions.InvTypeDough);
            }
            else if (type != "Crispy" && type != "Chewy" && type != "Homemade")
            {
                throw new ArgumentException(GlobalExeptions.InvTypeDough);
            }
        }

        private double FlourModifire()
        {
            if (this.FlourType == "White")
            {
                return 1.5;
            }

            return 1.0;
        }


    }
}
