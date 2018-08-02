using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel.Design;
using System.Configuration;
using System.Xml.Linq;
using Automator.DataAccess;
using Engine;
using Entity;
using Utility;

namespace Automator.UI
{
    public partial class ProjectPathForm : Form
    {
        private string _projectPath = @"E:\HackOverflow2018\Hackathon\Progresso";
        private string _functionListFilePath =  @"\ApplicationFiles\functionList.xml";
        

        private List<Function> _functionsList = new List<Function>();

        DBHelper _dbHelper = new DBHelper();

        public ProjectPathForm()
        {
            InitializeComponent();
        }

        private void ProjectPathForm_Load(object sender, EventArgs e)
        {
          //  _projectPath = ConfigurationManager.ConnectionStrings["ProjectPath"].ConnectionString;
            txtProjectPath.Text = _projectPath;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _functionListFilePath = _projectPath + @"\ApplicationFiles\functionList.xml";
           
            if (_projectPath != String.Empty)
            {
                //ReadFuntions(_functionListFilePath);
                //AddInitialFuntionsDataToDB();
                //AddTrainingDataToDB();
            }

            AnalyseForm startupForm = new AnalyseForm();
            startupForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
                txtProjectPath.Text = folderBrowserDialog.SelectedPath;

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
                func.Description = _function.LastAttribute.Value.Replace("Description:", "");
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

        private void AddInitialFuntionsDataToDB()
        {
            foreach (var _function in _functionsList)
            {
                string parameters = String.Empty;

                if (_function.Parameters != null)
                    foreach (var param in _function.Parameters)
                        parameters += param + " ";

                string query = "Insert into Functions values('" + _function.Name + "'," + "'" + parameters + "')";
                _dbHelper.ExecuteNonQuery(query);
            }
        }

        private void AddTrainingDataToDB()
        {
            foreach (var _function in _functionsList)
            {
                string query1 = "Insert into TrainingData values('" + _function.Name + "'," + "'" + _function.Name.ToLowercaseNamingConvention(true) + "')";
                _dbHelper.ExecuteNonQuery(query1);

                string query2 = "Insert into TrainingData values('" + _function.Name + "'," + "'" + _function.Description.Replace("'", "") + "')";
                _dbHelper.ExecuteNonQuery(query2);
            }
        }
    }
}
