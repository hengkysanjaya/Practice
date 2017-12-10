namespace WindowsFormsApplication10
{
    partial class Form1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CabinTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new WindowsFormsApplication10.DataSet1();
            this.DestinationAirportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AnswerCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AgeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GenderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet2 = new WindowsFormsApplication10.DataSet2();
            this.ReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CabinTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationAirportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CabinTypeBindingSource
            // 
            this.CabinTypeBindingSource.DataMember = "CabinType";
            this.CabinTypeBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DestinationAirportBindingSource
            // 
            this.DestinationAirportBindingSource.DataMember = "DestinationAirport";
            this.DestinationAirportBindingSource.DataSource = this.DataSet1;
            // 
            // AnswerCategoryBindingSource
            // 
            this.AnswerCategoryBindingSource.DataMember = "AnswerCategory";
            this.AnswerCategoryBindingSource.DataSource = this.DataSet1;
            // 
            // AgeBindingSource
            // 
            this.AgeBindingSource.DataMember = "Age";
            this.AgeBindingSource.DataSource = this.DataSet1;
            // 
            // GenderBindingSource
            // 
            this.GenderBindingSource.DataMember = "Gender";
            this.GenderBindingSource.DataSource = this.DataSet1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication10.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 13);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(693, 395);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet2
            // 
            this.DataSet2.DataSetName = "DataSet2";
            this.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportBindingSource
            // 
            this.ReportBindingSource.DataMember = "Report";
            this.ReportBindingSource.DataSource = this.DataSet2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 420);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CabinTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DestinationAirportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AgeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CabinTypeBindingSource;
        private DataSet1 DataSet1;
        private System.Windows.Forms.BindingSource DestinationAirportBindingSource;
        private System.Windows.Forms.BindingSource AnswerCategoryBindingSource;
        private System.Windows.Forms.BindingSource AgeBindingSource;
        private System.Windows.Forms.BindingSource GenderBindingSource;
        private System.Windows.Forms.BindingSource ReportBindingSource;
        private DataSet2 DataSet2;
    }
}

