using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpTracker
{
    public partial class StatisticsForm : Form
    {
        public Database db { get; set; } = new Database();
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            DataSet dataSet = db.GetMvpKillingStatistics();
 
            statisticsGridView.ReadOnly = true;
            statisticsGridView.DataSource = dataSet.Tables[0];
            statisticsGridView.BorderStyle = BorderStyle.Fixed3D;
            statisticsGridView.GridColor = Color.Black;
            statisticsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }
    }
}
