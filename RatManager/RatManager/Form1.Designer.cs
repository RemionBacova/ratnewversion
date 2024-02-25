namespace RatManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            UpdateGrid = new Button();
            btnSetAllForNoCMDRun = new Button();
            btnSetAllForNoConnect = new Button();
            btnSetAllForNoInstalledAplicationDump = new Button();
            btnSetAllForNoKeyLogDump = new Button();
            btnSetAllForNoRegistered = new Button();
            btnSetAllForNoUpdate = new Button();
            btnSetForUpdate = new Button();
            btnSetForRegistered = new Button();
            btnSetForKeyLogDump = new Button();
            btnSetForInstalledAplicationDump = new Button();
            btnSetForConnect = new Button();
            btnSetForCMDRun = new Button();
            btnDisplayPCData = new Button();
            btnDisplayKeyLogDump = new Button();
            btnDisplayApplicationDump = new Button();
            btnDisplayCMDRun = new Button();
            btnDisplayRDP = new Button();
            btnSetForRDP = new Button();
            btnSetAllForNoRDP = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 168);
            dataGridView1.TabIndex = 0;
            // 
            // UpdateGrid
            // 
            UpdateGrid.Location = new Point(12, 199);
            UpdateGrid.Name = "UpdateGrid";
            UpdateGrid.Size = new Size(214, 23);
            UpdateGrid.TabIndex = 1;
            UpdateGrid.Text = "Update List";
            UpdateGrid.UseVisualStyleBackColor = true;
            UpdateGrid.Click += UpdateGrid_Click;
            // 
            // btnSetAllForNoCMDRun
            // 
            btnSetAllForNoCMDRun.Location = new Point(12, 228);
            btnSetAllForNoCMDRun.Name = "btnSetAllForNoCMDRun";
            btnSetAllForNoCMDRun.Size = new Size(214, 23);
            btnSetAllForNoCMDRun.TabIndex = 2;
            btnSetAllForNoCMDRun.Text = "SetAllForNoCMDRun";
            btnSetAllForNoCMDRun.UseVisualStyleBackColor = true;
            btnSetAllForNoCMDRun.Click += btnSetAllForNoCMDRun_Click;
            // 
            // btnSetAllForNoConnect
            // 
            btnSetAllForNoConnect.Location = new Point(12, 257);
            btnSetAllForNoConnect.Name = "btnSetAllForNoConnect";
            btnSetAllForNoConnect.Size = new Size(214, 23);
            btnSetAllForNoConnect.TabIndex = 3;
            btnSetAllForNoConnect.Text = "SetAllForNoConnect";
            btnSetAllForNoConnect.UseVisualStyleBackColor = true;
            btnSetAllForNoConnect.Click += btnSetAllForNoConnect_Click;
            // 
            // btnSetAllForNoInstalledAplicationDump
            // 
            btnSetAllForNoInstalledAplicationDump.ImageAlign = ContentAlignment.BottomCenter;
            btnSetAllForNoInstalledAplicationDump.Location = new Point(12, 286);
            btnSetAllForNoInstalledAplicationDump.Name = "btnSetAllForNoInstalledAplicationDump";
            btnSetAllForNoInstalledAplicationDump.Size = new Size(214, 23);
            btnSetAllForNoInstalledAplicationDump.TabIndex = 4;
            btnSetAllForNoInstalledAplicationDump.Text = "SetAllForNoInstalledAplicationDump";
            btnSetAllForNoInstalledAplicationDump.UseVisualStyleBackColor = true;
            btnSetAllForNoInstalledAplicationDump.Click += btnSetAllForNoInstalledAplicationDump_Click;
            // 
            // btnSetAllForNoKeyLogDump
            // 
            btnSetAllForNoKeyLogDump.Location = new Point(12, 315);
            btnSetAllForNoKeyLogDump.Name = "btnSetAllForNoKeyLogDump";
            btnSetAllForNoKeyLogDump.Size = new Size(214, 23);
            btnSetAllForNoKeyLogDump.TabIndex = 5;
            btnSetAllForNoKeyLogDump.Text = "SetAllForNoKeyLogDump";
            btnSetAllForNoKeyLogDump.UseVisualStyleBackColor = true;
            btnSetAllForNoKeyLogDump.Click += btnSetAllForNoKeyLogDump_Click;
            // 
            // btnSetAllForNoRegistered
            // 
            btnSetAllForNoRegistered.Location = new Point(12, 344);
            btnSetAllForNoRegistered.Name = "btnSetAllForNoRegistered";
            btnSetAllForNoRegistered.Size = new Size(214, 23);
            btnSetAllForNoRegistered.TabIndex = 6;
            btnSetAllForNoRegistered.Text = "SetAllForNoRegistered";
            btnSetAllForNoRegistered.UseVisualStyleBackColor = true;
            btnSetAllForNoRegistered.Click += btnSetAllForNoRegistered_Click;
            // 
            // btnSetAllForNoUpdate
            // 
            btnSetAllForNoUpdate.Location = new Point(12, 373);
            btnSetAllForNoUpdate.Name = "btnSetAllForNoUpdate";
            btnSetAllForNoUpdate.Size = new Size(214, 23);
            btnSetAllForNoUpdate.TabIndex = 7;
            btnSetAllForNoUpdate.Text = "SetAllForNoUpdate";
            btnSetAllForNoUpdate.UseVisualStyleBackColor = true;
            btnSetAllForNoUpdate.Click += btnSetAllForNoUpdate_Click;
            // 
            // btnSetForUpdate
            // 
            btnSetForUpdate.Location = new Point(286, 373);
            btnSetForUpdate.Name = "btnSetForUpdate";
            btnSetForUpdate.Size = new Size(214, 23);
            btnSetForUpdate.TabIndex = 13;
            btnSetForUpdate.Text = "SetForUpdate";
            btnSetForUpdate.UseVisualStyleBackColor = true;
            btnSetForUpdate.Click += btnSetForUpdate_Click;
            // 
            // btnSetForRegistered
            // 
            btnSetForRegistered.Location = new Point(286, 344);
            btnSetForRegistered.Name = "btnSetForRegistered";
            btnSetForRegistered.Size = new Size(214, 23);
            btnSetForRegistered.TabIndex = 12;
            btnSetForRegistered.Text = "SetForRegistered";
            btnSetForRegistered.UseVisualStyleBackColor = true;
            btnSetForRegistered.Click += btnSetForRegistered_Click;
            // 
            // btnSetForKeyLogDump
            // 
            btnSetForKeyLogDump.Location = new Point(286, 315);
            btnSetForKeyLogDump.Name = "btnSetForKeyLogDump";
            btnSetForKeyLogDump.Size = new Size(214, 23);
            btnSetForKeyLogDump.TabIndex = 11;
            btnSetForKeyLogDump.Text = "SetForKeyLogDump";
            btnSetForKeyLogDump.UseVisualStyleBackColor = true;
            btnSetForKeyLogDump.Click += btnSetForKeyLogDump_Click;
            // 
            // btnSetForInstalledAplicationDump
            // 
            btnSetForInstalledAplicationDump.ImageAlign = ContentAlignment.BottomCenter;
            btnSetForInstalledAplicationDump.Location = new Point(286, 286);
            btnSetForInstalledAplicationDump.Name = "btnSetForInstalledAplicationDump";
            btnSetForInstalledAplicationDump.Size = new Size(214, 23);
            btnSetForInstalledAplicationDump.TabIndex = 10;
            btnSetForInstalledAplicationDump.Text = "SetForInstalledAplicationDump";
            btnSetForInstalledAplicationDump.UseVisualStyleBackColor = true;
            btnSetForInstalledAplicationDump.Click += btnSetForInstalledAplicationDump_Click;
            // 
            // btnSetForConnect
            // 
            btnSetForConnect.Location = new Point(286, 257);
            btnSetForConnect.Name = "btnSetForConnect";
            btnSetForConnect.Size = new Size(214, 23);
            btnSetForConnect.TabIndex = 9;
            btnSetForConnect.Text = "SetForConnect";
            btnSetForConnect.UseVisualStyleBackColor = true;
            btnSetForConnect.Click += btnSetForConnect_Click;
            // 
            // btnSetForCMDRun
            // 
            btnSetForCMDRun.Location = new Point(286, 228);
            btnSetForCMDRun.Name = "btnSetForCMDRun";
            btnSetForCMDRun.Size = new Size(214, 23);
            btnSetForCMDRun.TabIndex = 8;
            btnSetForCMDRun.Text = "SetForCMDRun";
            btnSetForCMDRun.UseVisualStyleBackColor = true;
            btnSetForCMDRun.Click += btnSetForCMDRun_Click;
            // 
            // btnDisplayPCData
            // 
            btnDisplayPCData.Location = new Point(545, 373);
            btnDisplayPCData.Name = "btnDisplayPCData";
            btnDisplayPCData.Size = new Size(214, 23);
            btnDisplayPCData.TabIndex = 17;
            btnDisplayPCData.Text = "Display PC Data";
            btnDisplayPCData.UseVisualStyleBackColor = true;
            btnDisplayPCData.Click += btnDisplayPCData_Click;
            // 
            // btnDisplayKeyLogDump
            // 
            btnDisplayKeyLogDump.Location = new Point(545, 315);
            btnDisplayKeyLogDump.Name = "btnDisplayKeyLogDump";
            btnDisplayKeyLogDump.Size = new Size(214, 23);
            btnDisplayKeyLogDump.TabIndex = 16;
            btnDisplayKeyLogDump.Text = "Display KeyLogDump";
            btnDisplayKeyLogDump.UseVisualStyleBackColor = true;
            btnDisplayKeyLogDump.Click += btnDisplayKeyLogDump_Click;
            // 
            // btnDisplayApplicationDump
            // 
            btnDisplayApplicationDump.ImageAlign = ContentAlignment.BottomCenter;
            btnDisplayApplicationDump.Location = new Point(545, 286);
            btnDisplayApplicationDump.Name = "btnDisplayApplicationDump";
            btnDisplayApplicationDump.Size = new Size(214, 23);
            btnDisplayApplicationDump.TabIndex = 15;
            btnDisplayApplicationDump.Text = "Display AplicationDump";
            btnDisplayApplicationDump.UseVisualStyleBackColor = true;
            btnDisplayApplicationDump.Click += btnDisplayApplicationDump_Click;
            // 
            // btnDisplayCMDRun
            // 
            btnDisplayCMDRun.Location = new Point(545, 228);
            btnDisplayCMDRun.Name = "btnDisplayCMDRun";
            btnDisplayCMDRun.Size = new Size(214, 23);
            btnDisplayCMDRun.TabIndex = 14;
            btnDisplayCMDRun.Text = "Display CMDRun";
            btnDisplayCMDRun.UseVisualStyleBackColor = true;
            btnDisplayCMDRun.Click += btnDisplayCMDRun_Click;
            // 
            // btnDisplayRDP
            // 
            btnDisplayRDP.Location = new Point(545, 402);
            btnDisplayRDP.Name = "btnDisplayRDP";
            btnDisplayRDP.Size = new Size(214, 23);
            btnDisplayRDP.TabIndex = 20;
            btnDisplayRDP.Text = "Display RDP";
            btnDisplayRDP.UseVisualStyleBackColor = true;
            btnDisplayRDP.Click += btnDisplayRDP_Click;
            // 
            // btnSetForRDP
            // 
            btnSetForRDP.Location = new Point(286, 402);
            btnSetForRDP.Name = "btnSetForRDP";
            btnSetForRDP.Size = new Size(214, 23);
            btnSetForRDP.TabIndex = 19;
            btnSetForRDP.Text = "SetForRDP";
            btnSetForRDP.UseVisualStyleBackColor = true;
            btnSetForRDP.Click += btnSetForRDP_Click;
            // 
            // btnSetAllForNoRDP
            // 
            btnSetAllForNoRDP.Location = new Point(12, 402);
            btnSetAllForNoRDP.Name = "btnSetAllForNoRDP";
            btnSetAllForNoRDP.Size = new Size(214, 23);
            btnSetAllForNoRDP.TabIndex = 18;
            btnSetAllForNoRDP.Text = "SetAllForNoRDP";
            btnSetAllForNoRDP.UseVisualStyleBackColor = true;
            btnSetAllForNoRDP.Click += btnSetAllForNoRDP_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDisplayRDP);
            Controls.Add(btnSetForRDP);
            Controls.Add(btnSetAllForNoRDP);
            Controls.Add(btnDisplayPCData);
            Controls.Add(btnDisplayKeyLogDump);
            Controls.Add(btnDisplayApplicationDump);
            Controls.Add(btnDisplayCMDRun);
            Controls.Add(btnSetForUpdate);
            Controls.Add(btnSetForRegistered);
            Controls.Add(btnSetForKeyLogDump);
            Controls.Add(btnSetForInstalledAplicationDump);
            Controls.Add(btnSetForConnect);
            Controls.Add(btnSetForCMDRun);
            Controls.Add(btnSetAllForNoUpdate);
            Controls.Add(btnSetAllForNoRegistered);
            Controls.Add(btnSetAllForNoKeyLogDump);
            Controls.Add(btnSetAllForNoInstalledAplicationDump);
            Controls.Add(btnSetAllForNoConnect);
            Controls.Add(btnSetAllForNoCMDRun);
            Controls.Add(UpdateGrid);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button UpdateGrid;
        private Button btnSetAllForNoCMDRun;
        private Button btnSetAllForNoConnect;
        private Button btnSetAllForNoInstalledAplicationDump;
        private Button btnSetAllForNoKeyLogDump;
        private Button btnSetAllForNoRegistered;
        private Button btnSetAllForNoUpdate;
        private Button btnSetForUpdate;
        private Button btnSetForRegistered;
        private Button btnSetForKeyLogDump;
        private Button btnSetForInstalledAplicationDump;
        private Button btnSetForConnect;
        private Button btnSetForCMDRun;
        private Button btnDisplayPCData;
        private Button btnDisplayKeyLogDump;
        private Button btnDisplayApplicationDump;
        private Button btnDisplayCMDRun;
        private Button btnDisplayRDP;
        private Button btnSetForRDP;
        private Button btnSetAllForNoRDP;
    }
}
