using System;

namespace App
{
    class Project
    {
        static void Main()
        {
            int[,] arr = new int[3, 3];
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Enter ["+ i+ "]["+ j+ "]: ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Enter duplicate number : ");
            num2 = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[j, i] == num2)
                        ++num;
                }
            }

            Console.WriteLine("Duplicate count for "+ num2+ "is : "+ num);
        }

    }
}