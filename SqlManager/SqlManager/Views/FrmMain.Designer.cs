namespace SqlManager.Views
{
    partial class FrmMain
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
            this.trvDatabase = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.dtgResult = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddConnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvDatabase
            // 
            this.trvDatabase.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvDatabase.Location = new System.Drawing.Point(0, 0);
            this.trvDatabase.Name = "trvDatabase";
            this.trvDatabase.Size = new System.Drawing.Size(175, 365);
            this.trvDatabase.TabIndex = 0;
            this.trvDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDatabase_AfterSelect);
            this.trvDatabase.Click += new System.EventHandler(this.trvDatabase_Click);
            this.trvDatabase.DoubleClick += new System.EventHandler(this.trvDatabase_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtQuery);
            this.panel2.Controls.Add(this.dtgResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(175, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 333);
            this.panel2.TabIndex = 5;
            // 
            // txtQuery
            // 
            this.txtQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQuery.Enabled = false;
            this.txtQuery.Location = new System.Drawing.Point(0, 0);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(437, 164);
            this.txtQuery.TabIndex = 3;
            // 
            // dtgResult
            // 
            this.dtgResult.BackgroundColor = System.Drawing.Color.White;
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgResult.Location = new System.Drawing.Point(0, 164);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.Size = new System.Drawing.Size(437, 169);
            this.dtgResult.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddConnect);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(175, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 32);
            this.panel1.TabIndex = 4;
            // 
            // btnAddConnect
            // 
            this.btnAddConnect.Location = new System.Drawing.Point(6, 3);
            this.btnAddConnect.Name = "btnAddConnect";
            this.btnAddConnect.Size = new System.Drawing.Size(100, 26);
            this.btnAddConnect.TabIndex = 3;
            this.btnAddConnect.Text = "New Connection";
            this.btnAddConnect.UseVisualStyleBackColor = true;
            this.btnAddConnect.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(112, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 26);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(202, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(62, 26);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Execute";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 365);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trvDatabase);
            this.Name = "FrmMain";
            this.Text = "SQL Manager";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvDatabase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.DataGridView dtgResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnAddConnect;


    }
}