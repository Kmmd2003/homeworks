using System;

namespace Project1
{
    class App
    {
        static void Main()
        {
            Console.WriteLine("adad 1 ");
            string num1= Console.ReadLine();
            Console.WriteLine("adad 2 ");
            string num2= Console.ReadLine();
            int num1n = Convert.ToInt32(num1);
            int num2n = Convert.ToInt32(num2);
            Console.WriteLine("Jam " + num2n+ num1n);
        }
    }
}