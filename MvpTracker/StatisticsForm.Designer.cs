namespace MvpTracker
{
    partial class StatisticsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mvpTrackerDataSet = new MvpTracker.MvpTrackerDataSet();
            this.mvpTrackerDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statisticsGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvpTrackerDataSet
            // 
            this.mvpTrackerDataSet.DataSetName = "MvpTrackerDataSet";
            this.mvpTrackerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mvpTrackerDataSetBindingSource
            // 
            this.mvpTrackerDataSetBindingSource.DataSource = this.mvpTrackerDataSet;
            this.mvpTrackerDataSetBindingSource.Position = 0;
            // 
            // statisticsGridView
            // 
            this.statisticsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.statisticsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.statisticsGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.statisticsGridView.Location = new System.Drawing.Point(30, 45);
            this.statisticsGridView.Name = "statisticsGridView";
            this.statisticsGridView.RowHeadersWidth = 80;
            this.statisticsGridView.Size = new System.Drawing.Size(282, 396);
            this.statisticsGridView.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Most Killed MVPs";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 482);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statisticsGridView);
            this.Name = "StatisticsForm";
            this.Text = "MVP Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MvpTrackerDataSet mvpTrackerDataSet;
        private System.Windows.Forms.BindingSource mvpTrackerDataSetBindingSource;
        private System.Windows.Forms.DataGridView statisticsGridView;
        private System.Windows.Forms.Label label2;
    }
}