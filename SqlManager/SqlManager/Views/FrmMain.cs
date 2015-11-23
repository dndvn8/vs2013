using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SqlManager.Properties;
using SqlManager.Utilities;

namespace SqlManager.Views
{
    public partial class FrmMain : Form
    {
        public SqlConnection Connection;
        public string ConnectString = string.Empty;
        //private string _server;
        public DataTable Database;
        private int _connectType;

        public FrmMain()
        {
            InitializeComponent();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuery.Text)) return;
            try
            {
                string sql = txtQuery.Text;
                SqlDataAdapter da = new SqlDataAdapter(sql, Connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dtgResult.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text.Equals("Connect"))
            {
                btnConnect.Text = @"Disconnect";
                btnRun.Enabled = txtQuery.Enabled = true;
                if (Settings.Default.KetNoi == "") return;
                Connection = new SqlConnection(Settings.Default.KetNoi);
                Connection.Open();
                SqlDataAdapter sda =
                    new SqlDataAdapter(
                        "SELECT name FROM master..sysdatabases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');",
                        Connection);
                DataTable data = new DataTable();
                sda.Fill(data);
                trvDatabase.Nodes.Add("Database");
                int i = 0;

                foreach (DataRow row in data.Rows)
                {
                    trvDatabase.Nodes[0].Nodes.Add(row[0].ToString());
                    string sql = string.Format(
                        "Use {0} \r\n SELECT * FROM information_schema.tables",
                        row[0]);
                    SqlDataAdapter da =
                        new SqlDataAdapter(sql, Connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row1 in dt.Rows)
                    {
                        if (row1[0].ToString().Equals(row[0].ToString()))
                            trvDatabase.Nodes[0].Nodes[i].Nodes.Add(row1[2].ToString());
                    }
                    i++;
                }
                //trvDatabase.ExpandAll();
            }
            else
            {
                btnConnect.Text = @"Connect";
                btnRun.Enabled = txtQuery.Enabled = false;
                trvDatabase.Nodes.Clear();
            }
        }

        private void trvDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*
            if (trvDatabase.SelectedNode.Level == 1)
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
                ConnectString = Utility.BuildConnectString(_connectType, Settings.Default.ServerName, trvDatabase.SelectedNode.Text,
                    Settings.Default.Username, Settings.Default.Password);
                Connection = new SqlConnection(ConnectString);
                try
                {
                    Connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/
            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FrmConnection conn = new FrmConnection();
            conn.ShowDialog();
            trvDatabase.Nodes.Add(conn.ConnectInfo.ServerName);
        }

        private void trvDatabase_Click(object sender, EventArgs e)
        {

        }

        private void trvDatabase_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(trvDatabase.SelectedNode.Text);
            if (trvDatabase.SelectedNode.Level == 0)
            {
                
            }
        }
    }
}
