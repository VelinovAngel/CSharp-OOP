using System;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private const string MSG_EXC_INV_COORDINATE = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                Validation(value, nameof(Length));

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException(String.Format(MSG_EXC_INV_COORDINATE, nameof(Width)));
                //}

                Validation(value, nameof(Width));

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException(String.Format(MSG_EXC_INV_COORDINATE, nameof(Height)));
                //}

                Validation(value, nameof(Height));

                this.height = value;
            }
        }

        private void Validation(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(MSG_EXC_INV_COORDINATE, paramName));
            }
        }


        public double SurfaceArea()
            => (2 * this.Length * this.Width) +
            LateralSurfaceArea();

        public double LateralSurfaceArea()
            => (2 * this.Length * this.Height)+
            (2 * this.Width * this.Height);

        public double Volume()
            => this.Length * this.Height * this.Width;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().TrimEnd();

        }


    }
}
