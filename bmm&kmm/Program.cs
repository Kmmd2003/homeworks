using System;

namespace App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number 1 : ");
            int number1 = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Enter number 2 : ");
            int number2 = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            int resGCD = calcGCD(number1, number2);   // ب.م.م
            int resLCM = calcLCM(number1, number2);   // ک.م.م
            Console.WriteLine("Result gcd is " + resGCD + ", result lcm is : " + resLCM);
        }

        static private int calcGCD(int number1, int number2)
        {
            int a = number1;   
            int b = number2;   
            int gcd = 1;

            if (number1 < number2)
            {
                a = number2;
                b = number1;
            }

            while (b != 0)
            {
                if (number1 % b == 0 && number2 % b == 0)
                {
                    gcd = b;
                    break;
                }
                --b;
            }
            return gcd;
        }

        static private int calcLCM(int number1, int number2)
        {
            return Math.Abs(number1 * number2) / calcGCD(number1, number2);
        }
    }
}