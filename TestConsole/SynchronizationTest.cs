using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
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
                thread[i] = new Thread(() => Printer2($"Message {i0}"));
            }
            Array.ForEach(thread, threads => threads.Start());
        }

        private readonly static object __SyncRoot = new object();
        private static void Printer(string Messages, int count = 20)
        {
            for (var i = 0; i < count; i++)
            {
                lock (__SyncRoot)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg{0}:", i);
                    Console.WriteLine("\"{0}\"", Messages);
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void Printer2(string Messages, int count = 20)
        {
            for (var i = 0; i < count; i++)
            {
                lock (__SyncRoot)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg{0}:", i);
                    Console.WriteLine("\"{0}\"", Messages);
                }
            }
        }

        [Synchronization]
        internal class Logger : ContextBoundObject
        {
            private string _FilePath;
            public string FilePath
            {
                get => _FilePath;
                set
                {
                    if (!File.Exists(value))
                        throw new FileNotFoundException("Файл не найден!", value);
                    _FilePath = value;
                }
            }
            //[MethodImpl(MethodImplOptions.Synchronized)]
            public Logger(string Path) => _FilePath = Path;
            public void Log(string Message)
            {
                //lock(this)
                File.AppendAllText(_FilePath, Message);
            }
        }
    }
}
