using System;

namespace App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter num 1 : ");
            int num1 = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            Console.WriteLine("Enter num 2 : ");
            int num2 = Math.Abs(Convert.ToInt32(Console.ReadLine()));

            int resGCD = calcGCD(num1, num2);   // ب.م.م
            int resLCM = calcLCM(num1, num2);   // ک.م.م
            Console.WriteLine("Result gcd is " + resGCD + ", result lcm is : " + resLCM);
        }

        static private int calcGCD(int num1, int num2)
        {
            int a = num1;   
            int b = num2;   
            int gcd = 1;

            if (num1 < num2)
            {
                a = num2;
                b = num1;
            }

            while (b != 0)
            {
                if (num1 % b == 0 && num2 % b == 0)
                {
                    gcd = b;
                    break;
                }
                --b;
            }
            return gcd;
        }

        static private int calcLCM(int num1, int num2)
        {
            return Math.Abs(num1 * num2) / calcGCD(num1, num2);
        }
    }
}
