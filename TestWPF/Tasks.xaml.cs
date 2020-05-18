using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWPF
{
    public partial class Tasks : UserControl
    {
        public Tasks()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _ProcessCancellation;
        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;
            button.IsEnabled = false;
            var cancellation = new CancellationTokenSource();
            _ProcessCancellation?.Cancel();
            _ProcessCancellation = cancellation;

            const string message = "hello World";

            Result.Text = "Начался расчёт";
            IProgress<int> progress = new Progress<int>(p => _Progress.Value = p);

            try
            {
                var result = await GetMessageLengthAsync(message, 30, progress, cancellation.Token).ConfigureAwait(true);

                progress.Report(0);
                Result.Text = result.ToString();
            }
            catch(OperationCanceledException)
            {
                Result.Text = "Выполнен сброс";
                progress?.Report(0);
            }
            button.IsEnabled = true;
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            _ProcessCancellation?.Cancel();   
        }

        private async Task<int> GetMessageLengthAsync(string Message, int Timeout = 30, IProgress<int> progress = null, CancellationToken Cancel = default)
        {
            return await Task.Run(() => GetLengthAsync(Message, Timeout, progress, Cancel), Cancel).ConfigureAwait(false);
        }

        private int _StartCount;
        private int GetMessageLength(string Message, int Timeout = 30, IProgress<int> progress = null, CancellationToken Cancel = default)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(Timeout);
                progress?.Report(i);

                Cancel.ThrowIfCancellationRequested();
            }
            return Message.Length + _StartCount++;
        }

        private async Task<int> GetLengthAsync(string Message, int Timeout = 30, IProgress<int> progress = null, CancellationToken Cancel = default)
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(Timeout, Cancel);

                //if (Cancel.IsCancellationRequested)
                //    progress?.Report(0);
                //else
                    progress?.Report(i);

                Cancel.ThrowIfCancellationRequested();
            }
            return Message.Length + _StartCount++;
        }
    }
}
