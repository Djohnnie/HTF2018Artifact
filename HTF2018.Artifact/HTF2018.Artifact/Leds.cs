using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace HTF2018.Artifact
{
    public class Leds
    {
        private GpioPin _dataPin;
        private GpioPin _clockPin;
        private GpioPin _latchPin;

        private int _whiteLedsCount = 0;
        private int _greenLedsCount = 0;
        private int _redLedsCount = 0;

        private int[] _whiteLedsA = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _whiteLedsB = new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _whiteLedsC = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _whiteLedsD = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] _whiteLedsE = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
        private int[] _whiteLedsF = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        private int[] _greenLeds = new[] { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 };
        private int[] _redLeds = new[] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0 };

        public Leds()
        {
            _dataPin = Pi.Gpio.Pin00;
            _dataPin.PinMode = GpioPinDriveMode.Output;
            _clockPin = Pi.Gpio.Pin01;
            _clockPin.PinMode = GpioPinDriveMode.Output;
            _latchPin = Pi.Gpio.Pin02;
            _latchPin.PinMode = GpioPinDriveMode.Output;
        }

        public void RandomizeWhite()
        {
            _whiteLedsCount++;
            if (_whiteLedsCount == 1)
            {
                SetLeds(_whiteLedsA);
            }
            if (_whiteLedsCount == 2)
            {
                SetLeds(_whiteLedsB);
            }
            if (_whiteLedsCount == 3)
            {
                SetLeds(_whiteLedsC);
            }
            if (_whiteLedsCount == 4)
            {
                SetLeds(_whiteLedsD);
            }
            if (_whiteLedsCount == 5)
            {
                SetLeds(_whiteLedsE);
            }
            if (_whiteLedsCount == 6)
            {
                SetLeds(_whiteLedsF);
                _whiteLedsCount = 0;
            }
        }

        public void SetGreen()
        {
            _greenLedsCount = 0;
            SetLeds(_greenLeds);
        }

        public void SetRed()
        {
            _redLedsCount = 0;
            SetLeds(_redLeds);
        }

        private void SetLeds(int[] leds)
        {
            for (int i = 0; i < leds.Length; i++)
            {
                _dataPin.Write(0);
                Thread.Sleep(1);
                _dataPin.Write(leds[i]);

                Thread.Sleep(1);
                _latchPin.Write(0);
                Thread.Sleep(1);
                _latchPin.Write(1);
            }

            Thread.Sleep(1);
            _clockPin.Write(0);
            Thread.Sleep(1);
            _clockPin.Write(1);
        }
    }
}