using System.Collections.Generic;

namespace HTF2018.Artifact
{
    public class Leds
    {
        private Triangle _t01 = new Triangle();
        private Triangle _t02 = new Triangle();
        private Triangle _t03 = new Triangle();
        private Triangle _t04 = new Triangle();
        private Triangle _t05 = new Triangle();
        private Triangle _t06 = new Triangle();
        private Triangle _t07 = new Triangle();
        private Triangle _t08 = new Triangle();
        private Triangle _t09 = new Triangle();
        private Triangle _t10 = new Triangle();
        private Triangle _t11 = new Triangle();
        private Triangle _t12 = new Triangle();
        private Triangle _t13 = new Triangle();
        private Triangle _t14 = new Triangle();
        private Triangle _t15 = new Triangle();

        private readonly List<Triangle> _ts = new List<Triangle>();

        public Leds()
        {
            _ts.Add(_t01);
            _ts.Add(_t02);
            _ts.Add(_t03);
            _ts.Add(_t04);
            _ts.Add(_t05);
            _ts.Add(_t06);
            _ts.Add(_t07);
            _ts.Add(_t08);
            _ts.Add(_t09);
            _ts.Add(_t10);
            _ts.Add(_t11);
            _ts.Add(_t12);
            _ts.Add(_t13);
            _ts.Add(_t14);
            _ts.Add(_t15);
        }

        public void RandomizeWhite()
        {
            foreach (var t in _ts)
            {
                t.RandomizeWhite();
            }
        }

        public void SetGreen()
        {
            foreach (var t in _ts)
            {
                t.SetGreen();
            }
        }

        public void SetRed()
        {
            foreach (var t in _ts)
            {
                t.SetRed();
            }
        }

        public bool[] GetLeds()
        {
            List<bool> leds = new List<bool>();
            foreach (var t in _ts)
            {
                leds.AddRange(t.GetLeds());
            }
            return leds.ToArray();
        }
    }
}