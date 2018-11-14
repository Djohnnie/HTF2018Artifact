using System;
using System.Threading;

namespace HTF2018.Artifact
{
    class Program
    {
        private static readonly Poller _poller = Poller.Instance;

        static void Main(string[] args)
        {
            _poller.Start();
            do
            {
                while (!Console.KeyAvailable)
                {
                    MainLoop();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.WriteLine();
            Console.WriteLine("Shutting down...");
            _poller.Stop();
        }

        static void MainLoop()
        {
            Console.Clear();
            Console.WriteLine("HTF2018 Artifact Console");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine($"{_poller.Status}");
            Console.WriteLine();
            Console.Write("Press the ESC key to shut down this console! ");
            Thread.Sleep(100);
        }
    }
}