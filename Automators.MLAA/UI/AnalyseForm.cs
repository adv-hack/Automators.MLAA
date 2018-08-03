using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Automator.DataAccess;
using DevExpress.Data.Helpers;
using Engine;
using Entity;
using Utility;


namespace Automator.UI
{
    public partial class AnalyseForm : Form
    {
        private string _projectPath;
        private string _moduleListFilePath;

        public List<string> _moduleList = new List<string>();
        public List<TestDataResult> _testdataresult = new List<TestDataResult>();

        private string _currentModuleName = string.Empty;

        private Categoriser categoriser;

        public AnalyseForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _projectPath = ConfigurationManager.AppSettings["ProjectPath"];
            _moduleListFilePath = _projectPath + @"\ApplicationFiles\module_list.xml";
            ReadModules(_moduleListFilePath);
            cmbModules.DataSource = _moduleList;
        }

        private void ReadModules(string modulepath)
        {
            XDocument xdocument = XDocument.Load(modulepath);
            IEnumerable<XElement> modules = xdocument.Root.Elements();

            foreach (var module in modules)
                _moduleList.Add(module.Name.ToString());
        }

        private void cmbModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentModuleName = cmbModules.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtcasesteps.Clear();
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            categoriser = new Categoriser();
            _testdataresult = categoriser.Categorise(txtcasesteps.Lines.ToList<string>());

            ShowResultsForm showResults = new ShowResultsForm();
            showResults.TestDataResults = _testdataresult;
            showResults._moduleList = _moduleList;
            showResults._tcID = txtTestCaseID.Text;
            showResults._tcDesc = txtDescription.Text;
            showResults.Show();
        }
    }
}
