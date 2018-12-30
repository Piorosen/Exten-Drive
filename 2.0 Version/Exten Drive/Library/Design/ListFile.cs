using Library.Cloud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using Exten_Drive;
using Library.File;
using System.Numerics;

namespace Library.Design
{

    class ListFile
    {

        MainForm _mainform;

        public Dictionary<string, RaidSystem> listRaidSystem = new Dictionary<string, RaidSystem>();
        private Dictionary<string, FolderNFile> folder = new Dictionary<string, FolderNFile>();
        private List<FolderNFile> fileList = new List<FolderNFile>();
        private List<FolderNFile> folderList = new List<FolderNFile>();


        public string TaskHardID = null;


        public ListFile(MainForm mainForm)
        {
            _mainform = mainForm;

            DirectoryInfo di = new DirectoryInfo(Global.DriveHard);
            if (!di.Exists)
            {
                di.Create();
            }
            FileInfo[] Fi = di.GetFiles();

            foreach (var f in Fi)
            {
                listRaidSystem[f.Name] = new Cloud.RaidSystem(f.Name);
            }
#if DEBUG
            Log.FileWrite("ListFile : ListFile : OK", Error.Success);
#endif
        }

        #region Draw
        /// <summary>
        /// listRaidSystem객체 안에 있는 모든 RaidSystem에 있는 모든 값을 FolderNFile로 변환한뒤 유저에게 보여주는 메소드입니다.
        /// </summary>
        /// <returns>본 출력이 제대로 되었는가에 대한 리턴입니다.</returns>
        public Error DrawRaidSystem()
        {
            foreach (var p in folderList)
            {
                p.Dispose();
            }
            foreach (var p in fileList)
            {
                p.Dispose();
            }
            folderList.Clear();
            fileList.Clear();

            int i = 0;
            foreach (string str in listRaidSystem.Keys)
            {
                try
                {
                    if (folder[str].IsDisposed)
                    {
                        folder.Remove(str);
                    }
                    else
                    {
                        folder[str].Visible = true;
                        folder[str].Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                            i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                    }
                }
                catch (Exception)
                {
                    FolderNFile f = new FolderNFile(str, TypeFile.Drive);
                    f.Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                        i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                    f.IsHover += FNF_Hover;
                    f.MyMouseLeave += FNF_Leave;
                    
                    f.IsDoubleClick += FNF_DoubleClick;

                    _mainform.Tab_Explorer.Controls.Add(f);
                    folder[str] = f;
                }
                i++;
            }
            return Error.Success;
        }
        /// <summary>
        /// 파일 목록들을 다시 그립니다. (FileList를 RePaint하는 역활입니다.)
        /// </summary>
        /// <returns>본 출력이 제대로 되었는가에 대한 리턴입니다.</returns>
        public Error DrawFileList()
        {
            int i = 0;
            foreach (var file in folderList)
            {
                file.Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                            i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                _mainform.Tab_Explorer.Controls.Add(file);
                i++;
            }
            foreach (var file in fileList)
            {
                file.Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                            i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                _mainform.Tab_Explorer.Controls.Add(file);
                i++;
            }
            return Error.Success;
        }

