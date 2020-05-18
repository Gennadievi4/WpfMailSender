using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TestConsole
{
    internal class TPLtests
    {
        public static void Start2()
        {

            var cancellation = new CancellationTokenSource(millisecondsDelay: 3000);
            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}");
            var long_creating_messages = messages.AsParallel()
                .WithDegreeOfParallelism(degreeOfParallelism: 3)
                .WithCancellation(cancellation.Token)
                .Select(
                m =>
                {
                    Console.WriteLine("Запрос сообщения {0}", m);
                    Thread.Sleep(250);
                    Console.WriteLine("Запрос сообщения {0}", m);
                    return m;
                });
            var timer = Stopwatch.StartNew();
            var selected_messages = long_creating_messages
                .Select(m => (msg: m, length: m.Length))
                .AsSequential()
                .Where(m => m.msg.EndsWith("20"))
                .ToArray();

            Console.WriteLine("Главный поток завершён!");
            Console.ReadLine();
        }
        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThrID: {0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThrID: {0} - finished", Thread.CurrentThread.ManagedThreadId);
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine("ThrID: {0} - started: {1}", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThrID: {0} - finished: {1}", Thread.CurrentThread.ManagedThreadId, msg);
        }
    }
}
