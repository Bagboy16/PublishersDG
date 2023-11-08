using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishersDG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void editorialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Publishers publishers = new Publishers();
            publishers.ShowDialog();

        }
    }
}
