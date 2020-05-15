using System;
using System.Linq;
using System.Threading;

namespace TestConsole
{
    internal class ThreadPooltest
    {
        public static void Start()
        {
            var messages = Enumerable.Range(1, 100).Select(x => $"Message {x}").ToArray();
            //var threads = new Thread[messages.Length];

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    var i1 = i;
            //    threads[i] = new Thread(() => PrintThreadMessage(messages[i1]));
            //}

            //for (int i = 0; i < threads.Length; i++)
            //    threads[i].Start();

            //for (int i = 0; i < threads.Length; i++)
            //    threads[i].Join();

            //ThreadPool.SetMinThreads(2, 2);
            //ThreadPool.SetMaxThreads(16, 16);

            for (int i = 0; i < messages.Length; i++)
            {
                var i1 = i;
                ThreadPool.QueueUserWorkItem(x => PrintThreadMessage(messages[i1]));
            }
        }
        private static void PrintThreadMessage(string message)
        {
            Console.WriteLine("Печать сообщения из потока Id:{0} - {1}", Thread.CurrentThread.ManagedThreadId, message);
            Thread.Sleep(2000);
            Console.WriteLine("Печать сообщения из потока Id:{0} - {1} - завершена", Thread.CurrentThread.ManagedThreadId, message);
        }
    }
}
