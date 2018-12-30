using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Library;
using Exten_Drive.Properties;

namespace Library.Design
{
    public delegate void IsDoubleClick(object sender, string DriveID);
    public delegate void IsHover(object sender);


    public partial class FolderNFile : UserControl
    {
        public event IsDoubleClick IsDoubleClick;
        public event IsHover IsHover;
        public event IsHover MyMouseLeave;

        protected virtual void OnIsHover()
        {
            IsHover?.Invoke(this);
        }
        
        protected virtual void OnMyMouseLeave()
        {
            MyMouseLeave?.Invoke(this);
        }

        protected virtual void OnIsDoubleClick()
        {
            IsDoubleClick?.Invoke(this, DriveName);
        }

        public TypeFile TypeFile { private set; get; }
        public string DriveName { private set; get; }
        Graphics paint;
        Pen pen = new Pen(Color.LightSkyBlue);

        public Cloud.CloudFile File;

        bool Bool_IsClick = false;
        bool mousein = false;
        
        public void Rename(string name, float font_size = 8.25f)
        {
            Font font = new Font(Label_Text.Font.FontFamily, font_size);
            Label_Text.Font = font;

            DriveName = name;
            Label_Text.Text = "";
            int start_y = this.Size.Height - Icon.Height - 4;
            int start_x = 2;

            int end_x = this.Size.Width - 2;
            int end_y = this.Size.Height - 2;

            int middle_x = end_x - start_x;
            int middle_y = end_y - start_y;

            string buffer = "";
            foreach (var r in DriveName)
            {
                Label_Text.Text += r;
                
                if (Label_Text.Size.Width > 100)
                {
                    buffer += Environment.NewLine + r;
                    Label_Text.Text = buffer;

                }
                else
                {
                    buffer += r;
                    Label_Text.Text = buffer;
                }
            }

            if (Label_Text.Size.Height > 24)
            {
                Rename(DriveName, font_size - 0.5f);
            }
        }

        public FolderNFile(Cloud.CloudFile name, TypeFile typeFile)
        { 
            InitializeComponent();
            Rename(name.Title);
            File = name;
            DriveName = name.DriveID;
            this.TypeFile = typeFile;

            switch (TypeFile)
            {
                case TypeFile.Drive:
                    this.Icon.Image = Resources.DriveImage;
                    break;
                case TypeFile.Folder:
                    this.Icon.Image = Resources.FoldImage;

                    break;

                case TypeFile.UnknownFile:
                    this.Icon.Image = Resources.FileImage;
                    break;
            }

            paint = this.CreateGraphics();
            pen.Width = 1;
        }

        public FolderNFile(string name, TypeFile typeFile)
        {
            InitializeComponent();
            Rename(name);

            File = null;
            DriveName = name;
            this.TypeFile = typeFile;

            switch (TypeFile)
            {
                case TypeFile.Drive:
                    this.Icon.Image = Resources.DriveImage;
                    break;
                case TypeFile.Folder:
                    this.Icon.Image = Resources.FoldImage;

                    break;

                case TypeFile.UnknownFile:
                    this.Icon.Image = Resources.FileImage;
                    break;
            }

            paint = this.CreateGraphics();
            pen.Width = 1;
        }
        /// <summary>
        /// listFile에서 해당 자료가 클릭되었는 유무를 나타냅니다.
        /// </summary>
        /// <returns>리턴 : 클릭됨, 안됨.</returns>
        public bool IsClick()
        {
            return Bool_IsClick;
        }

        #region 마우스가 해당 아이콘에 들어올시 겉부분의 직사각형이 만들어지는 코드.
        private void Icon_MouseEnter(object sender, EventArgs e)
        {
            mousein = true;
            paint.DrawRectangle(pen, 0,0, this.Size.Width - pen.Width, this.Height - pen.Width );
        }
        private void Icon_MouseLeave(object sender, EventArgs e)
        {
            mousein = false;
            this.Refresh();
            OnMyMouseLeave();
        }
        #endregion


        /// <summary>
        /// 외부에서 다른 것을 클릭했을때 나타납니다.
        /// </summary>
        public void Command()
        {
            Bool_IsClick = false;
            this.BackColor = Color.Transparent;
            this.Refresh();
        }


        

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            if (mousein)
            {
                Icon_MouseEnter(new object(), new EventArgs());
            }
        }


        #region 해당 프로그램이 움직이는 기능입니다. + 클릭하였을때 색깔이 바뀌는 기능 또한 포함되어 있습니다.
        private Point mCurrentPosition = new Point(0, 0);
        private void Icon_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 현재위치
                // mCurrentPosition + e
                // 패널위치 + 패널사이즈 < 큰 패널 사이즈
                this.Location = new Point(
                    this.Location.X + (mCurrentPosition.X + e.X),
                    this.Location.Y + (mCurrentPosition.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.

            }
        }
        private void Icon_MouseDown(object sender, MouseEventArgs e)
        {
            this.BringToFront();
            if (e.Button == MouseButtons.Left)
            {
                mCurrentPosition = new Point(-e.X, -e.Y);
            }
            this.BackColor = Color.Gainsboro;
        }
        private void Icon_MouseUp(object sender, MouseEventArgs e)
        {
            Bool_IsClick = true;
            this.BackColor = Color.GhostWhite;

        }
        #endregion

        private void Icon_DoubleClick(object sender, EventArgs e)
        {
            OnIsDoubleClick();
        }

        private void Label_Text_Click(object sender, EventArgs e)
        {

        }

        private void Icon_MouseHover(object sender, EventArgs e)
        {
            OnIsHover();
        }

        private void FolderNFile_Leave(object sender, EventArgs e)
        {
            
            OnMyMouseLeave();
        }
    }
}


