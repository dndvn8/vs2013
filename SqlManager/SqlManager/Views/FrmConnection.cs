using System;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using SqlManager.Object;
using SqlManager.Properties;
using SqlManager.Utilities;

namespace SqlManager.Views
{
    public partial class FrmConnection : Form
    {
        public SqlConnection Conn;
        public ConnectInfo ConnectInfo;
        public FrmConnection()
        {
            InitializeComponent();
            cbbAuthencation.SelectedIndex = 1;
            this.FormClosing += FrmConnection_FormClosing;
        }

        void FrmConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        public int ConnectType
        {
            get
            {
                return cbbAuthencation.SelectedIndex; 
            }
        }

        private SqlConnection GetConnect(int type)
        {
            if (type == 0)
                return new SqlConnection("Data Source=" + txtServerName.Text + ";Integrated Security=True");
            return
                new SqlConnection("Data Source=" + txtServerName.Text + ";Persist Security Info=True;User ID=" +
                                  txtUsername.Text + ";Password=" + txtPassword.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Conn = GetConnect(cbbAuthencation.SelectedIndex);
                Conn.Open();
                MessageBox.Show(@"Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectInfo = new ConnectInfo(txtServerName.Text, txtUsername.Text, txtPassword.Text, cbbAuthencation.SelectedIndex);
            
            if (chkRememberPassword.Checked)
            {
                Settings.Default.Username = txtUsername.Text;
                Settings.Default.Password = txtPassword.Text;
                Settings.Default.SavePassword = true;
            }
            else
            {
                Settings.Default.Username = txtUsername.Text;
                Settings.Default.Password = "";
                Settings.Default.SavePassword = false;
            }
            Settings.Default.ServerName = txtServerName.Text;
            Settings.Default.KetNoi = GetConnect(cbbAuthencation.SelectedIndex).ConnectionString;
            Settings.Default.Save();
            Utility.SaveConfig(txtServerName.Text, Settings.Default.KetNoi);
            //btnExit_Click(null, null);
        }

        private void cbbAuthencation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthencation.SelectedIndex == 0)
            {
                chkRememberPassword.Enabled = txtUsername.Enabled = txtPassword.Enabled = false;
            }
            else
            {
                chkRememberPassword.Enabled = txtUsername.Enabled = txtPassword.Enabled = true;
            }
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            txtServerName.Text = Settings.Default.ServerName;
            chkRememberPassword.Checked = Settings.Default.SavePassword;
            if (Settings.Default.SavePassword)
            {
                txtUsername.Text = Settings.Default.Username;
                txtPassword.Text = Settings.Default.Password;
            }
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            Network net = new Network();
            net.ShowDialog();
        }
    }
}
