using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screen_Beauty
{
    public partial class Screen
    {
        private int FHeight = 0;
        private int FWidth = 0;
        private int Height_Speed = 0;
        private int Width_Speed = 0;
        private int HSleep = 0;
        private int WSleep = 0;
        private int First_Height = 0;
        private int First_Width = 0;

        Form form = null;

        public Screen(Form form)
        // 가로 세로 = 100, 속도 = 2, 딜레이 = 1, 초기값 = 1
        {
            this.form = form;
            this.FHeight = 100;
            this.FWidth = 100;
            this.Height_Speed = 2;
            this.Width_Speed = 2;
            this.HSleep = 1;
            this.WSleep = 1;
            this.First_Height = 1;
            this.First_Width = 1;
        }
        public Screen(Form form, int Width, int Height, int Width_Speed, int Height_Speed)
        // 딜레이 문 속도 0.001초
        {
            this.form = form;
            this.FHeight = Height;
            this.FWidth = Width;
            this.Height_Speed = Height_Speed;
            this.Width_Speed = Width_Speed;
            this.HSleep = 1;
            this.WSleep = 1;
            this.First_Height = 1;
            this.First_Width = 1;
        }
        public Screen(Form form, int Width, int Height, int Width_Speed, int Height_Speed, int WSleep, int HSleep)
        // First 초기값 1
        {
            this.form = form;
            this.FWidth = Width;
            this.FHeight = Height;
            this.Width_Speed = Width_Speed;
            this.Height_Speed = Height_Speed;
            this.WSleep = WSleep;
            this.HSleep = HSleep;
            this.First_Height = 1;
            this.First_Width = 1;
        }
        public Screen(Form form, int Width, int Height, int Width_Speed, int Height_Speed, int WSleep, int HSleep, int First_Width, int First_Height)
        // First -> 처음 의 크기
        {
            this.form = form;
            this.FWidth = Width;
            this.FHeight = Height;
            this.Width_Speed = Width_Speed;
            this.Height_Speed = Height_Speed;
            this.WSleep = WSleep;
            this.HSleep = HSleep;
            this.First_Height = First_Height;
            this.First_Width = First_Width;
        }
        public void WHStart()
        // Width -> Height
        {
            int TWidth = 0;
            int THeight = 0;
            Point DeskPoint = form.DesktopLocation;
            Size FormSize = form.Size;

            for (TWidth = 0; TWidth < FWidth; TWidth += Width_Speed)
            {
                form.Size = new Size(TWidth, First_Height);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)));
                System.Threading.Thread.Sleep(WSleep);
            } for (THeight = 0; THeight < FHeight; THeight += Height_Speed)
            {
                form.Size = new Size(FWidth, THeight);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                System.Threading.Thread.Sleep(HSleep);
            } form.Size = new Size(FWidth, FHeight);
            form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
        }
        public void HWStart()
        {
            int TWidth = 0;
            int THeight = 0;
            Point DeskPoint = form.DesktopLocation;
            Size FormSize = form.Size;

            for (THeight = 0; THeight < FHeight; THeight += Height_Speed)
            {
                form.Size = new Size(First_Width, THeight);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)), (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                System.Threading.Thread.Sleep(HSleep);
            } for (TWidth = 0; TWidth < FWidth; TWidth += Width_Speed)
            {
                form.Size = new Size(TWidth, THeight);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                System.Threading.Thread.Sleep(WSleep);
            }
            form.Size = new Size(FWidth, FHeight);
            form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
        }
        public void RHWStart(bool Final)
        // Width -> Height
        {
            Point DeskPoint = form.DesktopLocation;
            Size FormSize = form.Size;
            int TWidth = FormSize.Width;
            int THeight = FormSize.Height;

            if (Final)
            {
                Point FirstPoint = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);

                for (; THeight > 0; THeight -= Height_Speed)
                {
                    form.Size = new Size(FWidth, THeight);
                    form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                    System.Threading.Thread.Sleep(HSleep);
                } for (; TWidth > 0; TWidth -= Width_Speed)
                {
                    form.Size = new Size(TWidth, THeight);
                    form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                    System.Threading.Thread.Sleep(HSleep);
                }
                form.Size = new Size(FWidth, FHeight);
                form.DesktopLocation = FirstPoint;
            }
            else
            {
                for (; THeight > 0; THeight -= Height_Speed)
                {
                    form.Size = new Size(FWidth, THeight);
                    form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                    System.Threading.Thread.Sleep(HSleep);
                } for (; TWidth > 0; TWidth -= Width_Speed)
                {
                    form.Size = new Size(TWidth, THeight);
                    form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                    System.Threading.Thread.Sleep(HSleep);
                }
                form.Size = new Size(0,0);
            }
        }
        public void RWHStart()
        // Width -> Height
        {
            Point DeskPoint = form.DesktopLocation;
            Size FormSize = form.Size;

            int TWidth = FormSize.Width;
            int THeight = FormSize.Height;

            for (; TWidth > 0; TWidth -= Width_Speed)
            {
                form.Size = new Size(TWidth, FHeight);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                System.Threading.Thread.Sleep(HSleep);
            }
            for (; THeight > 0; THeight -= Height_Speed)
            {
                form.Size = new Size(TWidth, THeight);
                form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
                System.Threading.Thread.Sleep(HSleep);
            } form.Size = new Size(FWidth, FHeight);
            form.DesktopLocation = new Point((DeskPoint.X + (FormSize.Width / 2)) - TWidth / 2, (DeskPoint.Y + (FormSize.Height / 2)) - THeight / 2);
        }
    }
}
