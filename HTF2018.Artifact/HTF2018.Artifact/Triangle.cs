namespace HTF2018.Artifact
{
    public class Triangle
    {
        public bool White1 { get; set; }
        public bool White2 { get; set; }
        public bool Green1 { get; set; }
        public bool Green2 { get; set; }
        public bool Red1 { get; set; }
        public bool Red2 { get; set; }

        public void RandomizeWhite()
        {
            White1 = true;
            White2 = true;
            Green1 = false;
            Green2 = false;
            Red1 = false;
            Red2 = false;
        }

        public void SetGreen()
        {
            White1 = false;
            White2 = false;
            Green1 = true;
            Green2 = true;
            Red1 = false;
            Red2 = false;
        }

        public void SetRed()
        {
            White1 = false;
            White2 = false;
            Green1 = false;
            Green2 = false;
            Red1 = true;
            Red2 = true;
        }

        public bool[] GetLeds()
        {
            return new[] { false, White1, White2, Green1, Green2, Red1, Red2, false };
        }
    }
}