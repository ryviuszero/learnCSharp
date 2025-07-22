// #define hello
using System;
using System.Diagnostics;

namespace AttributeApplication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property,
    AllowMultiple = true,
    Inherited = false)]
    public class HelpAttribute : Attribute
    {
        protected String description;

        public HelpAttribute(String Description)
        {
            this.description = Description;
        }
        public String Description
        {
            get
            {
                return this.description;
            }
        }
    }

    public class TestConAttribute
    {
        [Conditional("hello")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    class RunTestConAttribute
    {
        static void function1()
        {
            TestConAttribute.Message("In Function1");
            function2();
        }

        static void function2()
        {
            TestConAttribute.Message("In Function2");
        }

        public static void Run(string[] args)
        {
            TestConAttribute.Message("In Main");
            function1();
        }
    }

}
