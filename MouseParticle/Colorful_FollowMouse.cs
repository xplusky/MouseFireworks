using System.Windows;
using System.Windows.Input;
using MouseKeyboardLibrary;
using forms = System.Windows.Forms;

namespace MouseParticle
{
    public class ColorfulFollowMouse : Colorful
    {
        public ColorfulFollowMouse()
        {
            var mouseHook = new MouseHook();
            //MouseMove += new MouseEventHandler(Colorful_FollowMouse_MouseMove);
            mouseHook.MouseMove += MouseHookMouseMove;
            mouseHook.Start();
        }

        private void Colorful_FollowMouse_MouseMove(object sender, MouseEventArgs e)
        {
            
            AddDotToGroup(e.GetPosition(this).X, e.GetPosition(this).Y);
            //MessageBox.Show(e.GetPosition(this).X.ToString());
        }

        private void MouseHookMouseMove(object sender, forms.MouseEventArgs e)
        {
            var width = SystemParameters.WorkArea.Width;
            var widthpix = (double)forms.Screen.PrimaryScreen.Bounds.Width;
            var suofang = widthpix / width;
            AddDotToGroup(e.X/ suofang, e.Y/ suofang);
        }
    }
}