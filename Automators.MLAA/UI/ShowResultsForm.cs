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
using Automator.DataAccess;
using Entity;
using System.Xml.Linq;
using Engine;

namespace Automator.UI
{
    public partial class ShowResultsForm : Form
    {

        private string _projectPath = @"E:\HackOverflow2018\Hackathon\Progresso\" + "DataSheets";

        public List<TestDataResult> TestDataResults { get; set; }
        public List<string> _moduleList = new List<string>();

        public ShowResultsForm()
        {
            InitializeComponent();
            this.Load += ShowResultsForm_Load;
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            cmbModules.DataSource = _moduleList;
        }

        private void ShowResultsForm_Load(object sender, EventArgs e)
        {
            var col1 = new DataGridViewTextBoxColumn
            {
                Name = "Test Data",
                ValueType = typeof(string)
            };

            col1.AutoSizeMode= DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(col1);

            var col2 = new DataGridViewComboBoxColumn
            {
                Name = "Function",
                ValueType = typeof(string)
            };
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(col2);

            var col3 = new DataGridViewTextBoxColumn
            {
                Name = "Params",
                ValueType = typeof(string)
                
            };

            col3.ReadOnly = true;
            dataGridView1.Columns.Add(col3);

            var col4 = new DataGridViewButtonColumn()
            {
                Name = "Params edit",
                ValueType = typeof(string)
            };
            dataGridView1.Columns.Add(col4);

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

                dataGridView1.Rows.Add(row);
                
            }

            dataGridView1.Refresh();
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure you want to save XML", @"MLATA", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                DBHelper _dbHelper = new DBHelper();


                //Save the xmls
                SaveTCsXml();
                SaveDriverXml();
            }

            if(dialogResult == DialogResult.Cancel)
                Application.Exit();

        }


        private void SaveDriverXml()
        {
            //using (System.IO.StreamWriter file =
            //    new System.IO.StreamWriter(_projectPath + "/" + txtTestCaseID.Text + "Driver.xml"))
            //{

            //}

            //XDocument doc = XDocument.Load(_projectPath + "/" + txtTestCaseID.Text + "Driver.xml");
            //XElement rootElement = doc.Root;
            //XElement root = new XElement("Snippet");
            //root.Add(new XAttribute("name", "name goes here"));
            //root.Add(new XElement("SnippetCode", "SnippetCode"));
            //rooElement.Add(root);
            //doc.Save(spath);
        }

        private void SaveTCsXml()
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(_projectPath + "/" + txtTestCaseID.Text + "TCs.xml"))
            {
                foreach (var testData in TestDataResults)
                        file.WriteLine("TC created");
            }

        }

        private void ModulesXml()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if(senderGrid.CurrentRow != null)
                    ((DataGridViewTextBoxCell)(senderGrid.CurrentRow.Cells[2])).ReadOnly = false;
            }
        }

        //private void UpdateTrainingDataToDB()
        //{
        //    foreach (var _function in _functionsList)
        //    {
        //        string query2 = "Insert into TrainingData values('" + _function.Name + "'," + "'" + _function.Description.Replace("'", "") + "')";
        //        _dbHelper.ExecuteNonQuery(query2);
        //    }
        //}

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
