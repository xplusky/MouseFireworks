using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MouseParticle
{
    public class Dot : Canvas
    {
        public double Gravity = 1;
        public double XVelocity = 1;
        public double YVelocity = 1;

        public Dot(byte red, byte green, byte blue, double size)
        {
            double opac = GlobalValue.OPACITY;
            size = GlobalValue.random.Next(GlobalValue.SIZE_MIN, GlobalValue.SIZE_MAX);
            //生成圆圈粒子
            {
                var ellipse = new Ellipse();
                ellipse.Width = size;
                ellipse.Height = size;
                ellipse.Fill = new SolidColorBrush(Color.FromArgb(255, red, green, blue));
                ellipse.Opacity = opac;
                ellipse.SetValue(LeftProperty, -ellipse.Width/2);
                ellipse.SetValue(TopProperty, -ellipse.Height/2);
                Children.Add(ellipse);
            }
        }

        //制作一个绑定属性
        public double X
        {
            get { return (double) (GetValue(LeftProperty)); }
            set { SetValue(LeftProperty, value); }
        }

        public double Y
        {
            get { return (double) (GetValue(TopProperty)); }
            set { SetValue(TopProperty, value); }
        }

        public void RunFirework()
        {
            X = X + XVelocity;
            Y = Y + YVelocity;
            Opacity += GlobalValue.OpacityInc;
            YVelocity += Gravity;
        }
    }
}