using System;
using System.Threading;

namespace TestConsole
{
    internal static class ThreadTest
    {
        private static void CheckThread(Thread thread)
        {
            Console.WriteLine("Поток [id:{0}]:{1} - {2}фоновый", thread.ManagedThreadId, thread.Name, thread.IsBackground ? "" : "не ");
        }

        private static bool _ClockCanWork = true;
        private static void ClockThread()
        {
            try
            {
                CheckThread(Thread.CurrentThread);
                while (_ClockCanWork)
                {
                    Console.Title = DateTime.Now.ToString();
                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван");
            }
            Console.WriteLine("Поток часов заршил свою работу");
        }
        private static void PrintThreadMessage(object parameter)
        {
            PrintThreadMessage((string)parameter);
        }
        private static void PrintThreadMessage(string message)
        {
            Console.WriteLine("Печать сообщения из потока Id:{0} - {1}", Thread.CurrentThread.ManagedThreadId, message);
            Thread.Sleep(2000);
            Console.WriteLine("Печать сообщения из потока Id:{0} - {1} - завершена", Thread.CurrentThread.ManagedThreadId, message);
        }

        class PrinterData
        {
            private string _Message;
            public PrinterData(string Message) => _Message = Message;
            public void Print() => Console.WriteLine("Печать сообщения из потока id:{0} - {1}", Thread.CurrentThread.ManagedThreadId, _Message);
        }
        public static void Start()
        {
                Thread.CurrentThread.Name = "Главный поток";
                CheckThread(Thread.CurrentThread);

                var clock_thread = new Thread(ClockThread);
                clock_thread.Name = "Фоновый поток";
                clock_thread.Priority = ThreadPriority.BelowNormal;
                //clock_thread.IsBackground = true;
                clock_thread.Start();

                var message = "Hello World!";

                //var printer1_thread = new Thread(new ParameterizedThreadStart(PrintThreadMessage));
                //var printer1_thread = new Thread(PrintThreadMessage);
                //printer1_thread.Start(message);

                //var printer2_thread = new Thread(() => PrintThreadMessage(message));
                //printer2_thread.Start();

                var printer_data = new PrinterData(message);
                var printer3_threa = new Thread(printer_data.Print);
                printer3_threa.Start();

                Console.WriteLine("Главный поток завершился!");
                Console.ReadLine();

                _ClockCanWork = false;
                //clock_thread.Abort();
                if (!clock_thread.Join(50))
                    clock_thread.Interrupt();

                Console.WriteLine("Приложение должно быть закрыто");
        }
        
    }
}
