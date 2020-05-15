using System;
using System.Threading;

namespace TestConsole
{
    internal class SynchronizationTest
    {
        public static void Start()
        {
            var thread = new Thread[10];
            for (int i = 0; i < thread.Length; i++)
            {
                var i0 = i;
                thread[i] = new Thread(() => Printer($"Message {i0}"));
            }
            Array.ForEach(thread, threads => threads.Start());
        }

        private static void Printer(string Messages, int count = 20)
        {
            for (var i = 0; i < count; i++)
            {
                Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                Console.Write(" - msg{0}:", i);
                Console.WriteLine("\"{0}\"", Messages);
            }
        }
    }
}
