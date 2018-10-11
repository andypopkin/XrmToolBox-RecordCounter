using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox___CRM_Record_Counter;

namespace AndyPopkin.RecordCounter
{
    public partial class SaveAs : Form
    {
        public MainControl main;
        public Configuration config;
        private string entityList;
        public string EntityList { get { return entityList; } set { entityList = value; } }
        
        public SaveAs()
        {
            InitializeComponent();
        }

        private void SaveAs_Load(object sender, EventArgs e)
        {
            txtEntityList.Text = EntityList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Pass the name back to Configuration
            config.NewConfigName = txtConfigName.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
