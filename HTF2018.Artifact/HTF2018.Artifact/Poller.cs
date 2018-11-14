using System;
using System.Threading;
using System.Threading.Tasks;

namespace HTF2018.Artifact
{
    public sealed class Poller
    {
        private static readonly Poller _instance = new Poller();
        private Random _randomGenerator = new Random();
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private Task _pollerTask;
        private Status _status;

        static Poller()
        {
        }

        private Poller()
        {
        }

        public static Poller Instance
        {
            get
            {
                return _instance;
            }
        }

        public Status Status
        {
            get { return _status; }
        }

        public void Start()
        {
            var ct = _cts.Token;
            _pollerTask = Task.Run(async () =>
            {
                while (!ct.IsCancellationRequested)
                {
                    await Poll();
                }
            }, _cts.Token);
        }

        public void Stop()
        {
            _cts.Cancel();
            while (!_pollerTask.IsCompleted)
            {
                Thread.Sleep(100);
            }
        }

        private async Task Poll()
        {
            await Task.Delay(10000);
            _status = _randomGenerator.Next(0, 2) == 0 ? Status.Successful : Status.Unsuccessful;
        }
    }
}