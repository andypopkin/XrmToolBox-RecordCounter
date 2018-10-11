using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XrmToolBox;
using XrmToolBox___CRM_Record_Counter;

namespace AndyPopkin.RecordCounter
{
    public partial class Configuration : Form
    {
        public MainControl main;
        private string checkedEntities;
        public string CheckedEntities { get { return checkedEntities; } set { checkedEntities = value; } }
        private string newConfigName;
        public string NewConfigName { get { return newConfigName; } set { newConfigName = value; } }

        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            //MainControl main = new MainControl();

            if (!System.IO.File.Exists("RecordCounter.Configurations.xml"))
            {
                lblStatus.Text = "No Configurations Exist - Save As New to create one using existing checked boxes";
            }
            else
            {
                ReloadGrid();

                /*XmlSerializer deserializer = new XmlSerializer(typeof(RecordCounterConfigurations));
                StreamReader reader = new StreamReader("RecordCounter.Configurations.xml");
                               
                RecordCounterConfigurations rccs = null;
                rccs = (RecordCounterConfigurations)deserializer.Deserialize(reader);
                reader.Close();
                List<RCConfig> test_rccs = rccs.Configurations.ToList();
                this.Invoke((MethodInvoker)delegate()
                {
                    dataGridView1.DataSource = rccs.Configurations.ToList();
                });
                 * */
            }
        }

        private void ReloadGrid()
        {
            if (!System.IO.File.Exists("RecordCounter.Configurations.xml"))
            {
                lblStatus.Text = "No Configurations Exist - Save As New to create one using existing checked boxes";
            }
            else
            {
                DataTable dt = new DataTable("Configurations");
                dt.Columns.Add("ConfigurationName");
                dt.Columns.Add("ConfigurationEntities");

                XmlSerializer deserializer = new XmlSerializer(typeof(RecordCounterConfigurations));
                StreamReader reader = new StreamReader("RecordCounter.Configurations.xml");
                RecordCounterConfigurations rccs = (RecordCounterConfigurations)deserializer.Deserialize(reader);
                reader.Close();

                List<RCConfig> RCCList = rccs.Configurations.ToList();

                foreach (RCConfig config in RCCList)
                {
                    DataRow row = dt.NewRow();
                    row["ConfigurationName"] = config.ConfigurationName;
                    row["ConfigurationEntities"] = config.ConfigurationEntities;

                    dt.Rows.Add(row);
                }

                this.Invoke((MethodInvoker)delegate()
                {
                    dataGridView1.DataSource = dt;
                });
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists("RecordCounter.Configurations.xml"))
            {
                MessageBox.Show("Please create a Configuration first before attempting to Open a Configuration.");
            }
            else
            {                
                main.OpenConfigEntities = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnSaveNewConfiguration_Click(object sender, EventArgs e)
        {
            NewConfigName = "";

            SaveAs saveAs = new SaveAs();
            saveAs.StartPosition = FormStartPosition.CenterParent;
            saveAs.EntityList = CheckedEntities;
            saveAs.main = this.main;
            saveAs.config = this;

            if (saveAs.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists("RecordCounter.Configurations.xml"))
                {
                    // deserialize xml file
                    XmlSerializer deserializer = new XmlSerializer(typeof(RecordCounterConfigurations));
                    StreamReader reader = new StreamReader("RecordCounter.Configurations.xml");
                    RecordCounterConfigurations rccs = (RecordCounterConfigurations)deserializer.Deserialize(reader);
                    reader.Close();

                    List<RCConfig> RCCList = rccs.Configurations.ToList();

                    // create new rccconfig
                    RCConfig newConfig = new RCConfig();
                    newConfig.ConfigurationEntities = CheckedEntities;
                    newConfig.ConfigurationName = NewConfigName;

                    RCCList.Add(newConfig);

                    // save the file
                    XmlSerializer writer = new XmlSerializer(typeof(RecordCounterConfigurations));
                    System.IO.StreamWriter file = new System.IO.StreamWriter("RecordCounter.Configurations.xml");
                    RecordCounterConfigurations rcc = new RecordCounterConfigurations();
                    rcc.Configurations = RCCList.ToArray();
                    writer.Serialize(file, rcc);
                    file.Close();

                    // ReloadGrid();
                    ReloadGrid();
                }
                else
                {
                    RecordCounterConfigurations rccs = new RecordCounterConfigurations();
                    List<RCConfig> RCCList = new List<RCConfig>();
                    // create new rccconfig
                    RCConfig newConfig = new RCConfig();
                    newConfig.ConfigurationEntities = CheckedEntities;
                    newConfig.ConfigurationName = NewConfigName;

                    RCCList.Add(newConfig);

                    // save the file
                    XmlSerializer writer = new XmlSerializer(typeof(RecordCounterConfigurations));
                    System.IO.StreamWriter file = new System.IO.StreamWriter("RecordCounter.Configurations.xml");
                    //RecordCounterConfigurations rcc = new RecordCounterConfigurations();
                    rccs.Configurations = RCCList.ToArray();
                    writer.Serialize(file, rccs);
                    file.Close();

                    // ReloadGrid();
                    ReloadGrid();
                }
            }
            
            #region old code
            /*
            if (!System.IO.File.Exists("RecordCounter.Configurations.xml"))
            {
                //MessageBox.Show("Please create a Configuration first before attempting to Open a Configuration.");

                
                RCConfig c = new RCConfig();
                c.ConfigurationName = "Test Name";
                c.ConfigurationEntities = "a;b;c";
                
               // RCConfig c = new RCConfig("Test Config Name", "a;b;c;d;e;f");

                RCConfig[] items = { c };
                RecordCounterConfigurations rcc = new RecordCounterConfigurations();
                rcc.Configurations = items;
                //List<RCConfig> rccs = new List<RCConfig>() { c };
                
                //rcc.RCConfigs = rccs;

                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(RecordCounterConfigurations));

                System.IO.TextWriter file = new System.IO.StreamWriter("RecordCounter.Configurations.xml");
                writer.Serialize(file, rcc);
                file.Close();
            }
            else
            {

            }
             * */
            #endregion old code
        }

        private void btnOverwriteConfig_Click(object sender, EventArgs e)
        {
            //TODO: get selected row index
            //TODO: deserialize file
            //TODO: edit the index item
            //TODO: serialize / save to file
            //TODO: RealodGrid();
        }
    }

    [Serializable]
    public class RCConfig
    {
        public string ConfigurationName;
        public string ConfigurationEntities;
    }

    [Serializable]
    public class RecordCounterConfigurations
    {
        public RCConfig[] Configurations;
    }  
}
