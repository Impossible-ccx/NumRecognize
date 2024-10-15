using NumRecognize.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumRecognize
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void QuitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OpenBIO(object sender, EventArgs e)
        {
            foreach(Form mdiForm in this.MdiChildren)
            {
                mdiForm.Close();
            }
            BasicIO basicIO = new BasicIO();
            basicIO.MdiParent = this;
            basicIO.Show();
        }
    }
}
