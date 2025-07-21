using System;
using System.Linq;

namespace RectangleApplication
{
    class Rectangle
    {
        double length;
        double width;

        public void Acceptdetail()
        {
            length = 4.5;
            width = 3.5;
        }

        public double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }

    class ExecuteRectangle
    {
        public static void Run(string[] args)
        {
            //变量声明
            int number = 42;
            string message = "The answer to life, the universe, and everything is";

            // 输出变量
            Console.WriteLine($"{message} {number}");

            // 定义和调用方法
            int Add(int a, int b) => a + b;
            Console.WriteLine($"Sum of 1 and 2 is {Add(1, 2)}.");

            // 使用 LINQ
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var evens = numbers.Where(n => n % 2 == 0).ToArray();
            Console.WriteLine("Even numbers: " + string.Join(", ", evens));


            try
            {
                int zero = 0;
                int result = number / zero;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Rectangle rect = new Rectangle();
            rect.Acceptdetail();
            rect.Display();
        }
    }
}