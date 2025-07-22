#define hello
#define DEBUG
using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;


namespace BugFixApplication
{
    // 一个自定义特性 BugFix 被赋给类及其成员
    [AttributeUsage
    #region // 定了特性能被放在哪些前面
    (
        AttributeTargets.Class |
        AttributeTargets.Constructor |
        AttributeTargets.Field |
        AttributeTargets.Method |
        AttributeTargets.Property,
    #endregion
    AllowMultiple = true)]
    public class DeBugInfo : System.Attribute //继承了预定义特性后的自定义特性
    {
        private int bugNo;
        private string developer;
        private string lastReview;
        public string message;

        public DeBugInfo(int bg, string dev, string d)//构造函数，接收三个参数并赋给对应实例
        {
            this.bugNo = bg;
            this.developer = dev;
            this.lastReview = d;
        }

        #region//定义对应的调用，返回对应值value
        public int BugNo
        {
            get
            {
                return bugNo;
            }
        }
        public string Developer
        {
            get
            {
                return developer;
            }
        }
        public string LastReview
        {
            get
            {
                return lastReview;
            }
        }

        //前面有public string message;
        public string Message//定义了可以通过Message = "",来对message进行赋值。
                             //因为不在构造函数中，所以是可选的
        {
            get
            { return message; }
            set
            { message = value; }
        }

    }
    #endregion


    [DeBugInfo(45, "Zara Ali", "12/8/2012",
         Message = "Return type mismatch")]
    [DeBugInfo(49, "Nuha Ali", "10/10/2012",
         Message = "Unused variable")]//前面定义时的AllowMultiple=ture允许了多次使用在同一地方
    class Rectangle
    {
        protected double length;
        protected double width;//定义两个受保护的（封装）的成员变量
        public Rectangle(double l, double w)//构造函数，对两个成员变量进行初始化，公开的
        {
            length = l;
            width = w;
        }

        [DeBugInfo(55, "Zara Ali", "19/10/2012",
             Message = "Return type mismatch")]
        public double GetArea()
        {
            return length * width;
        }

        [DeBugInfo(56, "Zara Ali", "19/10/2012")]//因为message是可选项，所以可以不给出
                                                 //不给出即为null，为空白
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width:{0}", width);
            Console.WriteLine("Area:{0}", GetArea());//常规打印
        }
    }

    class ExecuteRectangle
    {
        public static void Run(string[] args)
        {
            Rectangle rect = new Rectangle(10, 5);
            rect.Display();

            Type type = typeof(Rectangle);
            foreach (Object attribute in type.GetCustomAttributes(false))
            {
                DeBugInfo dbi = (DeBugInfo)attribute;
                if (null != dbi)
                {
                    Console.WriteLine("BugNo: {0}", dbi.BugNo);
                    Console.WriteLine("Developer: {0}", dbi.Developer);
                    Console.WriteLine("LastReview: {0}", dbi.LastReview);
                    Console.WriteLine("Message: {0}", dbi.Message);
                }
            }

            foreach (MethodInfo m in type.GetMethods())
            {
                foreach (Attribute a in m.GetCustomAttributes(true))
                {
                    DeBugInfo dbi = a as DeBugInfo;
                    if (dbi != null)
                    {
                        Console.WriteLine("Method: {0}", m.Name);
                        Console.WriteLine("BugNo: {0}", dbi.BugNo);
                        Console.WriteLine("Developer: {0}", dbi.Developer);
                        Console.WriteLine("LastReview: {0}", dbi.LastReview);
                        Console.WriteLine("Message: {0}", dbi.Message);
                    }
                }
            }




        }
    }

}