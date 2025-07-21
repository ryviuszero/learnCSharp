using System;

namespace DataApplication
{
    class Program
    {
        public void Run(string[] args)
        {
            Console.WriteLine("Size of int: {0}", sizeof(int));

            byte b = 10;
            int i = b; // 隐式转换， 不需要显示转换

            int intValue = 100;
            long longValue = intValue; // 隐式转换， 不需要显示转换

            int intValue2 = 10;
            long longValue2 = intValue2;

            int intValue3 = 100;
            float floatValue = (float)intValue3; // 显式转换， 需要显示转换

            int intValue4 = 100;
            string stringValue = intValue4.ToString();

            string str = "123";
            int number = Convert.ToInt32(str); 

        }
    }
}