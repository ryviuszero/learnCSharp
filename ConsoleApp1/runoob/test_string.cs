using System;

namespace StringApplication
{
    class StringProgram
    {
        public static void Run(string[] args)
        {
            string fname, lname;
            fname = "Rowan";
            lname = "Atkinson";

            // 字符串连接
            string fullname = fname + " " + lname;
            Console.WriteLine("Full Name: {0}", fullname);

            //通过使用 string 构造函数
            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            string greetings = new string(letters);
            Console.WriteLine("Message: {0}", greetings);

            // 方法返回字符串
            string[] sarray = { "hello", "From", "Totorials", "Point" };
            string message = String.Join(" ", sarray);
            Console.WriteLine("Message: {0}", message);

            // 用于转化值的格式化方法
            DateTime waiting = new DateTime(2023, 10, 1);
            string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
            Console.WriteLine("Message: {0}", chat);
        }
    }
}