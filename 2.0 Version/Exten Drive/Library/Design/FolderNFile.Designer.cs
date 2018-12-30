namespace Library.Design
{
    partial class FolderNFile
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Icon = new System.Windows.Forms.PictureBox();
            this.Label_Text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Icon
            // 
            this.Icon.BackColor = System.Drawing.Color.Transparent;
            this.Icon.Image = global::Exten_Drive.Properties.Resources.DriveImage;
            this.Icon.Location = new System.Drawing.Point(2, 2);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(100, 100);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon.TabIndex = 0;
            this.Icon.TabStop = false;
            this.Icon.Paint += new System.Windows.Forms.PaintEventHandler(this.Icon_Paint);
            this.Icon.DoubleClick += new System.EventHandler(this.Icon_DoubleClick);
            this.Icon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
            this.Icon.MouseEnter += new System.EventHandler(this.Icon_MouseEnter);
            this.Icon.MouseLeave += new System.EventHandler(this.Icon_MouseLeave);
            this.Icon.MouseHover += new System.EventHandler(this.Icon_MouseHover);
            this.Icon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseMove);
            this.Icon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseUp);
            // 
            // Label_Text
            // 
            this.Label_Text.AutoSize = true;
            this.Label_Text.BackColor = System.Drawing.Color.Transparent;
            this.Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label_Text.Location = new System.Drawing.Point(2, 104);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(54, 13);
            this.Label_Text.TabIndex = 1;
            this.Label_Text.Text = "RaidDrive";
            this.Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_Text.Click += new System.EventHandler(this.Label_Text_Click);
            this.Label_Text.Paint += new System.Windows.Forms.PaintEventHandler(this.Icon_Paint);
            this.Label_Text.DoubleClick += new System.EventHandler(this.Icon_DoubleClick);
            this.Label_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
            this.Label_Text.MouseEnter += new System.EventHandler(this.Icon_MouseEnter);
            this.Label_Text.MouseLeave += new System.EventHandler(this.Icon_MouseLeave);
            this.Label_Text.MouseHover += new System.EventHandler(this.Icon_MouseHover);
            this.Label_Text.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseMove);
            this.Label_Text.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseUp);
            // 
            // FolderNFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Label_Text);
            this.Controls.Add(this.Icon);
            this.Name = "FolderNFile";
            this.Size = new System.Drawing.Size(104, 130);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Icon_Paint);
            this.DoubleClick += new System.EventHandler(this.Icon_DoubleClick);
            this.Leave += new System.EventHandler(this.FolderNFile_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Icon_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Icon_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Icon_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Icon_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox Icon;
        internal System.Windows.Forms.Label Label_Text;
    }
}
