using System;

namespace Project1
{
    class App
    {
        static void Main()
        {
            int[,] array = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }

                int j = (array[0, 0] * ((array[1, 1] * array[2, 2]) - (array[1, 2] * array[2, 1])))- (array[0, 1] * ((array[1, 0] * array[2, 2]) - (array[1, 2] * array[2, 0])))+ (array[0, 2] * ((array[1, 0] * array[2, 1]) - (array[1, 1] * array[2, 0])));
                Console.WriteLine("matrix : " + j);
            }
        }

    }
}