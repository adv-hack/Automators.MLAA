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
using Entity;

namespace Automator.UI
{
    public partial class AnalyseForm : Form
    {

        private string _projectPath = @"E:\HackOverflow2018\Hackathon\Progresso\" + "DataSheets";

        public List<TestDataResult> TestDataResults { get; set; }
        public List<string> _moduleList = new List<string>();

        public AnalyseForm()
        {
            InitializeComponent();
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            cmbModules.DataSource = _moduleList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Are you sure you want to save XML", @"MLATA", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.OK)
            {
                //Save the xmls
                SaveTCsXml();
                SaveDriverXml();
            }

            if(dialogResult == DialogResult.Cancel)
                Application.Exit();

        }


        private void SaveDriverXml()
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(_projectPath + "/" + txtTestCaseID.Text + "Driver.xml"))
            {
                    file.WriteLine("Driver file created");
            }
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
    }
}
