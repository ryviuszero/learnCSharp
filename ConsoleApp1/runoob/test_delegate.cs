using System;

delegate int NumberChange(int n);
namespace DelegateAppl
{
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