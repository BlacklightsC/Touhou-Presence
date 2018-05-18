using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Touhou_Presence
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Icon = TrayIcon.Icon = Properties.Resources.Icon;
            ProcessFinder.SetText = text => this.Invoke(new Action(() => CMT_CurrentGame.Text = text));
            Shown += (sender, e) =>
            {
                this.Hide();
                ProcessFinder.SearchProcess();
            };
        }

        private void CMB_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
