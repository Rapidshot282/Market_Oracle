
namespace Market_final_exam
{
    partial class Chart_price_Top5
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 20;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(23, 74);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(211, 19);
            this.metroLabel17.TabIndex = 18;
            this.metroLabel17.Text = "현재까지의 상품 매출순위 TOP 5";
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
            // Chart_price_Top5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(639, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel17);
            this.Name = "Chart_price_Top5";
            this.Text = "Chart_price";
            this.Load += new System.EventHandler(this.Chart_price_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private Oracle.ManagedDataAccess.Client.OracleConnection oracleConnection1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}