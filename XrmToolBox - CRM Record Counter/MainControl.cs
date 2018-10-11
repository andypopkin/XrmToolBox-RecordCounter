// PROJECT : XrmToolBox___CRM_Record_Counter
// This project was developed by Tanguy Touzard
// CODEPLEX: http://xrmtoolbox.codeplex.com
// BLOG: http://mscrmtools.blogspot.com

using AndyPopkin.RecordCounter;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McTools.Xrm.Connection;
using Microsoft.Win32;
using System.Globalization;

namespace XrmToolBox___CRM_Record_Counter
{
    public partial class MainControl : PluginControlBase, IPayPalPlugin, IGitHubPlugin, IHelpPlugin
    {
        //private Settings mySettings;
        #region Custom Variables

        //public string openConfigEntities = "";        
        private string openConfigEntities;
        public string OpenConfigEntities{ get { return openConfigEntities; } set { openConfigEntities = value; } }
        DataTable dtEntities;

        #endregion Custom Variables

        public MainControl()
        {
            InitializeComponent();

            // Disable buttons until Entities are loaded
            tsbConfiguration.Enabled 
            = tsbConfiguration.Visible
            = toolStripTextBox1.Enabled
            = tsbGetCounts.Enabled
            = tsbCheckAll.Enabled
            = tsbUncheckAll.Enabled
            = btnExport.Enabled
            = false;
        }

        private void MainControl_Load(object sender, System.EventArgs e)
        {
            //TODO: Turn on the Configuration Feature
            
            ExecuteMethod(loadEntities);
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            //if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            //{
            //    mySettings = new Settings();
            //    dictMimeToFile = new Dictionary<string, string>();

            //    LogWarning("Settings not found => a new settings file has been created!");
            //}
            //else
            //{
            //    LogInfo("Settings found and loaded");
            //}
        }     
        
        #region Load Entities

