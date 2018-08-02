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
    public partial class StartupForm : Form
    {
        private string _projectPath = @"E:\HackOverflow2018\Hackathon\Progresso";
        private string _functionListFilePath;
        private string _moduleListFilePath;

        public List<Function> _functionsList = new List<Function>();
        public List<string> _moduleList = new List<string>();
        public List<TestDataResult> _testdataresult = new List<TestDataResult>();

        private string _currentModuleName = string.Empty;

        DBHelper dbHelper = new DBHelper();
        Categoriser categoriser = new Categoriser();

        public StartupForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _functionListFilePath = _projectPath + @"\ApplicationFiles\functionList.xml";
            _moduleListFilePath = _projectPath + @"\ApplicationFiles\module_list.xml";

            ReadFuntions(_functionListFilePath);
            ReadModules(_moduleListFilePath);

            cmbModules.DataSource = _moduleList;
        }


        private void ReadFuntions(string functionpath)
        {
            XDocument xdocument = XDocument.Load(functionpath);
            IEnumerable<XElement> xmlfunctions = xdocument.Root.Elements();

            foreach (var _function in xmlfunctions.Elements())
            {
                Function func = new Function();
                List<string> parameters = new List<string>();

                func.Name = _function.FirstAttribute.Value;
                func.Description = _function.LastAttribute.Value.Replace("Description:","");
                func.Parameters = parameters;

                if (_function.HasElements)
                {
                    foreach (var element in _function.Elements())
                    {
                        parameters.Add(element.Value);
                    }
                }

                _functionsList.Add(func);
            }
        }


        private void ReadModules(string modulepath)
        {
            XDocument xdocument = XDocument.Load(modulepath);
            IEnumerable<XElement> modules = xdocument.Root.Elements();

            foreach (var module in modules)
                _moduleList.Add(module.Name.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var _function in _functionsList)
            {
                string parameters = String.Empty;

                if (_function.Parameters != null)
                    foreach (var param in _function.Parameters)
                        parameters += param + " ";

                string query = "Insert into Functions values('" + _function.Name + "'," + "'" + parameters + "')";
                dbHelper.ExecuteNonQuery(query);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var _function in _functionsList)
            {
                string query1 = "Insert into TrainingData values('" + _function.Name + "'," + "'" + _function.Name.ToLowercaseNamingConvention(true) + "')";
                dbHelper.ExecuteNonQuery(query1);

                string query2 = "Insert into TrainingData values('" + _function.Name + "'," + "'" + _function.Description.Replace("'","") + "')";
                dbHelper.ExecuteNonQuery(query2);
            }
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
            _testdataresult = categoriser.Categorise(txtcasesteps.Lines.ToList<string>());

            AnalyseForm analyse = new AnalyseForm();
            analyse.TestDataResults = _testdataresult;
            analyse._moduleList = _moduleList;

            analyse.Show();
        }
    }
}
