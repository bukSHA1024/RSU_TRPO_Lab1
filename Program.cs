using System;
using System.Collections;
using System.Linq;

namespace Lab1_mag
{
    class Program
    {
        static void Main(string[] args)
        {
            var vectorsArray = new TwoDimensionalVector[]
            {
                new(10.1, -5.3),
                new(1.1, 6.3),
                new (31, 5.4),
                new (-0, 0),
                new (109.1, -57.3)
            };

            PrintArray("Original array:", vectorsArray);

            Array.Sort(vectorsArray, (first, second) => first.CompareTo(second));
            PrintArray("Sorted array:", vectorsArray);

            var firstMoreThenSecondArray = vectorsArray.Where(item => item.FirstDimension > item.SecondDimension);
            PrintArray("Elements where first dimension is bigger then second:", firstMoreThenSecondArray);

            var bothNegativeArray = vectorsArray.Where(item => item.FirstDimension < 0 && item.SecondDimension < 0).ToArray();
            if (bothNegativeArray.Any())
                PrintArray("Array contains elements where are both dimensions is negative:", bothNegativeArray);
            else
                Console.WriteLine("There are no array elements where both dimensions are negative.");
        }

        private static void PrintArray<T>(string headerMessage, T array) where T : IEnumerable
        {
            Console.WriteLine(headerMessage);
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }

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
