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

            Icon icon = Icon.ExtractAssociatedIcon("images\\desktop_icon_new.ico");

            this.Icon = icon;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //empty implementation
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

            var showResults = new ShowResultsForm
            {
                TestDataResults = _testdataresult,
                ModuleList = _moduleList,
                TcId = txtTestCaseID.Text,
                TcDesc = txtDescription.Text,
                RefFormAnalyzeForm = this
            };

            this.Visible = false;
            showResults.Show();
        }

        private void lblGuidelines_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Test cases should always be added in new line.  Parameter values should be in double quotes.", "Guidelines", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you wan to Exit the application?", "Exit Application", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
