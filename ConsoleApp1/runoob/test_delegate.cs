using System;


// 委托就是一个定义函数类型的引用。
delegate int NumberChange(int n);
public delegate void GreetingDelegate(string name);
namespace DelegateAppl
{
    class DelegateClass1
    {
        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Good Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }

        private static void GreetingPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }

        public static void Run(string[] args)
        {
            GreetingPeople("MyWind", EnglishGreeting);
            GreetingPeople("李雷", ChineseGreeting);

            // 可以将多个方法赋给同一个委托, 委托的多播？
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeting;
            delegate1 = delegate1 + ChineseGreeting;
            // 也可以使用 += 来添加方法
            GreetingPeople("MyWind", delegate1);
            // -= 可以用来从委托中移除方法
            delegate1 -= ChineseGreeting;
            GreetingPeople("MyWind", delegate1);
        }
        
    }
    

    class TestDelegate
    {
        static int num = 5;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }

        public static void Run(string[] args)
        {
            NumberChange nc;
            NumberChange nc1 = new NumberChange(AddNum);
            NumberChange nc2 = new NumberChange(MultNum);
            nc = nc1;
            nc += nc2;

            // 调用多播
            nc(5);
            Console.WriteLine("Value of Num: {0}", getNum());
        }
    }
}