using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Cloud;
using MaterialSkin;
using Library.Design;
using System.Collections;
using System.IO;
using Library.File;
using Library;

namespace Exten_Drive
{
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            StringBuilder stringBuilder = new StringBuilder(256);
            Library.File.Config.GetPrivateProfileString("Design", "MainFormColor", "0", stringBuilder, 256, Library.Global.DriveOption + "Options.ini");
            
            if (!int.TryParse(stringBuilder.ToString(), out colorSchemeIndex))
            {
                colorSchemeIndex = 0;
            }

            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }

            bool chk;

            Library.File.Config.GetPrivateProfileString("Function", "UseFileInfo", "0", stringBuilder, 256, Library.Global.DriveOption + "Options.ini");
            if (!bool.TryParse(stringBuilder.ToString(), out chk))
            {
                chk = true;
            }
            Chk_FileInfo.Checked = chk;

            Library.File.Config.GetPrivateProfileString("Function", "UseDriveInfo", "0", stringBuilder, 256, Library.Global.DriveOption + "Options.ini");
            if (!bool.TryParse(stringBuilder.ToString(), out chk))
            {
                chk = true;
            }
            Chk_DriveInfo.Checked = chk;


            listFile = new ListFile(this);
            listFile.DrawRaidSystem();
#if DEBUG
            Log.FileWrite("MainForm : MainForm : 실행", Error.Success);
#endif
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Library.Global.DriveOption);
            if (!di.Exists)
            {
                di.Create();
            }
            Library.File.Config.WritePrivateProfileString("Design", "MainFormColor", colorSchemeIndex.ToString(), Library.Global.DriveOption + "Options.ini");
            Library.File.Config.WritePrivateProfileString("Function", "UseFileInfo", Chk_FileInfo.ToString(), Library.Global.DriveOption + "Options.ini");
            Library.File.Config.WritePrivateProfileString("Function", "UseDriveInfo", Chk_DriveInfo.ToString(), Library.Global.DriveOption + "Options.ini");
#if DEBUG
            Log.FileWrite("MainForm : FormClosing : 실행", Error.Success);
#endif
        }


        private void Tab_Explorer_Click(object sender, EventArgs e)
        {
            listFile.ClearSqure();
#if DEBUG
            Log.FileWrite("MainForm : Tab_Explorer_Click", Error.Success);
#endif
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2) colorSchemeIndex = 0;

            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
#if DEBUG
            Log.FileWrite("MainForm : ColorChange", Error.Success);