        private void loadEntities()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving Entities...",
                Work = (worker, args) =>
                {
                    #region Reset Variables

                    string filter = tscmbFilter.Text;
                    MetadataFilterExpression entityFilter = new MetadataFilterExpression(LogicalOperator.And);
                    dtEntities = new DataTable();
                    toolStripTextBox1.Enabled = false;

                    #endregion Reset Variables

                    #region Get Entities

                    switch (filter)
                    {
                        case "All Entities":
                            break;
                        case "Custom Entities":
                            entityFilter.Conditions.Add(new MetadataConditionExpression("IsCustomEntity", MetadataConditionOperator.Equals, true));
                            break;
                        case "CRM Entities":
                            entityFilter.Conditions.Add(new MetadataConditionExpression("IsCustomEntity", MetadataConditionOperator.Equals, false));
                            break;
                        case "System Entities":
                            entityFilter.Conditions.Add(new MetadataConditionExpression("IsManaged", MetadataConditionOperator.Equals, true));
                            break;
                        default:
                            MessageBox.Show("Error: Entities Drop Down was changed, please restart the tool and try again.");
                            return;
                    }                

                    #region Entity Metadata Request

                    EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
                    {
                        Criteria = entityFilter
                    };
                    RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest()
                    {
                        Query = entityQueryExpression,
                        ClientVersionStamp = null
                    };
                    RetrieveMetadataChangesResponse _allEntitiesResp = (RetrieveMetadataChangesResponse)Service.Execute(retrieveMetadataChangesRequest);

                    worker.ReportProgress(0, string.Format("Metadata has been retrieved!"));

                    #endregion Entity Metadata Request

                    #endregion Get Entities

                    #region Entities to DataTable
                                        
                    dtEntities.Columns.Add("DisplayName", typeof(string));
                    dtEntities.Columns.Add("SchemaName", typeof(string));
                    dtEntities.Columns.Add("Get Count", typeof(bool));
                    dtEntities.Columns.Add("Count", typeof(int));

                    //dataGridView1.DataSource = e.Result;
                    foreach (var item in _allEntitiesResp.EntityMetadata)
                    {
                        DataRow row = dtEntities.NewRow();
                        row["DisplayName"] = item.DisplayName.LocalizedLabels.Count > 0 ? item.DisplayName.UserLocalizedLabel.Label.ToString() : null;
                        row["SchemaName"] = item.LogicalName;
                        row["Get Count"] = false;
                        row["Count"] = DBNull.Value;

                        dtEntities.Rows.Add(row);
                    }                

                    args.Result = dtEntities;

                    #endregion Entities to DataTable
                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result;
                    if (result != null)
                    {
                        //MessageBox.Show($"Found {result.Entities.Count} accounts");
                        LoadGridData((DataTable)args.Result);
                        toolStripTextBox1.Enabled = tsbGetCounts.Enabled = tsbCheckAll.Enabled = tsbUncheckAll.Enabled = btnExport.Enabled = true;
                    }
                }
            });
        }

        #endregion Load Entities

        #region Process Get Counts

        private void ProcessGetCounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving Counts...",
                Work = (worker, args) =>
                {
                    #region Reset Variables

                    toolStripTextBox1.Enabled = false;
                    Dictionary<int, string> selectedEntities = new Dictionary<int, string>();
                    dataGridView1.EndEdit();
                    DataGridViewRowCollection rows = null;
                    rows = dataGridView1.Rows;
                    int rowCount = 0;

                    #endregion Reset Variables

                    #region Get Counts

                    foreach (DataGridViewRow row in rows)
                    {
                        var cell = row.Cells[2];
                        if (cell != null)
                        {
                            if ((System.Boolean)cell.Value != null && (System.Boolean)cell.Value == true)
                            {
                                //selectedEntities.Add(rowCount, row.Cells[1].Value.ToString());
                                #region Get Record Count
                                try
                                {
                                    QueryExpression query = new QueryExpression(row.Cells[1].Value.ToString());
                                    query.PageInfo = new PagingInfo();
                                    query.PageInfo.PageNumber = 1;
                                    query.PageInfo.PagingCookie = null;
                                    query.PageInfo.Count = 5000;
                                    int recordCounter = 0;

                                    while (true)
                                    {
                                        EntityCollection results = Service.RetrieveMultiple(query);

                                        recordCounter += results.Entities.Count;
                                        

                                        // Check for more records, if it returns true.
                                        if (results.MoreRecords)
                                        {
                                            // Increment the page number to retrieve the next page.
                                            query.PageInfo.PageNumber++;
                                            // Set the paging cookie to the paging cookie returned from current results.
                                            query.PageInfo.PagingCookie = results.PagingCookie;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        worker.ReportProgress(0, $"Retrieving Counts...{Environment.NewLine}Entity: {row.Cells[1].Value.ToString()}{Environment.NewLine}{recordCounter.ToString("#,#", CultureInfo.InvariantCulture)} Records");
                                    }

                                    //this.Invoke((MethodInvoker)delegate ()
                                    //{
                                        row.Cells[3].Value = recordCounter;
                                    //});
                                }
                                catch (Exception)
                                {
                                    //this.Invoke((MethodInvoker)delegate ()
                                    //{
                                        row.Cells[3].Value = -1;
                                    //});
                                    //throw;
                                }
                                

                                //return recordCounter;

                                #endregion Get Record Count
                            }
                        }
                        rowCount++;
                    }
                    //worker.ReportProgress(0, string.Format("Total Entities Selected: {0}", selectedEntities.Count));

                    args.Result = true;

                    #endregion Get Counts
                },
                ProgressChanged = e =>
                {
                    // If progress has to be notified to user, use the following method:
                    SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result;
                    if (result != null)
                    {
                        //MessageBox.Show($"Found {result.Entities.Count} accounts");
                        toolStripTextBox1.Enabled = true;

                    }
                }
            });
        }

        #endregion Process Get Counts
        
        #region Other Buttons

        private void TsbClose_Click(object sender, System.EventArgs e)
        {
            CloseTool();
        }

        private void TsbLoadData_Click(object sender, System.EventArgs e)
        {
            ExecuteMethod(loadEntities);
        }

        private void tsbGetCounts_Click(object sender, System.EventArgs e)
        {
            ExecuteMethod(ProcessGetCounts);
        }

        //-----

        private void tsbCheckAll_Click_1(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                    chk.Value = true;
                }
            });
        }

        private void tsbUncheckAll_Click_1(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate()
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                    chk.Value = false;
                }
            });
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {           
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<string> export = new List<string>();
                export.Add("Entity Display Name, Entity Schema Name, Count,");

                int rowCount = 0;               

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cell = row.Cells[2];
                    if (cell != null)
                    {
                        if ((System.Boolean)cell.Value != null && (System.Boolean)cell.Value == true)
                        {
                            export.Add(string.Format("{0},{1},{2},", row.Cells[0].Value, row.Cells[1].Value, row.Cells[3].Value));
                        }
                    }
                    rowCount++;
                }

                File.WriteAllLines(saveFileDialog1.FileName.ToString(), export);            
            }           
        }   

        private void tsbConfiguration_Click(object sender, EventArgs e)
        {
            this.Focus();
            Configuration config = new Configuration();
            config.StartPosition = FormStartPosition.CenterParent;

            // make the entity string
            string ce = "";

            //TODO: this only grabs the last one when you get focus away from the selected row - is this the same for Count button?
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cell = row.Cells[2];
                if (cell != null)
                {
                    if ((System.Boolean)cell.Value != null && (System.Boolean)cell.Value == true)
                    {
                        ce = ce + (row.Cells[1].Value + ";");
                    }
                }                
            }
            ce = ce.TrimEnd(';');
            config.CheckedEntities = ce;

            openConfigEntities = "";
            config.main = this;            

            if (config.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openConfigEntities);
                List<string> entities = new List<string>(openConfigEntities.Split(';'));

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (entities.Contains(row.Cells[1].Value.ToString()))
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                                chk.Value = true;
                            });
                        }
                        else
                        {
                            this.Invoke((MethodInvoker)delegate()
                            {
                                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[2];
                                chk.Value = false;
                            });
                        }
                    }
                }
            }
        }

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == " search")
            {
                toolStripTextBox1.Clear();
            }
        }

        private void ToolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text == "" && dtEntities.Rows.Count > 0 && dataGridView1.Rows.Count != dtEntities.Rows.Count)
            {
                LoadGridData(dtEntities);
            }
            else if (toolStripTextBox1.Text != " search" && toolStripTextBox1.Text != "" && dtEntities.Rows.Count > 0)
            {
                string searchValue = toolStripTextBox1.Text.ToLower();
                //var filtered = dtEntities.Where(r => r.Field<String>("DisplayName").Contains(searchValue) || r.Field<String>("SchemaName").Contains(searchValue));
                try
                {
                    DataRow[] filtered = dtEntities.Select("DisplayName LIKE '%" + searchValue + "%' OR SchemaName LIKE '%" + searchValue + "%'");
                    if (filtered.Count() > 0)
                    {
                        LoadGridData(filtered.CopyToDataTable());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Search Character. Please do not use ' [ ] within searches.");
                    //throw;
                }
            }
        }
        private void tsbtnHelp_Click(object sender, EventArgs e)
        {
            string message = "";

            message += "1. Select an Entity Filter and click Load Entities";
            message += Environment.NewLine;
            message += "2. Click the checkbox on any entities that you would like to count";
            message += Environment.NewLine;
            message += "3. Search is wildcard already so you only need to type in the text you want to search for";
            message += Environment.NewLine;
            message += "4. Click Get Counts when Ready";
            message += Environment.NewLine;
            message += "5. If you get a -1 count that means the entity is not queryable";
            message += Environment.NewLine;
            message += Environment.NewLine;
            message += "If you have any issues please log them via GitHub and or contact me at andrewopopkin@gmail.com";

            MessageBox.Show(message);
        }

        #endregion Other Buttons

        #region Custom Helper Methods

        private void LoadGridData(DataTable dt)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Regular);
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Display Name";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].HeaderText = "Schema Name";
            dataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "N0";
        }

        #endregion Custom Helper Methods
        
        #region XrmToolBox Methods

        #region Who Am I Sample

        public void ProcessWhoAmI()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        private void BtnWhoAmIClick(object sender, EventArgs e)
        {
            ExecuteMethod(ProcessWhoAmI);
        }

        #endregion Who Am I Sample

        #region Github implementation
        
        public string RepositoryName
        {
            get { return "XrmToolBox-RecordCounter"; }
        }

        public string UserName
        {
            get { return "andypopkin"; }
        }

        #endregion Github implementation

        #region CodePlex implementation
        
        public string CodePlexUrlName
        {
            get { return "CodePlex"; }
        }

        #endregion CodePlex implementation

        #region PayPal implementation

        public string DonationDescription
        {
            get { return "Donate to inspire Andy to build more XrmToolBox tools!"; }
        }

        public string EmailAccount
        {
            get { return "fromasta@gmail.com"; }
        }

        #endregion PayPal implementation

        #region Help implementation
        // TODO - Help
        public string HelpUrl
        {
            get { return "https://github.com/andypopkin/XrmToolBox-RecordCounter/issues"; }
        }


        #endregion Help implementation

        #endregion XrmToolBox Methods        

        
    }
}
