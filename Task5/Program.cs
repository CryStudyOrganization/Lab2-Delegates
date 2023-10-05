using System;
using System.Collections.Generic;

namespace Task5
{
    class Class1
    {
        public static double Method1(double x)
        {
            return x * x;
        }

        public double Method2(double y)
        {
            if (y > 0)
                return 13 / y;
            else
                return 0;
        }
    }

    class Class2
    {
        public static double Method2(double x)
        {
            return Math.Pow(x, 3);
        }
    }

    class Program
    {
        static void Main()
        {
            List<Func<double, double>> delegates = new()
            {
                Class1.Method1, new Class1().Method2, Class2.Method2
            };

            double inputValue = 5.0;

            foreach (var func in delegates)
            {
                double result = func(inputValue);
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}