#endif
        }



        #region Panel Paint ( RaidAdd, CloudAdd, Raid Rename) and Panel Move
        private void Panel_RaidAdd_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            p.BringToFront();
            Pen pen = materialSkinManager.ColorScheme.PrimaryPen;
            pen.Width = 5;
            Graphics g = p.CreateGraphics();
            g.Clear(Color.GhostWhite);
            p.BackColor = Color.GhostWhite;
            g.DrawRectangle(pen, pen.Width / 2, pen.Width / 2, p.Size.Width - pen.Width, p.Size.Height - pen.Width);

        }

        private Point mCurrentPosition = new Point(0, 0);
        private void Panel_RaidAdd_MouseMove(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null)
            {

                Control w = sender as Control;
                p = w.Parent as Panel;
            }
            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point location = new Point(
                        p.Location.X + (mCurrentPosition.X + e.X),
                        p.Location.Y + (mCurrentPosition.Y + e.Y));// 마우스의 이동치를 Form Location에 반영한다.

                    // 현재위치
                    // mCurrentPosition + e
                    // 패널위치 + 패널사이즈 < 큰 패널 사이즈

                    if (location.X < 0)
                    {
                        location = new Point(0, location.Y);
                    }
                    if (location.Y < 0)
                    {
                        location = new Point(location.X, 0);
                    }
                    if (location.Y + p.Size.Height > Tab_Explorer.Size.Height)
                    {
                        location = new Point(location.X, Tab_Explorer.Size.Height - p.Size.Height - 1);
                    }
                    if (location.X + p.Size.Width > Tab_Explorer.Size.Width)
                    {

                        location = new Point(Tab_Explorer.Size.Width - p.Size.Width - 1, location.Y);
                    }

                    p.Location = location;
                }
            }
        }

        private void Panel_RaidAdd_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mCurrentPosition = new Point(-e.X, -e.Y);
            }
        }
        #endregion

        #region RAIDSYSTEMCREATE AND RAIDADD
        private void Panel_RaidAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BTN_RaidSystemCreate.PerformClick();
            }
        }

        private void TXT_CreateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Btn_CreateFolderOK.PerformClick();
            }
        }

        ListFile listFile;
        bool isRaid = false;
        private void Menu_Panel_RaidSystemCreate_Click(object sender, EventArgs e)
        {
            Panel_RaidAdd.BringToFront();
            Rabel_Nothing1.Text = "Raid System Name : ";
            isRaid = true;
            BringToFront();
            this.Panel_RaidAdd.Visible = true;
            TXT_RaidAdd_Input.Focus();
        }

        private void Menu_Panel_CloudServiceAddGoogleDrive_Click(object sender, EventArgs e)
        {
            Panel_RaidAdd.BringToFront();
            isRaid = false;
            Rabel_Nothing1.Text = "Cloud System Name : ";
            this.Panel_RaidAdd.Visible = true;
            TXT_RaidAdd_Input.Focus();
        }

        private void folderCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel_CreateFolder.BringToFront();
            Panel_CreateFolder.Visible = true;
            TXT_CreateName.Focus();
        }

        private void BTN_RaidSystemCreate_Click(object sender, EventArgs e)
        {
            if (isRaid)
            {
                RaidSystem r = new RaidSystem(TXT_RaidAdd_Input.Text);
                listFile.RaidSystemAdd(r);
#if DEBUG
                Log.FileWrite("MainForm : BTN_RaidSystemCreate_OK", Error.Success);
#endif
            }
            else
            {
                listFile.listRaidSystem[listFile.SelectHardID()[0]].AddAccount(TXT_RaidAdd_Input.Text, Library.Global.Cloud.GoogleDrive);
#if DEBUG
                Log.FileWrite("MainForm : BTN_CloudServiceCreate_OK", Error.Success);
#endif
            }
            this.TXT_RaidAdd_Input.Text = "";
            this.Panel_RaidAdd.Visible = false;
        }
        #endregion


        #region RaidSystem Rename
        private void Menu_Panel_RaidSystemRename_Click(object sender, EventArgs e)
        {
            IsRaidRename = true;
            var str = listFile.SelectHardID();
            
            if (str.Count != 0)
            {
                string s = str[0];
                Label_RenameNowName.Text = "Now : " + s;
                Panel_Rename.BringToFront();
                Panel_Rename.Visible = true;
                TXT_Rename.Focus();
            }
            else
            {
                MessageBox.Show("선택을 하지않으셨습니다.", "Error");
            }
#if DEBUG
            Log.FileWrite("MainForm : RaidSystemRename_OK", Error.Success);
#endif
        }

        private void Btn_Rename_Click(object sender, EventArgs e)
        {
            if (IsRaidRename)
            {
                Panel_Rename.Visible = false;
                listFile.RaidSystemRename(listFile.SelectHardID()[0], TXT_Rename.Text);
#if DEBUG
                Log.FileWrite("MainForm : BTN_Rename_OK", Error.Success);
#endif
            }
            else
            {
                Panel_Rename.Visible = false;
                listFile.CloudServiceRename(listFile.SelectFileList()[0], TXT_Rename.Text, Text_Path.Text);
#if DEBUG
                Log.FileWrite("MainForm : BTN_Rename_OK", Error.Success);
#endif
            }
        }

        bool IsRaidRename = false;
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var list =  listFile.SelectFileList();
            IsRaidRename = false;
            if (list.Count != 0)
            {
                string s = list[0].Title;
                TXT_Rename.Text = "";
                Label_RenameNowName.Text = "Now : " + s;
                Panel_Rename.BringToFront();
                Panel_Rename.Visible = true;
                TXT_Rename.Focus();
            }
            else
            {
                MessageBox.Show("선택을 하지않으셨습니다.", "Error");
            }
#if DEBUG
            Log.FileWrite("MainForm : renameContextToolStrip", Error.Success);
