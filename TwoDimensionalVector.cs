using System;

namespace Lab1_mag
{
    class TwoDimensionalVector
    {
        public double FirstDimension { get; private set; }

        public double SecondDimension { get; private set; }

        public double Length { get; private set; }

        public TwoDimensionalVector(double firstDimension, double secondDimension)
        {
            FirstDimension = firstDimension;
            SecondDimension = secondDimension;
            Length = Math.Sqrt(Math.Pow(FirstDimension, 2.0) + Math.Pow(SecondDimension, 2.0));
        }

        public int CompareTo(TwoDimensionalVector other)
        {
            var diff = Length - other.Length;
            return diff switch
            {
                > 0 => 1,
                0 => 0,
                _ => -1
            };
        }

        public override string ToString()
        {
            return $"({FirstDimension}, {SecondDimension})";
        }
    }
}