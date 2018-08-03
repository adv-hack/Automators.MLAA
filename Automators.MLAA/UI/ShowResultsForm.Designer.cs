namespace Automator.UI
{
    partial class ShowResultsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowResultsForm));
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTestCaseID = new System.Windows.Forms.TextBox();
            this.lblTestCase = new System.Windows.Forms.Label();
            this.cmbModules = new System.Windows.Forms.ComboBox();
            this.lblModuleList = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.testDataResultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.functionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.functionsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.functionsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.functionsBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.analyseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.startupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(545, 48);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(351, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(479, 51);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Description";
            // 
            // txtTestCaseID
            // 
            this.txtTestCaseID.Location = new System.Drawing.Point(324, 48);
            this.txtTestCaseID.Name = "txtTestCaseID";
            this.txtTestCaseID.Size = new System.Drawing.Size(132, 20);
            this.txtTestCaseID.TabIndex = 12;
            // 
            // lblTestCase
            // 
            this.lblTestCase.AutoSize = true;
            this.lblTestCase.Location = new System.Drawing.Point(249, 52);
            this.lblTestCase.Name = "lblTestCase";
            this.lblTestCase.Size = new System.Drawing.Size(69, 13);
            this.lblTestCase.TabIndex = 11;
            this.lblTestCase.Text = "Test Case ID";
            // 
            // cmbModules
            // 
            this.cmbModules.FormattingEnabled = true;
            this.cmbModules.Location = new System.Drawing.Point(88, 48);
            this.cmbModules.Name = "cmbModules";
            this.cmbModules.Size = new System.Drawing.Size(133, 21);
            this.cmbModules.TabIndex = 10;
            // 
            // lblModuleList
            // 
            this.lblModuleList.AutoSize = true;
            this.lblModuleList.Location = new System.Drawing.Point(9, 50);
            this.lblModuleList.Name = "lblModuleList";
            this.lblModuleList.Size = new System.Drawing.Size(73, 13);
            this.lblModuleList.TabIndex = 9;
            this.lblModuleList.Text = "Module Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 76);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(897, 403);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // testDataResultsBindingSource
            // 
            this.testDataResultsBindingSource.DataMember = "TestDataResults";
            this.testDataResultsBindingSource.DataSource = this.analyseBindingSource;
            // 
            // functionsBindingSource
            // 
            this.functionsBindingSource.DataMember = "Functions";
            this.functionsBindingSource.DataSource = this.testDataResultsBindingSource;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(464, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "    Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(339, 491);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = "   Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // functionsBindingSource1
            // 
            this.functionsBindingSource1.DataMember = "Functions";
            this.functionsBindingSource1.DataSource = this.testDataResultsBindingSource;
            // 
            // functionsBindingSource2
            // 
            this.functionsBindingSource2.DataMember = "Functions";
            this.functionsBindingSource2.DataSource = this.testDataResultsBindingSource;
            // 
            // functionsBindingSource3
            // 
            this.functionsBindingSource3.DataMember = "Functions";
            this.functionsBindingSource3.DataSource = this.testDataResultsBindingSource;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 34);
            this.panel1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 23);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(855, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "_";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(37, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "MLATA - Manual Test Case";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(886, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "x";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // analyseBindingSource
            // 
            this.analyseBindingSource.DataSource = typeof(Automator.UI.ShowResultsForm);
            // 
            // startupBindingSource
            // 
            this.startupBindingSource.DataSource = typeof(Automator.UI.AnalyseForm);
            // 
            // ShowResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTestCaseID);
            this.Controls.Add(this.lblTestCase);
            this.Controls.Add(this.cmbModules);
            this.Controls.Add(this.lblModuleList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "ShowResultsForm";
            this.Text = "MLATA";
            this.Load += new System.EventHandler(this.Analyse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtTestCaseID;
        private System.Windows.Forms.Label lblTestCase;
        private System.Windows.Forms.ComboBox cmbModules;
        private System.Windows.Forms.Label lblModuleList;
        private System.Windows.Forms.BindingSource startupBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource analyseBindingSource;
        private System.Windows.Forms.BindingSource testDataResultsBindingSource;
        private System.Windows.Forms.BindingSource functionsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource functionsBindingSource1;
        private System.Windows.Forms.BindingSource functionsBindingSource2;
        private System.Windows.Forms.BindingSource functionsBindingSource3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}