#endif
        }
        private void Btn_RaidSystemDown_Click(object sender, EventArgs e)
        {
            this.TXT_RaidAdd_Input.Text = "";
            this.Panel_RaidAdd.Visible = false;
        }
        private void Btn_RenameDown_Click(object sender, EventArgs e)
        {
            this.TXT_Rename.Text = "";
            this.Panel_Rename.Visible = false;
        }
        private void TXT_Rename_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Btn_Rename.PerformClick();
            }
        }

        #endregion

        #region CloudService FolderCreate

        private void Btn_CreateFolderDown_Click(object sender, EventArgs e)
        {
            Panel_CreateFolder.Visible = false;
            TXT_CreateName.Text = "";
        }


        private void Btn_CreateFolderOK_Click(object sender, EventArgs e)
        {
            listFile.CloudServiceFolderCreate(Text_Path.Text + TXT_CreateName.Text);
            Panel_CreateFolder.Visible = false;
#if DEBUG
            Log.FileWrite("MainForm : BTN_CreateFolder_OK", Error.Success);
#endif
        }



        #endregion

        private void Menu_Panel_RaidSystemDelete_Click(object sender, EventArgs e)
        {
            var list = listFile.SelectHardID();
            foreach (string str in list)
            {
                listFile.RaidSystemDelete(str);
            }
        }

        #region Paint
        
        
        private void OutsidePaint(object sender, PaintEventArgs e)
        {
            
            var control = sender as Control;
            var graphic = control.CreateGraphics();
            graphic.Clear(Color.White);
            Pen pen = materialSkinManager.ColorScheme.PrimaryPen;
            pen.Width = 5;
            
            graphic.DrawRectangle(pen, pen.Width / 2, pen.Width * (-1), control.Width - pen.Width, control.Size.Height + pen.Width / 2);
           
        }


        #endregion


        private static int TABSize = 0;
        private void Tab_Explorer_SizeChanged(object sender, EventArgs e)
        {
            if (Text_Path.Text != "RaidList\\")
            {
                int now = Tab_Explorer.Size.Width / 120;
                if (TABSize != now)
                {
                    TABSize = Tab_Explorer.Size.Width / 120;
                    listFile.DrawFileList();
                }
            }
        }



        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            
            if (Text_Path.Text == "RaidList\\")
            {

            }
            else if (Text_Path.Text == "Root\\" || Text_Path.Text == "Root")
            {
                Tab_Explorer.ContextMenuStrip = Menu_Panel;
                listFile.TaskHardID = null;
                Text_Path.Text = "RaidList\\";
                listFile.DrawRaidSystem();
                cancelToolStripMenuItem.PerformClick();
                Panel_RaidAdd.Visible = false;
                Panel_CreateFolder.Visible = false;
                Panel_Rename.Visible = false;

            }
            else
            {
                string p = Text_Path.Text.TrimEnd('\\');
                String[] k = p.Split('\\');
                Text_Path.Text = "Root\\";
                for (int i = 1; i < k.Length - 1; i++)
                {
                    Text_Path.Text += k[i] + @"\";
                }
                p = Text_Path.Text.TrimEnd('\\');
                listFile.DrawFileList(listFile.TaskHardID, p);
            }
        }
       

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (uploadFileDialog.ShowDialog() == DialogResult.OK)
            {
                var list = uploadFileDialog.FileNames;
                foreach (string filePath in list)
                {
                    listFile.CloudServiceUpload(filePath, Text_Path.Text.TrimEnd('\\'));
                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DownloadFolderDialog.ShowDialog() == DialogResult.OK)
            {
                listFile.CloudServiceDownload(DownloadFolderDialog.SelectedPath);
            }
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.moveToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Enabled = false;

            listFile.CloudServiceMove();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.moveToolStripMenuItem.Enabled = true;
            this.copyToolStripMenuItem.Enabled = true;
            this.deleteToolStripMenuItem.Enabled = true;
            this.renameToolStripMenuItem.Enabled = true;
            listFile.CloudServicePaste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listFile.CloudServiceDelete();
            listFile.DrawFileList(listFile.TaskHardID, Text_Path.Text.TrimEnd('\\'));
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.moveToolStripMenuItem.Enabled = false;
            this.copyToolStripMenuItem.Enabled = false;
            this.deleteToolStripMenuItem.Enabled = false;
            this.renameToolStripMenuItem.Enabled = false;
            listFile.CloudServiceCopy();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.moveToolStripMenuItem.Enabled = true;
            this.copyToolStripMenuItem.Enabled = true;
            this.deleteToolStripMenuItem.Enabled = true;
            this.renameToolStripMenuItem.Enabled = true;
            listFile.CloudServiceCancel();  
        }

        private void shareToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string str = listFile.CloudServiceShare();
        }

        private void Btn_InfoDown_Click(object sender, EventArgs e)
        {
            Panel_Info.Visible = false;
        }

        private void Btn_DriveListDown_Click(object sender, EventArgs e)
        {
            Panel_DriveList.Visible = false;
        }
    }
}