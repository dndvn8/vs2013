using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlManager.Views
{
    public partial class Network : Form
    {
        public Network()
        {
            InitializeComponent();
            this.Load += Network_Load;
        }

        void Network_Load(object sender, EventArgs e)
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            dataGridView1.DataSource = dt;
        }
    }
}
