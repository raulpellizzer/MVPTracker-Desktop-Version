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
            this.mvpTrackerDataSet = new MvpTracker.MvpTrackerDataSet();
            this.mvpTrackerDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statisticsGridView = new System.Windows.Forms.DataGridView();
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
            this.statisticsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statisticsGridView.Location = new System.Drawing.Point(39, 68);
            this.statisticsGridView.Name = "statisticsGridView";
            this.statisticsGridView.Size = new System.Drawing.Size(273, 256);
            this.statisticsGridView.TabIndex = 0;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statisticsGridView);
            this.Name = "StatisticsForm";
            this.Text = "MVP Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvpTrackerDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MvpTrackerDataSet mvpTrackerDataSet;
        private System.Windows.Forms.BindingSource mvpTrackerDataSetBindingSource;
        private System.Windows.Forms.DataGridView statisticsGridView;
    }
}