using RestSharp;
using System;
using System.Diagnostics;
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
        private readonly RestClient _restClient;
        private Status? _status;

        static Poller()
        {
        }

        private Poller()
        {
            _restClient = new RestClient("http://localhost:52100");
        }

        public static Poller Instance => _instance;

        public Status? Status => _status;

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
            try
            {
                _status = null;
                await Task.Delay(500);
                var sw = Stopwatch.StartNew();
                RestRequest request = new RestRequest("dashboard/history/status", Method.GET);
                request.AddHeader("htf-identification", "7f395e9b-8eb2-4829-b948-49ca2df65b2c");
                var response = await _restClient.ExecuteTaskAsync<History>(request);
                if (response.IsSuccessful && response.Data != null)
                {
                    _status = response.Data.Status;
                }
                sw.Stop();
                Debug.WriteLine($"POLLING TOOK {sw.ElapsedMilliseconds}ms");
            }
            catch { /* DO NOTHING */ }
        }
    }
}