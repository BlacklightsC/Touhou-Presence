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
        Data.th07 data = new Data.th07();
        public MainForm()
        {
            InitializeComponent();
        }
    }
}
