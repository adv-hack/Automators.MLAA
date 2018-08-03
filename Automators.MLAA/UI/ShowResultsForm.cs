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
using Engine;

namespace Automator.UI
{
    public partial class ShowResultsForm : Form
    {

        private readonly string _projectPath;
        private readonly string _projectPathDataSheets;
        public List<TestDataResult> TestDataResults { get; set; }
        public List<string> ModuleList = new List<string>();
        public string TcId;
        public string TcDesc;
        public Form RefFormAnalyzeForm { get; set; }

        public ShowResultsForm()
        {
            _projectPath = ConfigurationManager.AppSettings["ProjectPath"];
            _projectPathDataSheets = _projectPath  + @"\DataSheets";


            InitializeComponent();

            Icon icon = Icon.ExtractAssociatedIcon("images\\desktop_icon_new.ico");

            this.Icon = icon;

            this.Load += ShowResultsForm_Load;
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            cmbModules.DataSource = ModuleList;
            txtTestCaseID.Text = TcId;
            txtDescription.Text = TcDesc;
        }

        private void ShowResultsForm_Load(object sender, EventArgs e)
        {

            var col5 = new DataGridViewTextBoxColumn
            {
                Name = " ",
                ValueType = typeof(string),
                Width = 35
            };

            dataGridView1.Columns.Add(col5);

            var col1 = new DataGridViewTextBoxColumn
            {
                Name = "Test Data",
                ValueType = typeof(string),
                Width = 300
            };

            dataGridView1.Columns.Add(col1);

            var col2 = new DataGridViewComboBoxColumn
            {
                Name = "Function",
                ValueType = typeof(string),
                Width = 200
            };
            dataGridView1.Columns.Add(col2);

            var col3 = new DataGridViewTextBoxColumn
            {
                Name = "Params",
                ValueType = typeof(string),
                Width = 200
            };

            dataGridView1.Columns.Add(col3);

            var col4 = new DataGridViewButtonColumn()
            {
                Name = " ",
                ValueType = typeof(string),
                Width = 30
            };

            dataGridView1.Columns.Add(col4);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.Refresh();

            foreach (var data in TestDataResults)
            {
                var row = (DataGridViewRow)(dataGridView1.Rows[0].Clone());

                var textCell5 = (DataGridViewTextBoxCell)(row.Cells[0]);
                textCell5.ValueType = typeof(string);
                textCell5.Value = data.Order;
                dataGridView1.Rows.Add(row);

                var textCell = (DataGridViewTextBoxCell)(row.Cells[1]);
                textCell.ValueType = typeof(string);
                textCell.Value = data.TestData;

                var comboCell = (DataGridViewComboBoxCell)(row.Cells[2]);
                comboCell.ValueType = typeof(string);
                comboCell.DataSource = data.Functions.OrderByDescending(o => o.Score).Select(d => d.Name).ToList();
                comboCell.Value = data.Functions.OrderByDescending(o => o.Score).Take(1).Select(d => d.Name).FirstOrDefault();
                

                var textCel3 = (DataGridViewTextBoxCell)(row.Cells[3]);
                textCel3.ValueType = typeof(string);
                textCel3.Value = string.Join(",", data.SelectedParams);

                var cel4 = (DataGridViewButtonCell) (row.Cells[4]);
                cel4.Value = "...";
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
                var _dbHelper = new DBHelper();

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
                string xmlPath = _projectPathDataSheets + "/" + cmbModules.SelectedValue + "Driver.xml";
                XDocument doc = XDocument.Load(xmlPath);
                XElement rootElement = doc.Root;
                XElement newElement = new XElement(txtTestCaseID.Text);

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
                var xmlPath = _projectPathDataSheets + "/" + cmbModules.SelectedValue + "TCs.xml";

                if (!File.Exists(xmlPath))
                {

                    var newDoc = new XmlDocument();
                    newDoc.LoadXml($"<{cmbModules.SelectedValue.ToString()}></{cmbModules.SelectedValue.ToString()}>");

                    var writer = new XmlTextWriter(xmlPath, null) { Formatting = Formatting.Indented };
                    newDoc.Save(writer);
                    writer.Close();
                }

                var doc = XDocument.Load(xmlPath);

                var moduleNode = doc.XPathSelectElement(cmbModules.SelectedValue.ToString());

                var testCaseNode = doc.XPathSelectElement(cmbModules.SelectedValue + "/" + txtTestCaseID.Text);

                if (testCaseNode == null)
                {
                    var newTestCaseNode = new XElement(txtTestCaseID.Text);

                    moduleNode?.Add(newTestCaseNode);
                }

                testCaseNode = doc.XPathSelectElement(cmbModules.SelectedValue + "/" + txtTestCaseID.Text);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    var elementText = (string)row.Cells["Function"].Value;

                    var param = (string)row.Cells["Params"].Value;

                    var params1 = "";

                    if (!string.IsNullOrEmpty(param))
                    {
                        param = $"{param}";

                        foreach (var para in param.Split(','))
                        {
                            params1 += $"\"{para}\",";
                        }

                        params1 = params1.Substring(0, params1.Length - 1);
                    }

                    var newElement = new XElement("AT") { Value = $"{elementText}({params1})" };
                    testCaseNode?.Add(newElement);
                }

                doc.Save(xmlPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveMainDriverXml()
        {
            try
            {
                var xmlPath = _projectPath + "\\MainDriver.xml";

                if (!File.Exists(xmlPath))
                {

                    var newDoc = new XmlDocument();
                    newDoc.LoadXml("<MainDriver></MainDriver>");

                    var writer = new XmlTextWriter(xmlPath, null) {Formatting = Formatting.Indented};
                    newDoc.Save(writer);
                    writer.Close();
                }

                var xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

                var root = xmlDoc.DocumentElement;
                var nodeToFind = root?.SelectSingleNode(cmbModules.SelectedValue.ToString());

                if (nodeToFind != null)
                {
                    return;
                }

                var doc = XDocument.Load(xmlPath);
                var rootElement = doc.Root;
                var newElement = new XElement(cmbModules.SelectedValue.ToString());

                newElement.Add(new XElement("Driver", $"{cmbModules.SelectedValue.ToString()}Driver.xml"));
                newElement.Add(new XElement("TestCaseFile", $"{cmbModules.SelectedValue.ToString()}TCs.xml"));
                newElement.Add(new XElement("Run", "Yes"));

                rootElement?.Add(newElement);
                doc.Save(xmlPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.CurrentRow != null)
                    ((DataGridViewTextBoxCell)(senderGrid.CurrentRow.Cells[3])).ReadOnly = false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you wan to Exit the application?", "Exit Application", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var inputDialog = new InputDialog();

                if (senderGrid.CurrentRow != null)
                    inputDialog.Params = senderGrid.CurrentRow.Cells[3].Value.ToString();

                DialogResult result = inputDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (senderGrid.CurrentRow != null)
                        ((DataGridViewTextBoxCell)(senderGrid.CurrentRow.Cells[3])).Value = inputDialog.Params;

                    inputDialog.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RefFormAnalyzeForm.Show();
            this.Close();
        }
    }
}