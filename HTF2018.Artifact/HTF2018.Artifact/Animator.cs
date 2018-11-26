namespace HTF2018.Artifact
{
    public sealed class Animator
    {
        private static readonly Animator _instance = new Animator();

        private readonly Leds _leds = new Leds();

        static Animator()
        {
        }

        private Animator()
        {
        }

        public static Animator Instance => _instance;

        public void Animate(Status? status)
        {
            try
            {
                switch (status)
                {
                    case null:
                        _leds.RandomizeWhite();
                        break;
                    case Status.Successful:
                        _leds.SetGreen();
                        break;
                    case Status.Unsuccessful:
                        _leds.SetRed();
                        break;
                }
            }
            catch { /* DO NOTHING */ }
        }
    }
}