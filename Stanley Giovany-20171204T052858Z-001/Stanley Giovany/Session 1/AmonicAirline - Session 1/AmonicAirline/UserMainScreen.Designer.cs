namespace AmonicAirline
{
    partial class UserMainScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblNumberCrash = new System.Windows.Forms.Label();
            this.lblTimeSpent = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(11, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(35, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            // 
            // lblNumberCrash
            // 
            this.lblNumberCrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumberCrash.Location = new System.Drawing.Point(399, 43);
            this.lblNumberCrash.Name = "lblNumberCrash";
            this.lblNumberCrash.Size = new System.Drawing.Size(195, 14);
            this.lblNumberCrash.TabIndex = 1;
            this.lblNumberCrash.Text = "label2";
            this.lblNumberCrash.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTimeSpent
            // 
            this.lblTimeSpent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTimeSpent.Location = new System.Drawing.Point(125, 43);
            this.lblTimeSpent.Name = "lblTimeSpent";
            this.lblTimeSpent.Size = new System.Drawing.Size(268, 14);
            this.lblTimeSpent.TabIndex = 1;
            this.lblTimeSpent.Text = "label2";
            this.lblTimeSpent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(580, 289);
            this.dataGridView1.TabIndex = 2;
            // 
            // UserMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTimeSpent);
            this.Controls.Add(this.lblNumberCrash);
            this.Controls.Add(this.lblWelcome);
            this.Name = "UserMainScreen";
            this.Size = new System.Drawing.Size(608, 375);
            this.Load += new System.EventHandler(this.UserMainScreen_Load);
            this.DockChanged += new System.EventHandler(this.UserMainScreen_DockChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblNumberCrash;
        private System.Windows.Forms.Label lblTimeSpent;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
