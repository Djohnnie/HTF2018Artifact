using System;
using System.Threading;

namespace HTF2018.Artifact
{
    class Program
    {
        private static readonly Poller _poller = Poller.Instance;
        private static readonly Animator _animator = Animator.Instance;

        static void Main(string[] args)
        {
            Console.WriteLine("HTF2018 Artifact Console");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Press the ESC key to shut down this console! ");

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
            _animator.Animate(_poller.Status);
            Thread.Sleep(100);
        }
    }
}