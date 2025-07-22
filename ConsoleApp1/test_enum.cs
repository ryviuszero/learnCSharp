using System;

namespace EnumApplication
{
    public enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat }

    public class TestEnum
    {
        public static void Run(string[] args)
        {
            int x = (int)Day.Sun; // 将枚举值转换为整数
            int y = (int)Day.Fri; // 将枚举值转换为整数
            Console.WriteLine("Sun is {0}, Fri is {1}", x, y);
        }
    }
}