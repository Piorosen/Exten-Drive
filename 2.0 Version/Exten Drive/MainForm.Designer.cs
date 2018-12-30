namespace Exten_Drive
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tab_Selector = new MaterialSkin.Controls.MaterialTabSelector();
            this.Tab_Control = new MaterialSkin.Controls.MaterialTabControl();
            this.Tab_Explorer = new System.Windows.Forms.TabPage();
            this.Menu_Panel = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.Menu_Panel_RaidSystemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Panel_RaidSystemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Panel_RaidSystemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Panel_CloudServiceAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Panel_CloudServiceAddGoogleDrive = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_CreateFolder = new System.Windows.Forms.Panel();
            this.Btn_CreateFolderDown = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Btn_CreateFolderOK = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TXT_CreateName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.Panel_Rename = new System.Windows.Forms.Panel();
            this.Label_RenameNowName = new MaterialSkin.Controls.MaterialLabel();
            this.Btn_RenameDown = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Btn_Rename = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TXT_Rename = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.Panel_RaidAdd = new System.Windows.Forms.Panel();
            this.Btn_RaidSystemDown = new MaterialSkin.Controls.MaterialRaisedButton();
            this.BTN_RaidSystemCreate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.TXT_RaidAdd_Input = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.Rabel_Nothing1 = new MaterialSkin.Controls.MaterialLabel();
            this.Tab_Option = new System.Windows.Forms.TabPage();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.uploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatLabel_SelNCap = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatLabel_Slash = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatLabel_AllFileNum = new System.Windows.Forms.ToolStripStatusLabel();
            this.Text_Path = new MaterialSkin.Controls.MaterialLabel();
            this.Btn_Prev = new MaterialSkin.Controls.MaterialFlatButton();
            this.DownloadFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_FileManage = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel_Info = new System.Windows.Forms.Panel();
            this.Label_DriveName = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Ineer = new MaterialSkin.Controls.MaterialLabel();
            this.Label_Capcity = new MaterialSkin.Controls.MaterialLabel();
            this.Btn_InfoDown = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Panel_DriveList = new System.Windows.Forms.Panel();
            this.ListView_DriveList = new MaterialSkin.Controls.MaterialListView();
            this.Collum_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Use = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Btn_DriveListDown = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Chk_FileInfo = new MaterialSkin.Controls.MaterialCheckBox();
            this.Chk_DriveInfo = new MaterialSkin.Controls.MaterialCheckBox();
            this.Tab_Control.SuspendLayout();
            this.Tab_Explorer.SuspendLayout();
            this.Menu_Panel.SuspendLayout();
            this.Panel_CreateFolder.SuspendLayout();
            this.Panel_Rename.SuspendLayout();
            this.Panel_RaidAdd.SuspendLayout();
            this.Tab_Option.SuspendLayout();
            this.Menu_FileManage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Panel_Info.SuspendLayout();
            this.Panel_DriveList.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tab_Selector
            // 
            this.Tab_Selector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Selector.BaseTabControl = this.Tab_Control;
            this.Tab_Selector.Depth = 0;
            this.Tab_Selector.Location = new System.Drawing.Point(0, 51);
            this.Tab_Selector.MouseState = MaterialSkin.MouseState.HOVER;
            this.Tab_Selector.Name = "Tab_Selector";
            this.Tab_Selector.Size = new System.Drawing.Size(800, 42);
            this.Tab_Selector.TabIndex = 1;
            this.Tab_Selector.Text = "materialTabSelector1";
            // 
            // Tab_Control
            // 
            this.Tab_Control.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Control.Controls.Add(this.Tab_Explorer);
            this.Tab_Control.Controls.Add(this.Tab_Option);
            this.Tab_Control.Depth = 0;
            this.Tab_Control.Location = new System.Drawing.Point(9, 48);
            this.Tab_Control.Margin = new System.Windows.Forms.Padding(0);
            this.Tab_Control.MouseState = MaterialSkin.MouseState.HOVER;
            this.Tab_Control.Name = "Tab_Control";
            this.Tab_Control.SelectedIndex = 0;
            this.Tab_Control.Size = new System.Drawing.Size(782, 386);
            this.Tab_Control.TabIndex = 2;
            // 
            // Tab_Explorer
            // 
            this.Tab_Explorer.AutoScroll = true;
            this.Tab_Explorer.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            this.Tab_Explorer.ContextMenuStrip = this.Menu_Panel;
            this.Tab_Explorer.Controls.Add(this.Panel_DriveList);
            this.Tab_Explorer.Controls.Add(this.Panel_Info);
            this.Tab_Explorer.Controls.Add(this.Panel_CreateFolder);
            this.Tab_Explorer.Controls.Add(this.Panel_Rename);
            this.Tab_Explorer.Controls.Add(this.Panel_RaidAdd);
            this.Tab_Explorer.Location = new System.Drawing.Point(4, 22);
            this.Tab_Explorer.Name = "Tab_Explorer";
            this.Tab_Explorer.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Explorer.Size = new System.Drawing.Size(774, 360);
            this.Tab_Explorer.TabIndex = 0;
            this.Tab_Explorer.Text = "Explorer";
            this.Tab_Explorer.UseVisualStyleBackColor = true;
            this.Tab_Explorer.SizeChanged += new System.EventHandler(this.Tab_Explorer_SizeChanged);
            this.Tab_Explorer.Click += new System.EventHandler(this.Tab_Explorer_Click);
            // 
            // Menu_Panel
            // 
            this.Menu_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_Panel.Depth = 0;
            this.Menu_Panel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu_Panel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Panel_RaidSystemCreate,
            this.Menu_Panel_RaidSystemDelete,
            this.Menu_Panel_RaidSystemRename,
            this.toolStripSeparator1,
            this.Menu_Panel_CloudServiceAdd});
            this.Menu_Panel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Menu_Panel.Name = "Menu_Panel";
            this.Menu_Panel.Size = new System.Drawing.Size(188, 98);
            // 
            // Menu_Panel_RaidSystemCreate
            // 
            this.Menu_Panel_RaidSystemCreate.Name = "Menu_Panel_RaidSystemCreate";
            this.Menu_Panel_RaidSystemCreate.Size = new System.Drawing.Size(187, 22);
            this.Menu_Panel_RaidSystemCreate.Text = "Raid System Create";
            this.Menu_Panel_RaidSystemCreate.Click += new System.EventHandler(this.Menu_Panel_RaidSystemCreate_Click);
            // 
            // Menu_Panel_RaidSystemDelete
            // 
            this.Menu_Panel_RaidSystemDelete.Name = "Menu_Panel_RaidSystemDelete";
            this.Menu_Panel_RaidSystemDelete.Size = new System.Drawing.Size(187, 22);
            this.Menu_Panel_RaidSystemDelete.Text = "Raid System Delete";
            this.Menu_Panel_RaidSystemDelete.Click += new System.EventHandler(this.Menu_Panel_RaidSystemDelete_Click);
            // 
            // Menu_Panel_RaidSystemRename
            // 
            this.Menu_Panel_RaidSystemRename.Name = "Menu_Panel_RaidSystemRename";
            this.Menu_Panel_RaidSystemRename.Size = new System.Drawing.Size(187, 22);
            this.Menu_Panel_RaidSystemRename.Text = "Raid System Rename";
            this.Menu_Panel_RaidSystemRename.Click += new System.EventHandler(this.Menu_Panel_RaidSystemRename_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // Menu_Panel_CloudServiceAdd
            // 
            this.Menu_Panel_CloudServiceAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Panel_CloudServiceAddGoogleDrive});
            this.Menu_Panel_CloudServiceAdd.Name = "Menu_Panel_CloudServiceAdd";
            this.Menu_Panel_CloudServiceAdd.Size = new System.Drawing.Size(187, 22);
            this.Menu_Panel_CloudServiceAdd.Text = "Cloud Service Add";
            // 
            // Menu_Panel_CloudServiceAddGoogleDrive
            // 
            this.Menu_Panel_CloudServiceAddGoogleDrive.Name = "Menu_Panel_CloudServiceAddGoogleDrive";
            this.Menu_Panel_CloudServiceAddGoogleDrive.Size = new System.Drawing.Size(180, 22);
            this.Menu_Panel_CloudServiceAddGoogleDrive.Text = "Google Drive";
            this.Menu_Panel_CloudServiceAddGoogleDrive.Click += new System.EventHandler(this.Menu_Panel_CloudServiceAddGoogleDrive_Click);
            // 
            // Panel_CreateFolder
            // 
            this.Panel_CreateFolder.BackColor = System.Drawing.Color.GhostWhite;
            this.Panel_CreateFolder.Controls.Add(this.Btn_CreateFolderDown);
            this.Panel_CreateFolder.Controls.Add(this.Btn_CreateFolderOK);
            this.Panel_CreateFolder.Controls.Add(this.TXT_CreateName);
            this.Panel_CreateFolder.Controls.Add(this.materialLabel3);
            this.Panel_CreateFolder.Location = new System.Drawing.Point(371, 222);
            this.Panel_CreateFolder.Name = "Panel_CreateFolder";
            this.Panel_CreateFolder.Size = new System.Drawing.Size(400, 102);
            this.Panel_CreateFolder.TabIndex = 5;
            this.Panel_CreateFolder.Visible = false;
            this.Panel_CreateFolder.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_RaidAdd_Paint);
            this.Panel_CreateFolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Panel_CreateFolder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Btn_CreateFolderDown
            // 
            this.Btn_CreateFolderDown.AutoSize = true;
            this.Btn_CreateFolderDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_CreateFolderDown.Depth = 0;
            this.Btn_CreateFolderDown.Icon = null;
            this.Btn_CreateFolderDown.Location = new System.Drawing.Point(350, 10);
            this.Btn_CreateFolderDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_CreateFolderDown.Name = "Btn_CreateFolderDown";
            this.Btn_CreateFolderDown.Primary = true;
            this.Btn_CreateFolderDown.Size = new System.Drawing.Size(30, 36);
            this.Btn_CreateFolderDown.TabIndex = 3;
            this.Btn_CreateFolderDown.Text = "X";
            this.Btn_CreateFolderDown.UseVisualStyleBackColor = true;
            this.Btn_CreateFolderDown.Click += new System.EventHandler(this.Btn_CreateFolderDown_Click);
            this.Btn_CreateFolderDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Btn_CreateFolderDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Btn_CreateFolderOK
            // 
            this.Btn_CreateFolderOK.AutoSize = true;
            this.Btn_CreateFolderOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_CreateFolderOK.Depth = 0;
            this.Btn_CreateFolderOK.Icon = null;
            this.Btn_CreateFolderOK.Location = new System.Drawing.Point(341, 52);
            this.Btn_CreateFolderOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_CreateFolderOK.Name = "Btn_CreateFolderOK";
            this.Btn_CreateFolderOK.Primary = true;
            this.Btn_CreateFolderOK.Size = new System.Drawing.Size(39, 36);
            this.Btn_CreateFolderOK.TabIndex = 2;
            this.Btn_CreateFolderOK.Text = "OK";
            this.Btn_CreateFolderOK.UseVisualStyleBackColor = true;
            this.Btn_CreateFolderOK.Click += new System.EventHandler(this.Btn_CreateFolderOK_Click);
            this.Btn_CreateFolderOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Btn_CreateFolderOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // TXT_CreateName
            // 
            this.TXT_CreateName.Depth = 0;
            this.TXT_CreateName.Hint = "Create Name";
            this.TXT_CreateName.Location = new System.Drawing.Point(11, 65);
            this.TXT_CreateName.MaxLength = 32767;
            this.TXT_CreateName.MouseState = MaterialSkin.MouseState.HOVER;
            this.TXT_CreateName.Name = "TXT_CreateName";
            this.TXT_CreateName.PasswordChar = '\0';
            this.TXT_CreateName.SelectedText = "";
            this.TXT_CreateName.SelectionLength = 0;
            this.TXT_CreateName.SelectionStart = 0;
            this.TXT_CreateName.Size = new System.Drawing.Size(324, 23);
            this.TXT_CreateName.TabIndex = 1;
            this.TXT_CreateName.TabStop = false;
            this.TXT_CreateName.UseSystemPasswordChar = false;
            this.TXT_CreateName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_CreateName_KeyPress);
            this.TXT_CreateName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.TXT_CreateName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(7, 17);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(61, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Name : ";
            this.materialLabel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.materialLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Panel_Rename
            // 
            this.Panel_Rename.BackColor = System.Drawing.Color.GhostWhite;
            this.Panel_Rename.Controls.Add(this.Label_RenameNowName);
            this.Panel_Rename.Controls.Add(this.Btn_RenameDown);
            this.Panel_Rename.Controls.Add(this.Btn_Rename);
            this.Panel_Rename.Controls.Add(this.TXT_Rename);
            this.Panel_Rename.Controls.Add(this.materialLabel1);
            this.Panel_Rename.Location = new System.Drawing.Point(368, 6);
            this.Panel_Rename.Name = "Panel_Rename";
            this.Panel_Rename.Size = new System.Drawing.Size(400, 102);
            this.Panel_Rename.TabIndex = 4;
            this.Panel_Rename.Visible = false;
            this.Panel_Rename.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_RaidAdd_Paint);
            this.Panel_Rename.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Panel_Rename.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Label_RenameNowName
            // 
            this.Label_RenameNowName.AutoSize = true;
            this.Label_RenameNowName.Depth = 0;
            this.Label_RenameNowName.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_RenameNowName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_RenameNowName.Location = new System.Drawing.Point(7, 39);
            this.Label_RenameNowName.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_RenameNowName.Name = "Label_RenameNowName";
            this.Label_RenameNowName.Size = new System.Drawing.Size(52, 19);
            this.Label_RenameNowName.TabIndex = 4;
            this.Label_RenameNowName.Text = "Now : ";
            this.Label_RenameNowName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Label_RenameNowName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Btn_RenameDown
            // 
            this.Btn_RenameDown.AutoSize = true;
            this.Btn_RenameDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_RenameDown.Depth = 0;
            this.Btn_RenameDown.Icon = null;
            this.Btn_RenameDown.Location = new System.Drawing.Point(350, 10);
            this.Btn_RenameDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_RenameDown.Name = "Btn_RenameDown";
            this.Btn_RenameDown.Primary = true;
            this.Btn_RenameDown.Size = new System.Drawing.Size(30, 36);
            this.Btn_RenameDown.TabIndex = 3;
            this.Btn_RenameDown.Text = "X";
            this.Btn_RenameDown.UseVisualStyleBackColor = true;
            this.Btn_RenameDown.Click += new System.EventHandler(this.Btn_RenameDown_Click);
            this.Btn_RenameDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Btn_RenameDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Btn_Rename
            // 
            this.Btn_Rename.AutoSize = true;
            this.Btn_Rename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_Rename.Depth = 0;
            this.Btn_Rename.Icon = null;
            this.Btn_Rename.Location = new System.Drawing.Point(341, 52);
            this.Btn_Rename.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_Rename.Name = "Btn_Rename";
            this.Btn_Rename.Primary = true;
            this.Btn_Rename.Size = new System.Drawing.Size(39, 36);
            this.Btn_Rename.TabIndex = 2;
            this.Btn_Rename.Text = "OK";
            this.Btn_Rename.UseVisualStyleBackColor = true;
            this.Btn_Rename.Click += new System.EventHandler(this.Btn_Rename_Click);
            this.Btn_Rename.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Btn_Rename.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // TXT_Rename
            // 
            this.TXT_Rename.Depth = 0;
            this.TXT_Rename.Hint = "Change Name";
            this.TXT_Rename.Location = new System.Drawing.Point(11, 68);
            this.TXT_Rename.MaxLength = 32767;
            this.TXT_Rename.MouseState = MaterialSkin.MouseState.HOVER;
            this.TXT_Rename.Name = "TXT_Rename";
            this.TXT_Rename.PasswordChar = '\0';
            this.TXT_Rename.SelectedText = "";
            this.TXT_Rename.SelectionLength = 0;
            this.TXT_Rename.SelectionStart = 0;
            this.TXT_Rename.Size = new System.Drawing.Size(324, 23);
            this.TXT_Rename.TabIndex = 1;
            this.TXT_Rename.TabStop = false;
            this.TXT_Rename.UseSystemPasswordChar = false;
            this.TXT_Rename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_Rename_KeyPress);
            this.TXT_Rename.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.TXT_Rename.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(7, 10);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(115, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Change Name : ";
            this.materialLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.materialLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Panel_RaidAdd
            // 
            this.Panel_RaidAdd.BackColor = System.Drawing.Color.GhostWhite;
            this.Panel_RaidAdd.Controls.Add(this.Btn_RaidSystemDown);
            this.Panel_RaidAdd.Controls.Add(this.BTN_RaidSystemCreate);
            this.Panel_RaidAdd.Controls.Add(this.TXT_RaidAdd_Input);
            this.Panel_RaidAdd.Controls.Add(this.Rabel_Nothing1);
            this.Panel_RaidAdd.Location = new System.Drawing.Point(371, 114);
            this.Panel_RaidAdd.Name = "Panel_RaidAdd";
            this.Panel_RaidAdd.Size = new System.Drawing.Size(400, 102);
            this.Panel_RaidAdd.TabIndex = 3;
            this.Panel_RaidAdd.Visible = false;
            this.Panel_RaidAdd.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_RaidAdd_Paint);
            this.Panel_RaidAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Panel_RaidAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Btn_RaidSystemDown
            // 
            this.Btn_RaidSystemDown.AutoSize = true;
            this.Btn_RaidSystemDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_RaidSystemDown.Depth = 0;
            this.Btn_RaidSystemDown.Icon = null;
            this.Btn_RaidSystemDown.Location = new System.Drawing.Point(350, 10);
            this.Btn_RaidSystemDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_RaidSystemDown.Name = "Btn_RaidSystemDown";
            this.Btn_RaidSystemDown.Primary = true;
            this.Btn_RaidSystemDown.Size = new System.Drawing.Size(30, 36);
            this.Btn_RaidSystemDown.TabIndex = 3;
            this.Btn_RaidSystemDown.Text = "X";
            this.Btn_RaidSystemDown.UseVisualStyleBackColor = true;
            this.Btn_RaidSystemDown.Click += new System.EventHandler(this.Btn_RaidSystemDown_Click);
            // 
            // BTN_RaidSystemCreate
            // 
            this.BTN_RaidSystemCreate.AutoSize = true;
            this.BTN_RaidSystemCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BTN_RaidSystemCreate.Depth = 0;
            this.BTN_RaidSystemCreate.Icon = null;
            this.BTN_RaidSystemCreate.Location = new System.Drawing.Point(309, 52);
            this.BTN_RaidSystemCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.BTN_RaidSystemCreate.Name = "BTN_RaidSystemCreate";
            this.BTN_RaidSystemCreate.Primary = true;
            this.BTN_RaidSystemCreate.Size = new System.Drawing.Size(71, 36);
            this.BTN_RaidSystemCreate.TabIndex = 2;
            this.BTN_RaidSystemCreate.Text = "Create";
            this.BTN_RaidSystemCreate.UseVisualStyleBackColor = true;
            this.BTN_RaidSystemCreate.Click += new System.EventHandler(this.BTN_RaidSystemCreate_Click);
            this.BTN_RaidSystemCreate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Panel_RaidAdd_KeyPress);
            this.BTN_RaidSystemCreate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.BTN_RaidSystemCreate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // TXT_RaidAdd_Input
            // 
            this.TXT_RaidAdd_Input.Depth = 0;
            this.TXT_RaidAdd_Input.Hint = "ex) Exten Drive";
            this.TXT_RaidAdd_Input.Location = new System.Drawing.Point(23, 65);
            this.TXT_RaidAdd_Input.MaxLength = 32767;
            this.TXT_RaidAdd_Input.MouseState = MaterialSkin.MouseState.HOVER;
            this.TXT_RaidAdd_Input.Name = "TXT_RaidAdd_Input";
            this.TXT_RaidAdd_Input.PasswordChar = '\0';
            this.TXT_RaidAdd_Input.SelectedText = "";
            this.TXT_RaidAdd_Input.SelectionLength = 0;
            this.TXT_RaidAdd_Input.SelectionStart = 0;
            this.TXT_RaidAdd_Input.Size = new System.Drawing.Size(280, 23);
            this.TXT_RaidAdd_Input.TabIndex = 1;
            this.TXT_RaidAdd_Input.TabStop = false;
            this.TXT_RaidAdd_Input.UseSystemPasswordChar = false;
            this.TXT_RaidAdd_Input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Panel_RaidAdd_KeyPress);
            this.TXT_RaidAdd_Input.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.TXT_RaidAdd_Input.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Rabel_Nothing1
            // 
            this.Rabel_Nothing1.AutoSize = true;
            this.Rabel_Nothing1.Depth = 0;
            this.Rabel_Nothing1.Font = new System.Drawing.Font("Roboto", 11F);
            this.Rabel_Nothing1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Rabel_Nothing1.Location = new System.Drawing.Point(19, 27);
            this.Rabel_Nothing1.MouseState = MaterialSkin.MouseState.HOVER;
            this.Rabel_Nothing1.Name = "Rabel_Nothing1";
            this.Rabel_Nothing1.Size = new System.Drawing.Size(148, 19);
            this.Rabel_Nothing1.TabIndex = 0;
            this.Rabel_Nothing1.Text = "Raid System Name : ";
            this.Rabel_Nothing1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseDown);
            this.Rabel_Nothing1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_RaidAdd_MouseMove);
            // 
            // Tab_Option
            // 
            this.Tab_Option.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Tab_Option.Controls.Add(this.Chk_DriveInfo);
            this.Tab_Option.Controls.Add(this.Chk_FileInfo);
            this.Tab_Option.Controls.Add(this.materialRaisedButton1);
            this.Tab_Option.Location = new System.Drawing.Point(4, 22);
            this.Tab_Option.Name = "Tab_Option";
            this.Tab_Option.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Option.Size = new System.Drawing.Size(774, 360);
            this.Tab_Option.TabIndex = 1;
            this.Tab_Option.Text = "Option";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = null;
            this.materialRaisedButton1.Location = new System.Drawing.Point(15, 16);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(123, 36);
            this.materialRaisedButton1.TabIndex = 1;
            this.materialRaisedButton1.Text = "Color Change";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // uploadFileDialog
            // 
            this.uploadFileDialog.FileName = "Check Upload Pleaze";
            this.uploadFileDialog.Multiselect = true;
            this.uploadFileDialog.RestoreDirectory = true;
            // 
            // StatLabel_SelNCap
            // 
            this.StatLabel_SelNCap.Name = "StatLabel_SelNCap";
            this.StatLabel_SelNCap.Size = new System.Drawing.Size(132, 17);
            this.StatLabel_SelNCap.Text = "0개 항목 선택함 0 Byte";
            // 
            // StatLabel_Slash
            // 
            this.StatLabel_Slash.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.StatLabel_Slash.Name = "StatLabel_Slash";
            this.StatLabel_Slash.Size = new System.Drawing.Size(10, 17);
            this.StatLabel_Slash.Text = "l";
            // 
            // StatLabel_AllFileNum
            // 
            this.StatLabel_AllFileNum.Name = "StatLabel_AllFileNum";
            this.StatLabel_AllFileNum.Size = new System.Drawing.Size(270, 17);
            this.StatLabel_AllFileNum.Text = "0개 하드 항목, 0개 클라우드 항목, 0개 파일 항목";
            // 
            // Text_Path
            // 
            this.Text_Path.AutoSize = true;
            this.Text_Path.Depth = 0;
            this.Text_Path.Font = new System.Drawing.Font("Roboto", 11F);
            this.Text_Path.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Text_Path.Location = new System.Drawing.Point(51, 13);
            this.Text_Path.MouseState = MaterialSkin.MouseState.HOVER;
            this.Text_Path.Name = "Text_Path";
            this.Text_Path.Size = new System.Drawing.Size(69, 19);
            this.Text_Path.TabIndex = 5;
            this.Text_Path.Text = "RaidList\\";
            // 
            // Btn_Prev
            // 
            this.Btn_Prev.AutoSize = true;
            this.Btn_Prev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_Prev.BackColor = System.Drawing.Color.GhostWhite;
            this.Btn_Prev.Depth = 0;
            this.Btn_Prev.Icon = null;
            this.Btn_Prev.Location = new System.Drawing.Point(16, 6);
            this.Btn_Prev.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Btn_Prev.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_Prev.Name = "Btn_Prev";
            this.Btn_Prev.Primary = false;
            this.Btn_Prev.Size = new System.Drawing.Size(28, 36);
            this.Btn_Prev.TabIndex = 6;
            this.Btn_Prev.Text = "<";
            this.Btn_Prev.UseVisualStyleBackColor = false;
            this.Btn_Prev.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // folderCreateToolStripMenuItem
            // 
            this.folderCreateToolStripMenuItem.Name = "folderCreateToolStripMenuItem";
            this.folderCreateToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.folderCreateToolStripMenuItem.Text = "Folder Create";
            this.folderCreateToolStripMenuItem.Click += new System.EventHandler(this.folderCreateToolStripMenuItem_Click);
            // 
            // Menu_FileManage
            // 
            this.Menu_FileManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Menu_FileManage.Depth = 0;
            this.Menu_FileManage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu_FileManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.folderCreateToolStripMenuItem,
            this.shareToolStripMenuItem,
            this.toolStripSeparator3,
            this.renameToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.Menu_FileManage.MouseState = MaterialSkin.MouseState.HOVER;
            this.Menu_FileManage.Name = "Menu_FileManage";
            this.Menu_FileManage.Size = new System.Drawing.Size(146, 230);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.shareToolStripMenuItem.Text = "Share";
            this.shareToolStripMenuItem.Click += new System.EventHandler(this.shareToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // googleDriveToolStripMenuItem
            // 
            this.googleDriveToolStripMenuItem.Name = "googleDriveToolStripMenuItem";
            this.googleDriveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.googleDriveToolStripMenuItem.Text = "Google Drive";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Btn_Prev);
            this.panel1.Controls.Add(this.Tab_Control);
            this.panel1.Controls.Add(this.Text_Path);
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 445);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.OutsidePaint);
            // 
            // Panel_Info
            // 
            this.Panel_Info.BackColor = System.Drawing.Color.GhostWhite;
            this.Panel_Info.Controls.Add(this.Label_DriveName);
            this.Panel_Info.Controls.Add(this.Label_Ineer);
            this.Panel_Info.Controls.Add(this.Label_Capcity);
            this.Panel_Info.Controls.Add(this.Btn_InfoDown);
            this.Panel_Info.Location = new System.Drawing.Point(6, 6);
            this.Panel_Info.Name = "Panel_Info";
            this.Panel_Info.Size = new System.Drawing.Size(217, 75);
            this.Panel_Info.TabIndex = 5;
            this.Panel_Info.Visible = false;
            this.Panel_Info.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_RaidAdd_Paint);
            // 
            // Label_DriveName
            // 
            this.Label_DriveName.AutoSize = true;
            this.Label_DriveName.Depth = 0;
            this.Label_DriveName.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_DriveName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_DriveName.Location = new System.Drawing.Point(14, 14);
            this.Label_DriveName.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_DriveName.Name = "Label_DriveName";
            this.Label_DriveName.Size = new System.Drawing.Size(55, 19);
            this.Label_DriveName.TabIndex = 7;
            this.Label_DriveName.Text = "Drive : ";
            // 
            // Label_Ineer
            // 
            this.Label_Ineer.AutoSize = true;
            this.Label_Ineer.Depth = 0;
            this.Label_Ineer.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_Ineer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_Ineer.Location = new System.Drawing.Point(15, 70);
            this.Label_Ineer.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Ineer.Name = "Label_Ineer";
            this.Label_Ineer.Size = new System.Drawing.Size(106, 19);
            this.Label_Ineer.TabIndex = 6;
            this.Label_Ineer.Text = "0 Folder, 0 File";
            this.Label_Ineer.Visible = false;
            // 
            // Label_Capcity
            // 
            this.Label_Capcity.AutoSize = true;
            this.Label_Capcity.Depth = 0;
            this.Label_Capcity.Font = new System.Drawing.Font("Roboto", 11F);
            this.Label_Capcity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label_Capcity.Location = new System.Drawing.Point(15, 41);
            this.Label_Capcity.MouseState = MaterialSkin.MouseState.HOVER;
            this.Label_Capcity.Name = "Label_Capcity";
            this.Label_Capcity.Size = new System.Drawing.Size(108, 19);
            this.Label_Capcity.TabIndex = 5;
            this.Label_Capcity.Text = "Capcity : 0Byte";
            // 
            // Btn_InfoDown
            // 
            this.Btn_InfoDown.AutoSize = true;
            this.Btn_InfoDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_InfoDown.Depth = 0;
            this.Btn_InfoDown.Icon = null;
            this.Btn_InfoDown.Location = new System.Drawing.Point(175, 13);
            this.Btn_InfoDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_InfoDown.Name = "Btn_InfoDown";
            this.Btn_InfoDown.Primary = true;
            this.Btn_InfoDown.Size = new System.Drawing.Size(30, 36);
            this.Btn_InfoDown.TabIndex = 4;
            this.Btn_InfoDown.Text = "X";
            this.Btn_InfoDown.UseVisualStyleBackColor = true;
            this.Btn_InfoDown.Click += new System.EventHandler(this.Btn_InfoDown_Click);
            // 
            // Panel_DriveList
            // 
            this.Panel_DriveList.BackColor = System.Drawing.Color.GhostWhite;
            this.Panel_DriveList.Controls.Add(this.Btn_DriveListDown);
            this.Panel_DriveList.Controls.Add(this.ListView_DriveList);
            this.Panel_DriveList.Location = new System.Drawing.Point(6, 98);
            this.Panel_DriveList.Name = "Panel_DriveList";
            this.Panel_DriveList.Size = new System.Drawing.Size(356, 256);
            this.Panel_DriveList.TabIndex = 6;
            this.Panel_DriveList.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_RaidAdd_Paint);
            // 
            // ListView_DriveList
            // 
            this.ListView_DriveList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView_DriveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Collum_List,
            this.columnHeader2,
            this.Total,
            this.Use});
            this.ListView_DriveList.Depth = 0;
            this.ListView_DriveList.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ListView_DriveList.FullRowSelect = true;
            this.ListView_DriveList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_DriveList.Location = new System.Drawing.Point(9, 58);
            this.ListView_DriveList.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ListView_DriveList.MouseState = MaterialSkin.MouseState.OUT;
            this.ListView_DriveList.Name = "ListView_DriveList";
            this.ListView_DriveList.OwnerDraw = true;
            this.ListView_DriveList.Size = new System.Drawing.Size(336, 187);
            this.ListView_DriveList.TabIndex = 0;
            this.ListView_DriveList.UseCompatibleStateImageBehavior = false;
            this.ListView_DriveList.View = System.Windows.Forms.View.Details;
            // 
            // Collum_List
            // 
            this.Collum_List.Text = "List";
            this.Collum_List.Width = 66;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 101;
            // 
            // Use
            // 
            this.Use.DisplayIndex = 2;
            this.Use.Text = "Use";
            this.Use.Width = 69;
            // 
            // Total
            // 
            this.Total.DisplayIndex = 3;
            this.Total.Text = "Total";
            this.Total.Width = 98;
            // 
            // Btn_DriveListDown
            // 
            this.Btn_DriveListDown.AutoSize = true;
            this.Btn_DriveListDown.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Btn_DriveListDown.Depth = 0;
            this.Btn_DriveListDown.Icon = null;
            this.Btn_DriveListDown.Location = new System.Drawing.Point(316, 12);
            this.Btn_DriveListDown.MouseState = MaterialSkin.MouseState.HOVER;
            this.Btn_DriveListDown.Name = "Btn_DriveListDown";
            this.Btn_DriveListDown.Primary = true;
            this.Btn_DriveListDown.Size = new System.Drawing.Size(30, 36);
            this.Btn_DriveListDown.TabIndex = 8;
            this.Btn_DriveListDown.Text = "X";
            this.Btn_DriveListDown.UseVisualStyleBackColor = true;
            this.Btn_DriveListDown.Click += new System.EventHandler(this.Btn_DriveListDown_Click);
            // 
            // Chk_FileInfo
            // 
            this.Chk_FileInfo.AutoSize = true;
            this.Chk_FileInfo.Checked = true;
            this.Chk_FileInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_FileInfo.Depth = 0;
            this.Chk_FileInfo.Font = new System.Drawing.Font("Roboto", 10F);
            this.Chk_FileInfo.Location = new System.Drawing.Point(15, 69);
            this.Chk_FileInfo.Margin = new System.Windows.Forms.Padding(0);
            this.Chk_FileInfo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Chk_FileInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.Chk_FileInfo.Name = "Chk_FileInfo";
            this.Chk_FileInfo.Ripple = true;
            this.Chk_FileInfo.Size = new System.Drawing.Size(132, 30);
            this.Chk_FileInfo.TabIndex = 2;
            this.Chk_FileInfo.Text = "Use File Info List";
            this.Chk_FileInfo.UseVisualStyleBackColor = true;
            // 
            // Chk_DriveInfo
            // 
            this.Chk_DriveInfo.AutoSize = true;
            this.Chk_DriveInfo.Checked = true;
            this.Chk_DriveInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_DriveInfo.Depth = 0;
            this.Chk_DriveInfo.Font = new System.Drawing.Font("Roboto", 10F);
            this.Chk_DriveInfo.Location = new System.Drawing.Point(15, 99);
            this.Chk_DriveInfo.Margin = new System.Windows.Forms.Padding(0);
            this.Chk_DriveInfo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Chk_DriveInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.Chk_DriveInfo.Name = "Chk_DriveInfo";
            this.Chk_DriveInfo.Ripple = true;
            this.Chk_DriveInfo.Size = new System.Drawing.Size(142, 30);
            this.Chk_DriveInfo.TabIndex = 3;
            this.Chk_DriveInfo.Text = "Use Drive Info List";
            this.Chk_DriveInfo.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tab_Selector);
            this.Name = "MainForm";
            this.Text = "Exten Drive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OutsidePaint);
            this.Tab_Control.ResumeLayout(false);
            this.Tab_Explorer.ResumeLayout(false);
            this.Menu_Panel.ResumeLayout(false);
            this.Panel_CreateFolder.ResumeLayout(false);
            this.Panel_CreateFolder.PerformLayout();
            this.Panel_Rename.ResumeLayout(false);
            this.Panel_Rename.PerformLayout();
            this.Panel_RaidAdd.ResumeLayout(false);
            this.Panel_RaidAdd.PerformLayout();
            this.Tab_Option.ResumeLayout(false);
            this.Tab_Option.PerformLayout();
            this.Menu_FileManage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Panel_Info.ResumeLayout(false);
            this.Panel_Info.PerformLayout();
            this.Panel_DriveList.ResumeLayout(false);
            this.Panel_DriveList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabSelector Tab_Selector;
        private MaterialSkin.Controls.MaterialTabControl Tab_Control;
        internal System.Windows.Forms.TabPage Tab_Explorer;
        private MaterialSkin.Controls.MaterialContextMenuStrip Menu_Panel;
        private System.Windows.Forms.ToolStripMenuItem Menu_Panel_RaidSystemCreate;
        private System.Windows.Forms.ToolStripMenuItem Menu_Panel_RaidSystemDelete;
        private System.Windows.Forms.ToolStripMenuItem Menu_Panel_RaidSystemRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Panel_CloudServiceAdd;
        private System.Windows.Forms.ToolStripMenuItem Menu_Panel_CloudServiceAddGoogleDrive;
        private System.Windows.Forms.Panel Panel_CreateFolder;
        private MaterialSkin.Controls.MaterialRaisedButton Btn_CreateFolderDown;
        private MaterialSkin.Controls.MaterialRaisedButton Btn_CreateFolderOK;
        private MaterialSkin.Controls.MaterialSingleLineTextField TXT_CreateName;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel Panel_Rename;
        private MaterialSkin.Controls.MaterialLabel Label_RenameNowName;
        private MaterialSkin.Controls.MaterialRaisedButton Btn_RenameDown;
        private MaterialSkin.Controls.MaterialRaisedButton Btn_Rename;
        private MaterialSkin.Controls.MaterialSingleLineTextField TXT_Rename;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Panel Panel_RaidAdd;
        private MaterialSkin.Controls.MaterialRaisedButton Btn_RaidSystemDown;
        private MaterialSkin.Controls.MaterialRaisedButton BTN_RaidSystemCreate;
        private MaterialSkin.Controls.MaterialSingleLineTextField TXT_RaidAdd_Input;
        private MaterialSkin.Controls.MaterialLabel Rabel_Nothing1;
        private System.Windows.Forms.TabPage Tab_Option;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.OpenFileDialog uploadFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel StatLabel_SelNCap;
        private System.Windows.Forms.ToolStripStatusLabel StatLabel_Slash;
        private System.Windows.Forms.ToolStripStatusLabel StatLabel_AllFileNum;
        internal MaterialSkin.Controls.MaterialLabel Text_Path;
        private MaterialSkin.Controls.MaterialFlatButton Btn_Prev;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderCreateToolStripMenuItem;
        internal MaterialSkin.Controls.MaterialContextMenuStrip Menu_FileManage;
        private System.Windows.Forms.ToolStripMenuItem googleDriveToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        internal System.Windows.Forms.Panel Panel_Info;
        internal MaterialSkin.Controls.MaterialLabel Label_DriveName;
        internal MaterialSkin.Controls.MaterialLabel Label_Ineer;
        internal MaterialSkin.Controls.MaterialLabel Label_Capcity;
        internal MaterialSkin.Controls.MaterialRaisedButton Btn_InfoDown;
        private System.Windows.Forms.ColumnHeader Collum_List;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader Use;
        internal System.Windows.Forms.Panel Panel_DriveList;
        internal MaterialSkin.Controls.MaterialListView ListView_DriveList;
        internal MaterialSkin.Controls.MaterialRaisedButton Btn_DriveListDown;
        internal System.Windows.Forms.FolderBrowserDialog DownloadFolderDialog;
        internal MaterialSkin.Controls.MaterialCheckBox Chk_DriveInfo;
        internal MaterialSkin.Controls.MaterialCheckBox Chk_FileInfo;
    }
}

