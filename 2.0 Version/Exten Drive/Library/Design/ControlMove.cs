using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Beauty
{
    class ControlMove
    {
        Control Ctrl = new Control();
        

        private DateTime Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);

            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }

            return DateTime.Now;
        }

        public void Move(Control _Ctrl, Point Arrive, int time)
        {
            Point Distance;
            Ctrl = _Ctrl;
            Distance = new Point(Arrive.X - Ctrl.Location.X, Arrive.Y - Ctrl.Location.Y);

            int i = time;
            int x = Distance.X / i;
            int y = Distance.Y / i;

            for (int a = 0; a < i; a++)
            {
                Ctrl.Location = new Point(Ctrl.Location.X + x, Ctrl.Location.Y + y);
                Delay(10);
            }
            Ctrl.Location = Arrive;
        }
        public void Size(Control _Ctrl, Size Arrive, int time)
        {
            Size Distance;
            Ctrl = _Ctrl;
            Distance = new Size(Arrive.Width - Ctrl.Size.Width, Arrive.Height - Ctrl.Size.Height);

            int i = time;
            int x = Distance.Width / i;
            int y = Distance.Height / i;

            for (int a = 0; a < i; a++)
            {
                Ctrl.Size = new Size(Ctrl.Size.Width + x, Ctrl.Size.Height + y);
                Delay(10);
            }
            Ctrl.Size = Arrive;
        }

    }
}
