namespace Desktop_Controller
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
            this.ResultTable = new System.Windows.Forms.DataGridView();
            this.SearchBx = new System.Windows.Forms.TextBox();
            this.Restart = new System.Windows.Forms.Button();
            this.Shutdown = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ping = new System.Windows.Forms.Button();
            this.Uninstall = new System.Windows.Forms.CheckBox();
            this.spcommand = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.applocF = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultTable
            // 
            this.ResultTable.AllowUserToAddRows = false;
            this.ResultTable.AllowUserToDeleteRows = false;
            this.ResultTable.AllowUserToOrderColumns = true;
            this.ResultTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultTable.Location = new System.Drawing.Point(12, 52);
            this.ResultTable.Name = "ResultTable";
            this.ResultTable.ReadOnly = true;
            this.ResultTable.RowTemplate.Height = 24;
            this.ResultTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultTable.Size = new System.Drawing.Size(234, 327);
            this.ResultTable.TabIndex = 4;
            // 
            // SearchBx
            // 
            this.SearchBx.Location = new System.Drawing.Point(12, 12);
            this.SearchBx.Name = "SearchBx";
            this.SearchBx.Size = new System.Drawing.Size(487, 22);
            this.SearchBx.TabIndex = 5;
            this.SearchBx.TextChanged += new System.EventHandler(this.SearchBx_TextChanged);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(12, 708);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(75, 23);
            this.Restart.TabIndex = 7;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Shutdown
            // 
            this.Shutdown.Location = new System.Drawing.Point(112, 708);
            this.Shutdown.Name = "Shutdown";
            this.Shutdown.Size = new System.Drawing.Size(81, 23);
            this.Shutdown.TabIndex = 8;
            this.Shutdown.Text = "Shutdown";
            this.Shutdown.UseVisualStyleBackColor = true;
            this.Shutdown.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(259, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 327);
            this.dataGridView1.TabIndex = 11;
            // 
            // ping
            // 
            this.ping.Location = new System.Drawing.Point(518, 12);
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(75, 23);
            this.ping.TabIndex = 12;
            this.ping.Text = "Connect";
            this.ping.UseVisualStyleBackColor = true;
            this.ping.Click += new System.EventHandler(this.ping_Click);
            // 
            // Uninstall
            // 
            this.Uninstall.AutoSize = true;
            this.Uninstall.Location = new System.Drawing.Point(758, 653);
            this.Uninstall.Name = "Uninstall";
            this.Uninstall.Size = new System.Drawing.Size(92, 21);
            this.Uninstall.TabIndex = 2;
            this.Uninstall.Text = "Uninstall?";
            this.Uninstall.UseVisualStyleBackColor = true;
            // 
            // spcommand
            // 
            this.spcommand.AutoSize = true;
            this.spcommand.Location = new System.Drawing.Point(12, 597);
            this.spcommand.Name = "spcommand";
            this.spcommand.Size = new System.Drawing.Size(98, 21);
            this.spcommand.TabIndex = 9;
            this.spcommand.Text = "checkBox1";
            this.spcommand.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(758, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 624);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(713, 22);
            this.textBox1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // applocF
            // 
            this.applocF.Location = new System.Drawing.Point(12, 569);
            this.applocF.Name = "applocF";
            this.applocF.Size = new System.Drawing.Size(713, 22);
            this.applocF.TabIndex = 6;
            this.applocF.TextChanged += new System.EventHandler(this.applocF_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 744);
            this.Controls.Add(this.ping);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.spcommand);
            this.Controls.Add(this.Shutdown);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.applocF);
            this.Controls.Add(this.SearchBx);
            this.Controls.Add(this.ResultTable);
            this.Controls.Add(this.Uninstall);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ResultTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView ResultTable;
        private System.Windows.Forms.TextBox SearchBx;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Shutdown;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ping;
        private System.Windows.Forms.CheckBox Uninstall;
        private System.Windows.Forms.CheckBox spcommand;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox applocF;
    }
}

