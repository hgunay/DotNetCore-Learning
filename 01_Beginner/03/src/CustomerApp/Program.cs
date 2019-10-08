using System;
using System.Collections.Generic;

namespace CustomerApp
{
    class Program
    {
        static void Main()
        {
            // integer değerlerin toplamı
            // string interpolation ile sonuç yazdır.
            int x = 1;
            int y = 3;
            var intTotal = x + y;

            Console.WriteLine($"Integer Değerlerin Toplamı : {intTotal}");

            // double değerlerin toplamı
            double a = 15.3;
            double b = 23.8;
            var doubleTotal = a + b;
           
            Console.WriteLine($"Double Değerlerin Toplamı : {doubleTotal}");

            // bool değer kullanımı
            var isActive = false;

            Console.WriteLine($"Bool Değeri : {isActive}");

            // array kullanımı
            int[] intList = new int[5]{ 1, 2, 3, 4, 5 }; // Tek Boyutlu (Single Dimensional)

            Console.WriteLine($"Tek Boyutlu (Single Dimensional) Array Uzunluğu : {intList.Length}");

            int[,] multiList1 = new int[3, 2]{ 
                { 1, 2 }, 
                { 3, 4 }, 
                { 5, 6 } 
            }; // İki Boyutlu (Multi Dimensional)

            Console.WriteLine($"İki Boyutlu (Multi Dimensional) Array Uzunluğu : {multiList1.Length}");

            int[, ,] multiList2 = new int[2, 3, 3] { 
                { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, 
                { { 10, 11, 12 }, { 13, 14, 15 }, { 16, 17, 18 } } 
            }; // Üç Boyutlu (Multi Dimensional)

            Console.WriteLine($"Üç Boyutlu (Multi Dimensional) Array Uzunluğu : {multiList2.Length}");

            var newIntList = new int[3];
            newIntList[0] = 11;
            newIntList[1] = 22;
            newIntList[2] = 33;

            var newIntListTotal = newIntList[0];
            newIntListTotal += newIntList[1];
            newIntListTotal += newIntList[2];

            Console.WriteLine($"Integer Array Listesi Toplamı : {newIntListTotal}");

            var newIntTotal = 0;
            foreach(var item in newIntList){
                newIntTotal += item;
            }

            Console.WriteLine($"Integer Array Listesi Toplamı (foreach) : {newIntTotal}");

            // Generic List Kullanımı
            List<string> nameList = new List<string>();
            nameList.Add("Anakin");
            nameList.Add("Luke");            
            nameList.Add("Leia");

            var nameResult = string.Empty;
            foreach (var item in nameList)
            {
                nameResult += $"{item} ";
            }

            Console.WriteLine($"Generic List Kullanımı : {nameResult}");
        }
    }
}