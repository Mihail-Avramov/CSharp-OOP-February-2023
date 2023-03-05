using System;

namespace ClassBoxData.Models
{
    public class Box
    {
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
            get => length;
            private init
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
                length  = value;
            }
		}
		public double Width
		{
			get => width;
            private init
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException($"{nameof(Width)} cannot be zero or negative.");
                }
                width = value;
            }
		}
		public double Height
		{
			get => height;
            private init
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
                height = value;
            }
		}

        public double SurfaceArea() => 2 * (Length * Width + Length * Height + Width * Height);

        public double LateralSurfaceArea() => 2 * (Length * Height + Width * Height);

        public double Volume() => Length * Width * Height;

    }
}
