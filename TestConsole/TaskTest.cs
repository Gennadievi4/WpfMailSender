using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class TaskTest
    {
        public static void Start()
        {
            #region Примеры task (как делать не надо, только для теста сделал.)
            //var first_thread = new Task(TaskMethod);
            //first_thread.Start();
            //new Task(TaskMethod).Start();
            //const string msg = "Hello world";
            //var calculation_task = new Task<int>(() => GetMessageLength(msg));
            //var continuation_task = calculation_task.ContinueWith(t => Console.WriteLine("Длинна сообщения {0}", t.Result));
            //continuation_task.ContinueWith(t => Console.WriteLine("Теперь точно конец!"));
            //calculation_task.Start();

            //for (int i = 0; i < 20; i++)
            //{
            //    Thread.Sleep(20);
            //    Console.WriteLine("Работа в основном потоке...");
            //}

            //var msg_length = calculation_task.Result;

            //Console.WriteLine("Длинна сообщения {0}", msg_length);
            #endregion

            //var action_task = Task.Run(TaskMethod);
            //const string msg = "Hello world";
            //var task_result = Task.Run(() => GetMessageLength(msg));
            //task_result.ContinueWith(x => Console.WriteLine("Длинна сообщения {0}", x.Result));
            //var res = task_result.Result;

            #region Эксперименты с исключениями в заданиях
            var task_exeption = Task.Run(() => GetMessageLength(null));
            task_exeption.ContinueWith(x => Console.WriteLine("Длинна сообщения {0}", x.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            task_exeption.ContinueWith(x => Console.WriteLine("Длинна сообщения {0}", x.Exception.Message), TaskContinuationOptions.OnlyOnFaulted);
            int fault_len = -1;
            try
            {
                fault_len = task_exeption.Result;
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion


        }

        public static async void StartAsync()
        {
            //var action_task = Task.Run(TaskMethod);
            //await action_task;
            Console.WriteLine("Подготовка к запуску асинхронной операции ThrID:{0}", Thread.CurrentThread.ManagedThreadId);

            await Task.Run(TaskMethod).ConfigureAwait(true);
            //Проконтроллируем потоки
            Console.WriteLine("Обработка данных после запуска TrdID:{0}", Thread.CurrentThread.ManagedThreadId);

            var msg_len = await Task.Run(() => GetMessageLength("Hello world!!!")).ConfigureAwait(false);
            Console.WriteLine("ThrID:{0} TaskID:{1} - started : msg = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, msg_len);
        }

        public static async void StartDataProcessAsync()
        {
            var messages = Enumerable.Range(1, 100).Select(x => $"Message {x}").ToArray();
            var tasks = messages.Select(msg => Task.Run(() => GetMessageLength(msg, 30)));
            //var tasks_array = tasks.ToArray();

            //Task.WaitAll(tasks.ToArray());
            //Task.WaitAny(tasks.ToArray());

            //var complete_all_task = Task.WhenAll(tasks);
            //var complete_any_task = Task.WhenAny(tasks);

            //var results = await Task.WhenAll(tasks);
            //Console.WriteLine("Суммарная длина сообщений {0}", results.Sum());
            var resultsWhenAny = await Task.WhenAny(tasks);
            Console.WriteLine("Суммарная длина сообщений {0}", await resultsWhenAny);
        }
        private static void TaskMethod()
        {
            Console.WriteLine("ThrID:{0} TaskID:{1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Thread.Sleep(1000);
            Console.WriteLine("ThrID:{0} TaskID:{1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
        }

        private static int GetMessageLength (string msg, int Timeout = 1000)
        {
            Console.WriteLine("Входные данные:\"{0}\"", msg ?? "<null>");
            if (msg is null) throw new ArgumentNullException(nameof(msg));
            Console.WriteLine("ThrID:{0} TaskID:{1} - started : msg = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, msg);
            Thread.Sleep(Timeout);
            Console.WriteLine("ThrID:{0} TaskID:{1} - started : msg = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, msg);
            return msg.Length;
        }
    }
}
