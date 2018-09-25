using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Metroid
{
    public class KeyboardController
    {
        public event EventHandler kbEvent;
        private DispatcherTimer timer;
        private HashSet<Key> keyPressed;

        public KeyboardController(Window c, EventHandler function)
        {
            c.KeyDown += WinKeyDown;
            c.KeyUp += WinKeyUp;
            kbEvent = function;
            keyPressed = new HashSet<Key>();

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(kbTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
        }

        public bool KeyDown(Key key)
        {
            if (keyPressed.Contains(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void WinKeyDown(object sender, KeyEventArgs e)
        {
            keyPressed.Add(e.Key);
        }

        private void WinKeyUp(object sender, KeyEventArgs e)
        {
            keyPressed.Remove(e.Key);
            if (e.Key == Key.A)
            {
                Constants.SamusPreviousPositionX = Constants.SamusPositionX;
            }
            if (e.Key == Key.D)
            {
                Constants.SamusPreviousPositionX = Constants.SamusPositionX;
            }
        }

        private void kbTimer_Tick(object sender, EventArgs e)
        {
            kbEvent(null, null);
        }
    }
}
