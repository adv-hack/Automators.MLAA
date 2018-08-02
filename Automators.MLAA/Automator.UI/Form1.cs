using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automator.UI
{
    public partial class Form1 : Form
    {

        private string projectPath = @"E:\HackOverflow2018\Hackathon\Progresso";
        private string _functionListFilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _functionListFilePath = projectPath + @"\ApplicationFiles\functionList.xml";
        }

        
    }
}
