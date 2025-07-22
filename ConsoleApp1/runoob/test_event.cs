// event 可以看作特殊的委托，在外部类中无法使用 =
using System;
using System.Diagnostics;

namespace EventDemo
{
    // 定义一个委托类型，用于事件处理程序
    public delegate void NotifyEventHandler(object sender, EventArgs e);

    // 发布者类
    public class ProcessBusinessLogic
    {
        // 声明事件
        public event NotifyEventHandler ProcessCompleted;

        // 触发事件的方法
        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

        // 模拟业务逻辑过程并触发事件
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");

            OnProcessCompleted(EventArgs.Empty);
        }
    }

    // 订阅者类
    public class EventSubscriber
    {
        public void Subscribe(ProcessBusinessLogic process)
        {
            process.ProcessCompleted += Process_ProcessCompleted;
        }

        public void Process_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }

    }

    class ExecEventLogic
    {
        public static void Run(string[] args)
        {
            ProcessBusinessLogic process = new ProcessBusinessLogic();
            EventSubscriber subscriber = new EventSubscriber();

            // 订阅事件
            subscriber.Subscribe(process);

            // 启动过程
            process.StartProcess();
        }
    }


}