        /// <summary>
        /// 파일 목록들을 그립니다.
        /// </summary>
        /// <param name="HardID">TaskHardID와 동일 합니다.</param>
        /// <param name="root">어떤 루트를 탐색할것인지 전달 받습니다. Root\ 필수.</param>
        /// <returns></returns>
        public Error DrawFileList(string HardID, string root = "Root")
        {
            foreach (var p in folderList)
            {
                p.Dispose();
            }
            foreach (var p in fileList)
            {
                p.Dispose();
            }

            foreach (var fold in folder.Values)
            {
                fold.Visible = false;
            }

            // 모든 자료들을 버립니다.
            fileList.Clear();
            folderList.Clear();

            // 모든 파일을 읽습니다.
            var list = listRaidSystem[HardID].GetFiles(root);

            // 모든 파일을 읽고 그 모든 파일들을 UI 화를 합니다.
            foreach (var file in list)
            {
                FolderNFile fnf = new FolderNFile(file,
                                        file.MimeType == Global.GoogleMimeTypeFolder
                                        ? TypeFile.Folder
                                        : TypeFile.UnknownFile);
                fnf.IsDoubleClick += FNF_DoubleClick;
                fnf.IsHover += FNF_Hover;
                fnf.MyMouseLeave += FNF_Leave;
                if (file.MimeType == Global.GoogleMimeTypeFolder)
                {
                    folderList.Add(fnf);
                }
                else
                {
                    fileList.Add(fnf);
                }
            }

            int i = 0;
            foreach (var file in folderList)
            {
                file.Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                           i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                _mainform.Tab_Explorer.Controls.Add(file);
                i++;
            }
            foreach (var file in fileList)
            {
                file.Location = new Point(i % (_mainform.Tab_Explorer.Size.Width / 120) * 115 + 10,
                                           i / (_mainform.Tab_Explorer.Width / 120) * 150 + 10);
                _mainform.Tab_Explorer.Controls.Add(file);
                i++;
            }

#if DEBUG
            Log.FileWrite("ListFile : DrawFileList : OK", Error.Success);
#endif
            return Error.Success;
        }

        private void FNF_Leave(object sender)
        {
        }
        #endregion

        private void FNF_Hover(object sender)
        {
            FolderNFile f = sender as FolderNFile;
            Point pt = new Point(f.Location.X + (f.Size.Width / 2), f.Location.Y + (f.Size.Width / 2));

            if (TypeFile.UnknownFile == f.TypeFile)
            {
                if (_mainform.Chk_FileInfo.Checked)
                {
                    if (pt.X + _mainform.Panel_Info.Size.Width + 5 >= _mainform.Tab_Explorer.Size.Width)
                    {
                        pt.X -= _mainform.Panel_Info.Size.Width;
                    }
                    if (pt.Y + _mainform.Panel_Info.Size.Height + 5 >= _mainform.Tab_Explorer.Size.Height)
                    {
                        pt.Y -= _mainform.Panel_Info.Size.Height;
                    }

                    _mainform.Label_Capcity.Text = "Capacity : " + CapacityManage.Change(f.File.Size);
                    _mainform.Label_DriveName.Text = "Title : " + f.File.Title;
                    _mainform.Label_Ineer.Text = "Develop";
                    _mainform.Panel_Info.Location = pt;
                    _mainform.Panel_Info.Visible = true;
                }
                
            }
            else if (f.TypeFile == TypeFile.Drive)
            {
                if (_mainform.Chk_DriveInfo.Checked)
                {
                    if (pt.X + _mainform.Panel_DriveList.Size.Width + 5 >= _mainform.Tab_Explorer.Size.Width)
                    {
                        pt.X -= _mainform.Panel_DriveList.Size.Width;
                    }
                    if (pt.Y + _mainform.Panel_DriveList.Size.Height + 5 >= _mainform.Tab_Explorer.Size.Height)
                    {
                        pt.Y -= _mainform.Panel_DriveList.Size.Height;
                    }

                    _mainform.Panel_DriveList.Location = pt;
                    var a = _mainform.Panel_DriveList.CreateGraphics();
                    Size s;
                    Rectangle r1 = new Rectangle(_mainform.ListView_DriveList.Location.X, 15, _mainform.ListView_DriveList.Size.Width - 33, 30);

                    BigInteger? Use = listRaidSystem[f.DriveName].CapacityUse;
                    BigInteger? Total = listRaidSystem[f.DriveName].Capacity;

                    if (Use == 0 || Total == 0)
                    {
                        s = new Size(0, 0);
                    }
                    else
                    {
                        int data = (int)((Use * 100) / Total);
                        s = new Size((data * _mainform.ListView_DriveList.Size.Width) / 100 - 33, 30);

                    }


                    Rectangle r2 = new Rectangle(new Point(_mainform.ListView_DriveList.Location.X, 15), s);
                    Rectangle[] ali = { r1, r2 };

                    _mainform.Panel_DriveList.Visible = true;

                    a.FillRectangle(Brushes.Gray, r1);
                    a.FillRectangle(Brushes.LightBlue, r2);
                    a.DrawRectangles(Pens.Black, ali);


                    _mainform.ListView_DriveList.Items.Clear();
                    foreach (Drive list in listRaidSystem[f.DriveName].GetAccount().Values)
                    {
                        var items = new[] { list.DriveName, list.DriveID, CapacityManage.Change(list.Capacity), CapacityManage.Change(list.CapacityUse) };
                        var item = new ListViewItem(items);
                        _mainform.ListView_DriveList.Items.Add(item);
                    }
                }
            }
        }

