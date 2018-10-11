namespace XrmToolBox___CRM_Record_Counter
{
    partial class MainControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnWhoAmI = new System.Windows.Forms.Button();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscmbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.tsbLoadData = new System.Windows.Forms.ToolStripButton();
            this.tsbGetCounts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCheckAll = new System.Windows.Forms.ToolStripButton();
            this.tsbUncheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.tsbConfiguration = new System.Windows.Forms.ToolStripButton();
            this.toolImageList = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tsbtnHelp = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWhoAmI
            // 
            this.btnWhoAmI.Location = new System.Drawing.Point(405, 274);
            this.btnWhoAmI.Name = "btnWhoAmI";
            this.btnWhoAmI.Size = new System.Drawing.Size(75, 23);
            this.btnWhoAmI.TabIndex = 1;
            this.btnWhoAmI.Text = "Who Am I";
            this.btnWhoAmI.UseVisualStyleBackColor = true;
            this.btnWhoAmI.Visible = false;
            this.btnWhoAmI.Click += new System.EventHandler(this.BtnWhoAmIClick);
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.tscmbFilter,
            this.tsbLoadData,
            this.toolStripSeparator2,
            this.toolStripTextBox1,
            this.tsbCheckAll,
            this.tsbUncheckAll,
            this.toolStripSeparator4,
            this.tsbGetCounts,
            this.toolStripSeparator3,
            this.btnExport,
            this.tsbConfiguration,
            this.tsbtnHelp});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(911, 25);
            this.toolStripMenu.TabIndex = 2;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(23, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.TsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tscmbFilter
            // 
            this.tscmbFilter.Items.AddRange(new object[] {
            "All Entities",
            "Custom Entities",
            "CRM Entities",
            "System Entities"});
            this.tscmbFilter.Name = "tscmbFilter";
            this.tscmbFilter.Size = new System.Drawing.Size(121, 25);
            this.tscmbFilter.Text = "All Entities";
            // 
            // tsbLoadData
            // 
            this.tsbLoadData.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadData.Image")));
            this.tsbLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadData.Name = "tsbLoadData";
            this.tsbLoadData.Size = new System.Drawing.Size(94, 22);
            this.tsbLoadData.Text = "Load Entities";
            this.tsbLoadData.Click += new System.EventHandler(this.TsbLoadData_Click);
            // 
            // tsbGetCounts
            // 
            this.tsbGetCounts.Image = ((System.Drawing.Image)(resources.GetObject("tsbGetCounts.Image")));
            this.tsbGetCounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGetCounts.Name = "tsbGetCounts";
            this.tsbGetCounts.Size = new System.Drawing.Size(86, 22);
            this.tsbGetCounts.Text = "Get Counts";
            this.tsbGetCounts.Click += new System.EventHandler(this.tsbGetCounts_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCheckAll
            // 
            this.tsbCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbCheckAll.Image")));
            this.tsbCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckAll.Name = "tsbCheckAll";
            this.tsbCheckAll.Size = new System.Drawing.Size(61, 22);
            this.tsbCheckAll.Text = "Check All";
            this.tsbCheckAll.Click += new System.EventHandler(this.tsbCheckAll_Click_1);
            // 
            // tsbUncheckAll
            // 
            this.tsbUncheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUncheckAll.Image = ((System.Drawing.Image)(resources.GetObject("tsbUncheckAll.Image")));
            this.tsbUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUncheckAll.Name = "tsbUncheckAll";
            this.tsbUncheckAll.Size = new System.Drawing.Size(74, 22);
            this.tsbUncheckAll.Text = "Uncheck All";
            this.tsbUncheckAll.Click += new System.EventHandler(this.tsbUncheckAll_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.Text = " search";
            this.toolStripTextBox1.Click += new System.EventHandler(this.ToolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.ToolStripTextBox1_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(98, 22);
            this.btnExport.Text = "Export to CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click_1);
            // 
            // tsbConfiguration
            // 
            this.tsbConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfiguration.Image")));
            this.tsbConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfiguration.Name = "tsbConfiguration";
            this.tsbConfiguration.Size = new System.Drawing.Size(159, 22);
            this.tsbConfiguration.Text = "Load/Save Configuration";
            this.tsbConfiguration.Click += new System.EventHandler(this.tsbConfiguration_Click);
            // 
            // toolImageList
            // 
            this.toolImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolImageList.ImageStream")));
            this.toolImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.toolImageList.Images.SetKeyName(0, "ap-logo-311x250.png");
            this.toolImageList.Images.SetKeyName(1, "nologo.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(911, 575);
            this.dataGridView1.TabIndex = 3;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV|*.csv";
            // 
            // tsbtnHelp
            // 
            this.tsbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHelp.Image")));
            this.tsbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHelp.Name = "tsbtnHelp";
            this.tsbtnHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbtnHelp.Text = "Help";
            this.tsbtnHelp.Click += new System.EventHandler(this.tsbtnHelp_Click);
            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStripMenu);
            this.Controls.Add(this.btnWhoAmI);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(911, 600);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWhoAmI;
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ImageList toolImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadData;
        private System.Windows.Forms.ToolStripButton tsbGetCounts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCheckAll;
        private System.Windows.Forms.ToolStripButton tsbUncheckAll;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox tscmbFilter;
        private System.Windows.Forms.ToolStripButton tsbConfiguration;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnHelp;
    }
}
