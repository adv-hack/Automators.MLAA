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
using DevExpress.Data.Helpers;
using Entity;


namespace Automator.UI
{
    public partial class Form1 : Form
    {

        private string projectPath = @"E:\HackOverflow2018\Hackathon\Progresso";
        private string _functionListFilePath;
        private string _moduleListFilePath;

        private List<Entity.Function> functionsList = new List<Function>();
        private List<string> moduleList = new List<string>();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _functionListFilePath = projectPath + @"\ApplicationFiles\functionList.xml";
            _moduleListFilePath = projectPath + @"\ApplicationFiles\module_list.xml";

            ReadFuntions(_functionListFilePath);
            ReadModules(_moduleListFilePath);
        }


        private void ReadFuntions(string funtionpath)
        {
            XDocument xdocument = XDocument.Load(funtionpath);
            IEnumerable<XElement> xmlfunctions = xdocument.Root.Elements();

            foreach (var _function in xmlfunctions.Elements())
            {
                Function func = new Function();
                List<string> parameters = new List<string>();

                func.Name = _function.FirstAttribute.Value;
                func.Description = _function.LastAttribute.Value;
                func.Parameters = parameters;

                if (_function.HasElements)
                {
                    foreach (var element in _function.Elements())
                    {
                        parameters.Add(element.Value);
                    }
                }

                functionsList.Add(func);
            }
        }


        private void ReadModules(string modulepath)
        {
            XDocument xdocument = XDocument.Load(modulepath);
            IEnumerable<XElement> modules = xdocument.Root.Elements();

            foreach (var module in modules)
                moduleList.Add(module.Name.ToString());
        }


    }
}
