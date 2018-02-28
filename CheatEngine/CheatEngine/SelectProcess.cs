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
        public int selectedprocessindex;
        public Process[] processes;
        public MainWindow parent;

        public SelectProcess(MainWindow mainwindow)
        {
            InitializeComponent();
            this.parent = mainwindow;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listBox1.SelectedItem.ToString());
            selectedprocessindex = listBox1.SelectedIndex;
            parent.setSelectedProcess(processes[selectedprocessindex]);
            status = true;
            this.Close();
        }

        private void SelectProcess_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] ps = MemoryManager.GetProcesses();

            int length = 0;
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle != "") 
                {
                    length += 1;
                }
            }

            processes = new Process[length];
            int index = 0;
            foreach (Process p in ps)
            {
                if (p.MainWindowTitle != "") //The process with main window handle
                {
                    processes[index] = p;
                    listBox1.Items.Add(p.ProcessName + " " + p.Id);
                    index += 1;
                }            
            }
        }
    }
}
