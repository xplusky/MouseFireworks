using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace MouseParticle
{
    public class Colorful : Canvas
    {
        private const int IntervalTime = 20;
        private readonly List<Dot> _dotGroup = new List<Dot>();

        private DispatcherTimer _timer;

        public Colorful()
        {
            Background = new SolidColorBrush(Color.FromArgb(1, 255, 255, 255));
            Start();
        }

        private void LoopTimerTick(object sender, EventArgs e)
        {
            MoveDots();
        }

        private void MoveDots()
        {
            for (int i = _dotGroup.Count - 1; i >= 0; i--)
            {
                var dot = _dotGroup[i];
                dot.RunFirework();
                if (dot.Opacity <= 0.1)
                {
                    Children.Remove(dot);
                    _dotGroup.Remove(dot);
                }
            }
        }

        public void AddDotToGroup(double x, double y)
        {
            //int seed = (int)DateTime.Now.Ticks;

            for (int i = 0; i < GlobalValue.FIREWORK_NUM; i++)
            {
                double size = GlobalValue.SIZE_MIN + (GlobalValue.SIZE_MAX - GlobalValue.SIZE_MIN)*GlobalValue.random.NextDouble();
                var red = (byte) (128 + (128*GlobalValue.random.NextDouble()));
                var green = (byte) (128 + (128*GlobalValue.random.NextDouble()));
                var blue = (byte) (128 + (128*GlobalValue.random.NextDouble()));

                double xVelocity = GlobalValue.X_VELOCITY - 2*GlobalValue.X_VELOCITY*GlobalValue.random.NextDouble();
                double yVelocity = -GlobalValue.Y_VELOCITY*GlobalValue.random.NextDouble();
                var dot = new Dot(red, green, blue, size)
                {
                    X = x, Y = y, XVelocity = xVelocity, YVelocity = yVelocity, 
                    Gravity = GlobalValue.GRAVITY
                };
                dot.RunFirework();
                _dotGroup.Add(dot);

                Children.Add(dot);
            }
        }

        public void Start()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(IntervalTime)
            };

            _timer.Tick += LoopTimerTick;
            _timer.Start();
        }
    }
}