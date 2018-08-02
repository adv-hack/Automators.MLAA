namespace Automator.UI
{
    partial class Analyse
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
            this.grdTestCases = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
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
            // grdTestCases
            // 
            this.grdTestCases.Location = new System.Drawing.Point(45, 89);
            this.grdTestCases.MainView = this.gridView2;
            this.grdTestCases.Name = "grdTestCases";
            this.grdTestCases.Size = new System.Drawing.Size(787, 384);
            this.grdTestCases.TabIndex = 15;
            this.grdTestCases.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdTestCases;
            this.gridView1.Name = "gridView1";
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdTestCases;
            this.gridView2.Name = "gridView2";
            // 
            // Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 524);
            this.Controls.Add(this.grdTestCases);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTestCaseID);
            this.Controls.Add(this.lblTestCase);
            this.Controls.Add(this.cmbModules);
            this.Controls.Add(this.lblModuleList);
            this.Name = "Analyse";
            this.Text = "Analyse";
            ((System.ComponentModel.ISupportInitialize)(this.grdTestCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdTestCases;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    }
}