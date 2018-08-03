using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Automator.DataAccess;
using Entity;
using System.Xml.Linq;
using System.Xml.XPath;
using DevExpress.Data.Filtering.Helpers;
using Engine;

namespace Automator.UI
{
    public partial class ShowResultsForm : Form
    {

        private string _projectPath;

        public List<TestDataResult> TestDataResults { get; set; }
        public List<string> _moduleList = new List<string>();
        public string _tcID;
        public string _tcDesc;

        public ShowResultsForm()
        {
            _projectPath = ConfigurationManager.AppSettings["ProjectPath"].ToString() + @"\DataSheets";

            InitializeComponent();
            this.Load += ShowResultsForm_Load;
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            cmbModules.DataSource = _moduleList;
            txtTestCaseID.Text = _tcID;
            txtDescription.Text = _tcDesc;
        }

        private void ShowResultsForm_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn
            {
                Name = "Test Data",
                ValueType = typeof(string)
            };

            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(col1);

            var col2 = new DataGridViewComboBoxColumn
            {
                Name = "Function",
                ValueType = typeof(string)
            };
            dataGridView1.Columns.Add(col2);

            var col3 = new DataGridViewTextBoxColumn
            {
                Name = "Params",
                ValueType = typeof(string)
                
            };

            col3.ReadOnly = false;
            dataGridView1.Columns.Add(col3);

            var col4 = new DataGridViewButtonColumn()
            {
                Name = "Params edit",
                ValueType = typeof(string)
            };
            dataGridView1.Columns.Add(col4);

            var col5 = new DataGridViewTextBoxColumn
            {
                Name = "Order",
                ValueType = typeof(string)
            };
            
            dataGridView1.Columns.Add(col5);
            dataGridView1.Columns["Order"].Visible = false;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.Refresh();

            foreach (var data in TestDataResults)
            {
                var row = (DataGridViewRow)(dataGridView1.Rows[0].Clone());

                var textCell = (DataGridViewTextBoxCell)(row.Cells[0]);
                textCell.ValueType = typeof(string);
                textCell.Value = data.TestData;

                var comboCell = (DataGridViewComboBoxCell)(row.Cells[1]);
                comboCell.ValueType = typeof(string);
                comboCell.DataSource = data.Functions.OrderByDescending(o => o.Score).Select(d => d.Name).ToList();
                comboCell.Value = data.Functions.OrderByDescending(o => o.Score).Take(1).Select(d => d.Name).FirstOrDefault();
                

                var textCel3 = (DataGridViewTextBoxCell)(row.Cells[2]);
                textCel3.ValueType = typeof(string);
                textCel3.Value = string.Join(",", data.SelectedParams);

                var cel4 = (DataGridViewButtonCell) (row.Cells[3]);
                cel4.Value = "Edit Params";

                var textCell5 = (DataGridViewTextBoxCell)(row.Cells[4]);
                textCell5.ValueType = typeof(string);
                textCell5.Value = data.Order;
                dataGridView1.Rows.Add(row);
                
            }

            dataGridView1.Refresh();
            dataGridView1.AllowUserToAddRows = false;
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure you want to save XML", @"MLATA", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                //Update training data
                DBHelper _dbHelper = new DBHelper();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var selectedFunction = from r in TestDataResults
                                          where r.Order == (int)row.Cells["Order"].Value
                                          select r.SelectedFunction;
                    
                    if (!selectedFunction.First().Equals(((string)row.Cells["Function"].Value)))
                    {
                        string query = "Insert into TrainingData values('" + (string)row.Cells["Function"].Value + "'," + "'" + (string)row.Cells["Test Data"].Value + "')";
                        _dbHelper.ExecuteNonQuery(query);
                    }
                    
                }


                //Save the xmls
                  SaveTCsXml();
                  SaveDriverXml();
                  SaveMainDriverXml();
            }

            if(dialogResult == DialogResult.Cancel)
                Application.Exit();

        }

        private void SaveDriverXml()
        {
            try
            {
                string xmlPath = _projectPath + "/" + cmbModules.SelectedValue + "Driver.xml";
                XDocument doc = XDocument.Load(xmlPath);
                XElement rootElement = doc.Root;
                XElement newElement = new XElement(txtDescription.Text);

                newElement.Add(new XElement("Description", txtDescription.Text));
                newElement.Add(new XElement("Run", "Yes"));

                rootElement.Add(newElement);
                doc.Save(xmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveTCsXml()
        {
           try
            {
                string xmlPath = _projectPath + "/" + cmbModules.SelectedValue + "TCs.xml";
                XDocument doc = XDocument.Load(xmlPath);
                XElement element = doc.XPathSelectElement(cmbModules.SelectedValue + "/"+ txtTestCaseID.Text);

                if (element != null)
                {
                    foreach (var result in TestDataResults)
                    {
                        string elementText = result.Functions.First().Name + "(" +
                                             string.Join(",", result.SelectedParams);

                        XElement newElement = new XElement("AT");
                        newElement.Value = elementText;
                        element.Add(newElement);

                    }
                }

                doc.Save(xmlPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveMainDriverXml()
        {
            
        }

       private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.CurrentRow != null)
                    ((DataGridViewTextBoxCell)(senderGrid.CurrentRow.Cells[2])).ReadOnly = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
