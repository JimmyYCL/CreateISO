using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateISO
{
    public partial class ISOCreater : Form
    {

        private string srcdir = @"d:\temp\Mnt";
        private string isopath = @"d:\temp\temp.iso";
        private string filename = @"d:\temp\CreateIsoTool\mkisofs.exe";




        public ISOCreater()
        {
            InitializeComponent();
            textBox1.Text = srcdir;
            textBox2.Text = isopath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string param = @"-J -l -b isolinux/isolinux.bin -no-emul-boot -boot-load-size 4 -boot-info-table";

            Process myProcess = new Process();

            myProcess.StartInfo.FileName = filename;
            myProcess.StartInfo.Arguments = param + " -o " + isopath + " " + srcdir;
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo.RedirectStandardInput = true;

            myProcess.Start();

            
            try
            {
                myProcess.Start();

                myProcess.WaitForExit();
                int code = myProcess.ExitCode;

            }

            finally
            {
                if (myProcess != null)
                {
                    myProcess.Close();
                }
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // select mount path
        private void button2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select the mount source folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("You selected: " + dlg.SelectedPath);

                    srcdir = dlg.SelectedPath;
                    textBox1.Text = srcdir;
                }
            }
        }

        // select output ISO path
        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select output ISO folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //MessageBox.Show("You selected: " + dlg.SelectedPath);

                    isopath = dlg.SelectedPath + "\\temp.iso";
                    textBox2.Text = isopath;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
