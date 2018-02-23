using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace CheatEngine
{
    public partial class SelectProcess : Form
    {
        public Boolean status = false;
        public String selectedprocess;
        public MainWindow parent;
        public SelectProcess(MainWindow mainwindow)
        {
            InitializeComponent();
            this.parent = mainwindow;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            parent.setSelectedProcess(listBox1.SelectedItem.ToString());
            status = true;
            this.Close();
        }

        private void SelectProcess_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] ps = MemoryManager.GetProcesses();
            foreach (Process p in ps)
            {
                //listBox1.Items.Add(p.ProcessName);
                if (p.MainWindowTitle != ""){ //The process with main window handle
                    listBox1.Items.Add(p.ProcessName);
                }            
            }
        }
    }
}
