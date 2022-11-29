
namespace Market_final_exam
{
    partial class Chart_total_margin
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
            this.button1 = new System.Windows.Forms.Button();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.oracleConnection1 = new Oracle.ManagedDataAccess.Client.OracleConnection();
            this.oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.oracleCommand2 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 24;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(23, 74);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(44, 19);
            this.metroLabel17.TabIndex = 23;
            this.metroLabel17.Text = "날짜 :";
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.ChunkMigrationConnectionTimeout = "120";
            this.oracleConnection1.ConnectionString = "TNS_ADMIN=C:\\app\\minsu\\dbhomeXE\\network\\admin;USER ID=MINSU;PASSWORD=2435;DATA SO" +
    "URCE=MINSDB;PERSIST SECURITY INFO=True";
            // 
            // oracleCommand1
            // 
            this.oracleCommand1.Connection = this.oracleConnection1;
            this.oracleCommand1.Transaction = null;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2022-11-01",
            "2022-11-02",
            "2022-11-03",
            "2022-11-04",
            "2022-11-05",
            "2022-11-06",
            "2022-11-07",
            "2022-11-08",
            "2022-11-09",
            "2022-11-10",
            "2022-11-11",
            "2022-11-12",
            "2022-11-13",
            "2022-11-14",
            "2022-11-15",
            "2022-11-16",
            "2022-11-17",
            "2022-11-18",
            "2022-11-19",
            "2022-11-20",
            "2022-11-21",
            "2022-11-22",
            "2022-11-23",
            "2022-11-24",
            "2022-11-25",
            "2022-11-26"});
            this.comboBox1.Location = new System.Drawing.Point(73, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(131, 20);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 26;
            this.button2.Text = "새로고침";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // oracleCommand2
            // 
            this.oracleCommand2.Connection = this.oracleConnection1;
            this.oracleCommand2.Transaction = null;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(397, 75);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 19);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "총 매출 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "label1";
            // 
            // Chart_total_margin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel17);
            this.Name = "Chart_total_margin";
            this.Text = "Chart_total_margin";
            this.Load += new System.EventHandler(this.Chart_total_margin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private Oracle.ManagedDataAccess.Client.OracleConnection oracleConnection1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Label label1;
    }
}