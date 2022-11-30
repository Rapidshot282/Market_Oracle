
namespace Market_final_exam
{
    partial class Chart_stock
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
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            this.oracleConnection1 = new Oracle.ManagedDataAccess.Client.OracleConnection();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sTOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.managef = new Market_final_exam.Managef();
            this.sTOCKTableAdapter = new Market_final_exam.ManagefTableAdapters.STOCKTableAdapter();
            this.pDDETAILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pD_DETAILTableAdapter = new Market_final_exam.ManagefTableAdapters.PD_DETAILTableAdapter();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDDETAILBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(23, 74);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(72, 19);
            this.metroLabel17.TabIndex = 12;
            this.metroLabel17.Text = "상품번호 :";
            // 
            // oracleCommand1
            // 
            this.oracleCommand1.Connection = this.oracleConnection1;
            this.oracleCommand1.Transaction = null;
            // 
            // oracleConnection1
            // 
            this.oracleConnection1.ChunkMigrationConnectionTimeout = "120";
            this.oracleConnection1.ConnectionString = "TNS_ADMIN=C:\\app\\minsu\\dbhomeXE\\network\\admin;USER ID=MINSU;PASSWORD=2435;DATA SO" +
    "URCE=MINSDB;PERSIST SECURITY INFO=True";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 16;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 17;
            this.button2.Text = "새로고침";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sTOCKBindingSource
            // 
            this.sTOCKBindingSource.DataMember = "STOCK";
            this.sTOCKBindingSource.DataSource = this.managef;
            // 
            // managef
            // 
            this.managef.DataSetName = "Managef";
            this.managef.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sTOCKTableAdapter
            // 
            this.sTOCKTableAdapter.ClearBeforeFill = true;
            // 
            // pDDETAILBindingSource
            // 
            this.pDDETAILBindingSource.DataMember = "PD_DETAIL";
            this.pDDETAILBindingSource.DataSource = this.managef;
            // 
            // pD_DETAILTableAdapter
            // 
            this.pD_DETAILTableAdapter.ClearBeforeFill = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(101, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(121, 40);
            this.listBox1.TabIndex = 18;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Chart_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(639, 444);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.metroLabel17);
            this.Name = "Chart_stock";
            this.Text = "재고현황";
            this.Load += new System.EventHandler(this.Chart_stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sTOCKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDDETAILBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private Oracle.ManagedDataAccess.Client.OracleConnection oracleConnection1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Managef managef;
        private System.Windows.Forms.BindingSource sTOCKBindingSource;
        private ManagefTableAdapters.STOCKTableAdapter sTOCKTableAdapter;
        private System.Windows.Forms.BindingSource pDDETAILBindingSource;
        private ManagefTableAdapters.PD_DETAILTableAdapter pD_DETAILTableAdapter;
        private System.Windows.Forms.ListBox listBox1;
    }
}