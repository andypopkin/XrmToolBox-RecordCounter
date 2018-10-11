namespace AndyPopkin.RecordCounter
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnOverwriteConfig = new System.Windows.Forms.Button();
            this.btnSaveNewConfiguration = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(622, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(13, 326);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(150, 23);
            this.btnOpenConfig.TabIndex = 1;
            this.btnOpenConfig.Text = "Open Selected Config";
            this.btnOpenConfig.UseVisualStyleBackColor = true;
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnOverwriteConfig
            // 
            this.btnOverwriteConfig.Location = new System.Drawing.Point(211, 326);
            this.btnOverwriteConfig.Name = "btnOverwriteConfig";
            this.btnOverwriteConfig.Size = new System.Drawing.Size(166, 23);
            this.btnOverwriteConfig.TabIndex = 2;
            this.btnOverwriteConfig.Text = "Overwrite Selected Config";
            this.btnOverwriteConfig.UseVisualStyleBackColor = true;
            this.btnOverwriteConfig.Click += new System.EventHandler(this.btnOverwriteConfig_Click);
            // 
            // btnSaveNewConfiguration
            // 
            this.btnSaveNewConfiguration.Location = new System.Drawing.Point(383, 326);
            this.btnSaveNewConfiguration.Name = "btnSaveNewConfiguration";
            this.btnSaveNewConfiguration.Size = new System.Drawing.Size(123, 23);
            this.btnSaveNewConfiguration.TabIndex = 3;
            this.btnSaveNewConfiguration.Text = "Save As New";
            this.btnSaveNewConfiguration.UseVisualStyleBackColor = true;
            this.btnSaveNewConfiguration.Click += new System.EventHandler(this.btnSaveNewConfiguration_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(559, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(12, 298);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(622, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Open an existing Configuration, Overwrite an existing Configuration, or Save As N" +
    "ew using current checkbox values";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 362);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveNewConfiguration);
            this.Controls.Add(this.btnOverwriteConfig);
            this.Controls.Add(this.btnOpenConfig);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Configuration";
            this.Text = "Configuration Manager";
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOpenConfig;
        private System.Windows.Forms.Button btnOverwriteConfig;
        private System.Windows.Forms.Button btnSaveNewConfiguration;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
    }
}