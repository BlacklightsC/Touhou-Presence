namespace Touhou_Presence
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
            this.components = new System.ComponentModel.Container();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMB_CurrentGame = new System.Windows.Forms.ToolStripMenuItem();
            this.CMB_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.CMT_CurrentGame = new System.Windows.Forms.ToolStripTextBox();
            this.TrayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayIconMenu;
            this.TrayIcon.Text = "Touhou Presence";
            this.TrayIcon.Visible = true;
            // 
            // TrayIconMenu
            // 
            this.TrayIconMenu.AutoSize = false;
            this.TrayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMB_CurrentGame,
            this.CMT_CurrentGame,
            this.CMB_Close});
            this.TrayIconMenu.Name = "TrayIconMenu";
            this.TrayIconMenu.ShowImageMargin = false;
            this.TrayIconMenu.Size = new System.Drawing.Size(300, 71);
            // 
            // CMB_CurrentGame
            // 
            this.CMB_CurrentGame.Enabled = false;
            this.CMB_CurrentGame.Font = new System.Drawing.Font("Arial", 10F);
            this.CMB_CurrentGame.Name = "CMB_CurrentGame";
            this.CMB_CurrentGame.ShowShortcutKeys = false;
            this.CMB_CurrentGame.Size = new System.Drawing.Size(295, 22);
            this.CMB_CurrentGame.Text = "Current Game";
            // 
            // CMB_Close
            // 
            this.CMB_Close.Font = new System.Drawing.Font("Arial", 10F);
            this.CMB_Close.Name = "CMB_Close";
            this.CMB_Close.Size = new System.Drawing.Size(295, 22);
            this.CMB_Close.Text = "Close";
            this.CMB_Close.Click += new System.EventHandler(this.CMB_Close_Click);
            // 
            // CMT_CurrentGame
            // 
            this.CMT_CurrentGame.Font = new System.Drawing.Font("Arial", 9F);
            this.CMT_CurrentGame.Name = "CMT_CurrentGame";
            this.CMT_CurrentGame.ReadOnly = true;
            this.CMT_CurrentGame.Size = new System.Drawing.Size(280, 21);
            this.CMT_CurrentGame.Text = "Nothing found";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Touhou Presence";
            this.TransparencyKey = System.Drawing.Color.White;
            this.TrayIconMenu.ResumeLayout(false);
            this.TrayIconMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem CMB_CurrentGame;
        private System.Windows.Forms.ToolStripTextBox CMT_CurrentGame;
        private System.Windows.Forms.ToolStripMenuItem CMB_Close;
    }
}

