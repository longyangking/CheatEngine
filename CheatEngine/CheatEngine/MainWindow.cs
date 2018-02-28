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
    public partial class MainWindow : Form
    {
        Process process = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectProcess selectprocess = new SelectProcess(this);
            selectprocess.Show();
        }
        
        public void setSelectedProcess(Process process)
        {
            this.process = process;
            textBox1.Text = process.ProcessName + " " + process.Id ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter the value!");
                return;
            }

            int value;
            if(!int.TryParse(textBox2.Text, out value))
            {
                MessageBox.Show("Please enter the integer value!");
                return;
            }

            if (process == null)
            {
                MessageBox.Show("Please choose a process!");
                return;
            }

            MemoryManager.SYSTEM_INFO sys_info = new MemoryManager.SYSTEM_INFO();
            MemoryManager.GetSystemInfo(out sys_info);

            IntPtr proc_min_address = sys_info.minimumApplicationAddress;
            IntPtr proc_max_address = sys_info.maximumApplicationAddress;

            long proc_min_address_l = (long)proc_min_address;
            long proc_max_address_l = (long)proc_max_address;

            this.progressBar1.Minimum = 0;
            int minvalue = (int)proc_min_address_l;

            this.progressBar1.Maximum = 100;
            int maxvalue = (int)proc_max_address_l;

            this.progressBar1.Value = 0;

            MemoryManager.MEMORY_BASIC_INFORMATION mem_basic_info = new MemoryManager.MEMORY_BASIC_INFORMATION();

            int readsize = MemoryManager.SizeOf(mem_basic_info);

            IntPtr processHandle =
                MemoryManager.OpenProcess(MemoryManager.PROCESS_QUERY_INFORMATION | MemoryManager.PROCESS_WM_READ, false, process.Id);

            int arraysize = 10;
            int num = 0;
            int[] addresses = new int[arraysize];
            int[] values = new int[arraysize];
            
            /*
            while (proc_min_address_l < proc_max_address_l)
            {
                MemoryManager.VirtualQueryEx(processHandle, proc_min_address, out mem_basic_info, readsize);
                //MemoryManager.CloseHandle(hProcess);

                if (mem_basic_info.RegionSize == 0)
                {
                    mem_basic_info.RegionSize = 0x1000;

                }
                int baseAddress = (int)proc_min_address;
                    for (int i = 0; i < mem_basic_info.RegionSize; i++)
                    {
                        baseAddress += 1;
                        byte[] buffer = new byte[4];
                        IntPtr byteAddress = MemoryManager.GetAddressOfArray(buffer); 

                        MemoryManager.ReadProcessMemory(processHandle, (IntPtr)baseAddress, byteAddress, 4, IntPtr.Zero);

                        value = MemoryManager.ReadBytes2Int(byteAddress);
                        if (value == 1234567123)
                        {
                            //Console.WriteLine("0x{0} : {1}", baseAddress.ToString("X"), value);
                            addresses[num] = baseAddress;
                            values[num] = value;
                            num += 1;
                            if (num >= arraysize)
                            {
                                break;
                            }
                        }

                    label2.Text = "Found: " + num + " (" + baseAddress + ")";
                    //this.progressBar1.Value = (int)(100* (baseAddress - minvalue) / (maxvalue - minvalue));
                    }
                


                if (num >= arraysize)
                {
                    break;
                }
                proc_min_address_l += mem_basic_info.RegionSize;
                proc_min_address = new IntPtr(proc_min_address_l);
            }

            for(int index=0; index<arraysize; index++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = addresses[index].ToString("x8");
                this.dataGridView1.Rows[index].Cells[1].Value = values[index].ToString();
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int index = this.dataGridView1.Rows.Add();
            //this.dataGridView1.Rows[index].Cells[0].Value = "0x0";
            //this.dataGridView1.Rows[index].Cells[1].Value = "sdf";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
