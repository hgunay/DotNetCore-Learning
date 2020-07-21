using System;

namespace CustomerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Loop

            Console.WriteLine("Loop içinde Fibonacci...");
            Console.WriteLine("------------------------");

            int x = 0, y = 1, z = 0;

            Console.Write($"{x} {y}");

            int count = 10;
            for (int i = 2; i < count; i++)
            {
                z = x + y;
                Console.Write($" {z}");

                x = y;
                y = z;
            }

            #endregion

            Console.WriteLine("\r\n");

            #region Recursive

            Console.WriteLine("Recursive methot içinde Fibonacci...");
            Console.WriteLine("------------------------------------");
            FibonacciRecursiveCalc(0, 1, 1, 10);
            
            #endregion
            
            Console.WriteLine("\r\n");

            #region Reference Parameters

            Console.WriteLine("Recursive parameters...");
            Console.WriteLine("-----------------------");

            var value = 5;
            Console.WriteLine($"Orjinal Değer : {value}");

            SumValues(10, 15, ref value);
            Console.WriteLine($"Güncel Değer : {value}");

            #endregion

            Console.WriteLine("\r");

            #region Output Parameters

            Console.WriteLine("Output parameters...");
            Console.WriteLine("--------------------");
            
            int outputValue;
            var returnValue = SumAndReturnValues(15, 25, out outputValue);

            Console.WriteLine($"Dönüş Değeri : {returnValue}");
            Console.WriteLine($"Output Değeri : {outputValue}");

            #endregion
        }

        // Fibonacci dizisini oluşturacak methodumuz.
        private static void FibonacciRecursiveCalc(int x, int y, int count, int length)
        {
            if (count <= length)
            {
                Console.Write("{0} ", x);
                FibonacciRecursiveCalc(y, x + y, count + 1, length);
            }
        }

        private static void SumValues(int x, int y, ref int z)
        {
            z = x + y + z;
        }

        private static int SumAndReturnValues(int x, int y, out int z){
            z = 15;
            return x + y;
        }
    }
}