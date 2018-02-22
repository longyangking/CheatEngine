using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheatEngine
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectProcess selectprocess = new SelectProcess(this);
            selectprocess.Show();
        }
        
        public void setSelectedProcess(String str)
        {
            textBox1.Text = str;
        }
    }
}