        private void FNF_DoubleClick(object sender, string DriveName)
        {
            _mainform.Panel_Info.Visible = false;
            _mainform.Panel_DriveList.Visible = false;

            var t = (sender as FolderNFile);
            if (t.TypeFile == TypeFile.Drive)
            {
                _mainform.Text_Path.Text = "Root\\";
                string s = _mainform.Text_Path.Text.TrimEnd('\\');
                DrawFileList(DriveName, s);
                TaskHardID = DriveName;
                _mainform.Tab_Explorer.ContextMenuStrip = _mainform.Menu_FileManage;
            }
            else if (t.TypeFile == TypeFile.Folder)
            {
                _mainform.Text_Path.Text += t.File.Title + "\\";
                string s = _mainform.Text_Path.Text.TrimEnd('\\');
                DrawFileList(TaskHardID, s);
            }
            else
            {
                if (MessageBox.Show("정말로 다운로드 하시겠습니까?", "다운로드?", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    if (_mainform.DownloadFolderDialog.ShowDialog() == DialogResult.OK)
                    {
                        listRaidSystem[TaskHardID].Download(t.File, _mainform.DownloadFolderDialog.SelectedPath);
                    }
                    
                }
            }
#if DEBUG
            Log.FileWrite("ListFile : FNF_DoubleClick : OK", Error.Success);
#endif
        }


        public Error RaidSystemAdd(RaidSystem raidSystem)
        {

            listRaidSystem.Add(raidSystem.HardID, raidSystem);
            raidSystem.CreateHard(raidSystem.HardID, null);
            DrawRaidSystem();
#if DEBUG
            Log.FileWrite("ListFile : RaidSystemAdd : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error RaidSystemDelete(string raidSystem)
        {
            listRaidSystem.Remove(raidSystem);
            folder[raidSystem].Dispose();
            FileInfo info = new FileInfo(Global.DriveHard + raidSystem);
            if (info.Exists)
            {
                info.Delete();
            }
            DrawRaidSystem();
#if DEBUG
            Log.FileWrite("ListFile : RaidSystemDelete : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error RaidSystemRename(string raidSystem, string rename)
        {
            listRaidSystem[raidSystem].RenameHard(rename);
            folder[raidSystem].Rename(rename);

            listRaidSystem[rename] = listRaidSystem[raidSystem];
            folder[rename] = folder[raidSystem];

            listRaidSystem.Remove(raidSystem);
            folder.Remove(raidSystem);
#if DEBUG
            Log.FileWrite("ListFile : RaidSystemRemove : OK", Error.Success);
#endif
            return Error.Success;
        }


        public Error CloudServiceUpload(string path, string upload)
        {
            listRaidSystem[TaskHardID].Upload(path.TrimEnd('\\'), upload);
            DrawFileList(TaskHardID, upload.TrimEnd('\\'));
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceUpload : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServiceDownload(string path)
        {
            foreach (var file in fileList)
            {
                if (file.IsClick() && file.File.MimeType != Global.GoogleMimeTypeFolder)
                {
                    listRaidSystem[TaskHardID].Download(file.File, path);
                }
            }
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceDownload : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServiceFolderCreate(string path)
        {
            listRaidSystem[TaskHardID].FolderCreate(path);
            string[] str = path.Split('\\');
            string _path = "Root";
            for (int i = 1; i < str.Length - 1; i++)
            {
                _path += '\\' + str[i];
            }
            DrawFileList(TaskHardID, _path);
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceFolderCreate : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServiceDelete()
        {
            List<CloudFile> list = new List<CloudFile>();

            foreach (var r in fileList)
            {
                if (r.IsClick())
                {
                    list.Add(r.File);
                }
            }

            foreach (var r in folderList)
            {
                if (r.IsClick())
                {
                    list.Add(r.File);
                }
            }

            listRaidSystem[TaskHardID].Delete(list, _mainform.Text_Path.Text);
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceDelete : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServiceCopy()
        {
            list = new List<CloudFile>();
            IsCopy = true;
            prevPath = "";
            foreach (var r in fileList)
            {
                if (r.IsClick())
                {
                    list.Add(r.File);
                }
            }
            foreach (var r in folderList)
            {
                if (r.IsClick())
                {
                    list.Add(r.File);
                }
            }
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceCopy : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServiceRename(CloudFile file, string rename, string Path)
        {
            Error e = listRaidSystem[TaskHardID].ReName(file, rename, Path);
            DrawFileList(TaskHardID, Path.TrimEnd('\\'));
            return e;
        }


        private List<CloudFile> list = new List<CloudFile>();
        private bool IsCopy = false;
        private string prevPath = "";

        public Error CloudServiceMove()
        {
            list = new List<CloudFile>();
            IsCopy = false;
            prevPath = _mainform.Text_Path.Text;

            foreach (var f in fileList)
            {
                if (f.IsClick())
                {
                    list.Add(f.File);
                }
            }
            foreach (var f in folderList)
            {
                if (f.IsClick())
                {
                    list.Add(f.File);
                }
            }
#if DEBUG
            Log.FileWrite("ListFile : CloudServiceMove : OK", Error.Success);
#endif
            return Error.Success;
        }
        public Error CloudServicePaste()
        {
            if (IsCopy)
            {
                listRaidSystem[TaskHardID].Copy(list, _mainform.Text_Path.Text.TrimEnd('\\'));
            }
            else
            {
                listRaidSystem[TaskHardID].Move(list, _mainform.Text_Path.Text.TrimEnd('\\'), prevPath);
            }
            DrawFileList(TaskHardID, _mainform.Text_Path.Text.TrimEnd('\\'));
#if DEBUG
            Log.FileWrite("ListFile : CloudServicePaste : OK", Error.Success);
#endif
            return Error.Success;
        }

        public Error CloudServiceCancel()
        {
            list.Clear();
            return Error.Success;
        }


        public string CloudServiceShare()
        {
            var list = SelectFileList();
            var File = list[0];
            listRaidSystem[TaskHardID].ShareFile(File);

            return "";
        }

        public List<string> SelectHardID() 
        {
            List<string> list = new List<string>();
            foreach (var fold in folder)
            {
                if (folder[fold.Key].IsClick()) { list.Add(fold.Key); }
            }
#if DEBUG
            Log.FileWrite("ListFile : SelectHard : OK", Error.Success);
#endif
            return list;
        }        
        public List<CloudFile> SelectFileList()
        {
            List<CloudFile> list = new List<CloudFile>();

            foreach (var i in fileList)
            {
                if (i.IsClick())
                {
                    list.Add(i.File);
                }
            }
            foreach (var i in folderList)
            {
                if (i.IsClick())
                {
                    list.Add(i.File);
                }
            }
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        public Error ClearSqure()
        {
            foreach (FolderNFile str in folder.Values) 
            {
                str.Command();
            }
            foreach (FolderNFile str in folderList)
            {
                str.Command();
            }
            foreach (FolderNFile str in fileList)
            {
                str.Command();
            }
#if DEBUG
            Log.FileWrite("ListFile : ClearSqure : OK", Error.Success);
#endif
            return Error.Success;
        }


    }
}