namespace Automator.UI
{
    partial class AnalyseForm
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtTestCaseID = new System.Windows.Forms.TextBox();
            this.lblTestCase = new System.Windows.Forms.Label();
            this.cmbModules = new System.Windows.Forms.ComboBox();
            this.lblModuleList = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.testDataResultsBindingSource = new System.Windows.Forms.BindingSource();
            this.analyseBindingSource = new System.Windows.Forms.BindingSource();
            this.startupBindingSource = new System.Windows.Forms.BindingSource();
            this.functionsBindingSource = new System.Windows.Forms.BindingSource();
            this.selectedFunctionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectedScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testDataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataResultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(545, 35);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(351, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(479, 38);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Description";
            // 
            // txtTestCaseID
            // 
            this.txtTestCaseID.Location = new System.Drawing.Point(324, 35);
            this.txtTestCaseID.Name = "txtTestCaseID";
            this.txtTestCaseID.Size = new System.Drawing.Size(132, 20);
            this.txtTestCaseID.TabIndex = 12;
            // 
            // lblTestCase
            // 
            this.lblTestCase.AutoSize = true;
            this.lblTestCase.Location = new System.Drawing.Point(249, 38);
            this.lblTestCase.Name = "lblTestCase";
            this.lblTestCase.Size = new System.Drawing.Size(69, 13);
            this.lblTestCase.TabIndex = 11;
            this.lblTestCase.Text = "Test Case ID";
            // 
            // cmbModules
            // 
            this.cmbModules.FormattingEnabled = true;
            this.cmbModules.Location = new System.Drawing.Point(88, 34);
            this.cmbModules.Name = "cmbModules";
            this.cmbModules.Size = new System.Drawing.Size(133, 21);
            this.cmbModules.TabIndex = 10;
            // 
            // lblModuleList
            // 
            this.lblModuleList.AutoSize = true;
            this.lblModuleList.Location = new System.Drawing.Point(9, 38);
            this.lblModuleList.Name = "lblModuleList";
            this.lblModuleList.Size = new System.Drawing.Size(73, 13);
            this.lblModuleList.TabIndex = 9;
            this.lblModuleList.Text = "Module Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedFunctionDataGridViewTextBoxColumn,
            this.selectedScoreDataGridViewTextBoxColumn,
            this.orderDataGridViewTextBoxColumn,
            this.testDataDataGridViewTextBoxColumn,
            this.Column1});
            this.dataGridView1.DataSource = this.testDataResultsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(829, 372);
            this.dataGridView1.TabIndex = 15;
            // 
            // testDataResultsBindingSource
            // 
            this.testDataResultsBindingSource.DataMember = "TestDataResults";
            this.testDataResultsBindingSource.DataSource = this.analyseBindingSource;
            // 
            // analyseBindingSource
            // 
            this.analyseBindingSource.DataSource = typeof(Automator.UI.AnalyseForm);
            // 
            // startupBindingSource
            // 
            this.startupBindingSource.DataSource = typeof(Automator.UI.StartupForm);
            // 
            // functionsBindingSource
            // 
            this.functionsBindingSource.DataMember = "Functions";
            this.functionsBindingSource.DataSource = this.testDataResultsBindingSource;
            // 
            // selectedFunctionDataGridViewTextBoxColumn
            // 
            this.selectedFunctionDataGridViewTextBoxColumn.DataPropertyName = "SelectedFunction";
            this.selectedFunctionDataGridViewTextBoxColumn.HeaderText = "SelectedFunction";
            this.selectedFunctionDataGridViewTextBoxColumn.Name = "selectedFunctionDataGridViewTextBoxColumn";
            // 
            // selectedScoreDataGridViewTextBoxColumn
            // 
            this.selectedScoreDataGridViewTextBoxColumn.DataPropertyName = "SelectedScore";
            this.selectedScoreDataGridViewTextBoxColumn.HeaderText = "SelectedScore";
            this.selectedScoreDataGridViewTextBoxColumn.Name = "selectedScoreDataGridViewTextBoxColumn";
            // 
            // orderDataGridViewTextBoxColumn
            // 
            this.orderDataGridViewTextBoxColumn.DataPropertyName = "Order";
            this.orderDataGridViewTextBoxColumn.HeaderText = "Order";
            this.orderDataGridViewTextBoxColumn.Name = "orderDataGridViewTextBoxColumn";
            // 
            // testDataDataGridViewTextBoxColumn
            // 
            this.testDataDataGridViewTextBoxColumn.DataPropertyName = "TestData";
            this.testDataDataGridViewTextBoxColumn.HeaderText = "TestData";
            this.testDataDataGridViewTextBoxColumn.Name = "testDataDataGridViewTextBoxColumn";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 472);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 524);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTestCaseID);
            this.Controls.Add(this.lblTestCase);
            this.Controls.Add(this.cmbModules);
            this.Controls.Add(this.lblModuleList);
            this.Name = "Analyse";
            this.Text = "Analyse";
            this.Load += new System.EventHandler(this.Analyse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataResultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.analyseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionsBindingSource)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedFunctionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn selectedScoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testDataDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource functionsBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
    }
}