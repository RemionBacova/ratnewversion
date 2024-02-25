using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RatManager.SubPages
{
    public partial class CMDRun : Form
    {

        private Communicator communicator;
        private string lastElement = "";
        public CMDRun()
        {
            InitializeComponent();

            communicator = new Communicator();
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            textBox1.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            var returnvalue = communicator.ReadOutput();

            if (returnvalue != lastElement)
            {
                lastElement = returnvalue;

                richTextBox1.Text += "\n" + lastElement;
                communicator.ClearOutput();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            communicator.SendCMD(textBox1.Text);
            textBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                communicator.SendCMD(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
           var file =  communicator.GetFile();
            if(file == null)
            {
                MessageBox.Show("No file to download");
                return;
            }
            saveFileDialog1.FileName = file.fileName;
            
            saveFileDialog1.ShowDialog();


            System.IO.FileStream _FileStream =
       new System.IO.FileStream(saveFileDialog1.FileName, System.IO.FileMode.Create,
                                System.IO.FileAccess.Write);
            // Writes a block of bytes to this stream using data from
            // a byte array.
            _FileStream.Write(file.bytes, 0, file.bytes.Length);

            // close file stream
            _FileStream.Close();

            communicator.ClearFile();
        }
    }
}
