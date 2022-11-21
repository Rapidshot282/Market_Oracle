
namespace Market_final_exam
{
    partial class Worker
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pSTATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDSERIALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pUQUANTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pURCHASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.managef = new Market_final_exam.Managef();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.pURCHASETableAdapter = new Market_final_exam.ManagefTableAdapters.PURCHASETableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pUQUANTDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPRICEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pSTATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDATEDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDSERIALDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pURCHASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pURCHASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managef)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pURCHASEBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(701, 340);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.dataGridView1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 36);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(693, 300);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "구매승인";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pIDDataGridViewTextBoxColumn,
            this.cIDDataGridViewTextBoxColumn,
            this.pSTATEDataGridViewTextBoxColumn,
            this.pDSERIALDataGridViewTextBoxColumn,
            this.pPRICEDataGridViewTextBoxColumn,
            this.pUQUANTDataGridViewTextBoxColumn,
            this.pDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pURCHASEBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(686, 300);
            this.dataGridView1.TabIndex = 2;
            // 
            // pIDDataGridViewTextBoxColumn
            // 
            this.pIDDataGridViewTextBoxColumn.DataPropertyName = "P_ID";
            this.pIDDataGridViewTextBoxColumn.HeaderText = "주문번호";
            this.pIDDataGridViewTextBoxColumn.Name = "pIDDataGridViewTextBoxColumn";
            this.pIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // cIDDataGridViewTextBoxColumn
            // 
            this.cIDDataGridViewTextBoxColumn.DataPropertyName = "C_ID";
            this.cIDDataGridViewTextBoxColumn.HeaderText = "고객ID";
            this.cIDDataGridViewTextBoxColumn.Name = "cIDDataGridViewTextBoxColumn";
            this.cIDDataGridViewTextBoxColumn.Width = 80;
            // 
            // pSTATEDataGridViewTextBoxColumn
            // 
            this.pSTATEDataGridViewTextBoxColumn.DataPropertyName = "P_STATE";
            this.pSTATEDataGridViewTextBoxColumn.HeaderText = "주문상태";
            this.pSTATEDataGridViewTextBoxColumn.Name = "pSTATEDataGridViewTextBoxColumn";
            this.pSTATEDataGridViewTextBoxColumn.Width = 80;
            // 
            // pDSERIALDataGridViewTextBoxColumn
            // 
            this.pDSERIALDataGridViewTextBoxColumn.DataPropertyName = "PD_SERIAL";
            this.pDSERIALDataGridViewTextBoxColumn.HeaderText = "물품코드";
            this.pDSERIALDataGridViewTextBoxColumn.Name = "pDSERIALDataGridViewTextBoxColumn";
            this.pDSERIALDataGridViewTextBoxColumn.Width = 80;
            // 
            // pPRICEDataGridViewTextBoxColumn
            // 
            this.pPRICEDataGridViewTextBoxColumn.DataPropertyName = "P_PRICE";
            this.pPRICEDataGridViewTextBoxColumn.HeaderText = "가격";
            this.pPRICEDataGridViewTextBoxColumn.Name = "pPRICEDataGridViewTextBoxColumn";
            this.pPRICEDataGridViewTextBoxColumn.Width = 80;
            // 
            // pUQUANTDataGridViewTextBoxColumn
            // 
            this.pUQUANTDataGridViewTextBoxColumn.DataPropertyName = "PU_QUANT";
            this.pUQUANTDataGridViewTextBoxColumn.HeaderText = "수량";
            this.pUQUANTDataGridViewTextBoxColumn.Name = "pUQUANTDataGridViewTextBoxColumn";
            this.pUQUANTDataGridViewTextBoxColumn.Width = 55;
            // 
            // pDATEDataGridViewTextBoxColumn
            // 
            this.pDATEDataGridViewTextBoxColumn.DataPropertyName = "P_DATE";
            this.pDATEDataGridViewTextBoxColumn.HeaderText = "주문날짜";
            this.pDATEDataGridViewTextBoxColumn.Name = "pDATEDataGridViewTextBoxColumn";
            this.pDATEDataGridViewTextBoxColumn.Width = 160;
            // 
            // pURCHASEBindingSource
            // 
            this.pURCHASEBindingSource.DataMember = "PURCHASE";
            this.pURCHASEBindingSource.DataSource = this.managef;
            // 
            // managef
            // 
            this.managef.DataSetName = "Managef";
            this.managef.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.dataGridView2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 36);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(693, 300);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "환불요청승인";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // pURCHASETableAdapter
            // 
            this.pURCHASETableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pIDDataGridViewTextBoxColumn1,
            this.cIDDataGridViewTextBoxColumn1,
            this.mIDDataGridViewTextBoxColumn,
            this.pUQUANTDataGridViewTextBoxColumn1,
            this.pPRICEDataGridViewTextBoxColumn1,
            this.pSTATEDataGridViewTextBoxColumn1,
            this.pDATEDataGridViewTextBoxColumn1,
            this.pDSERIALDataGridViewTextBoxColumn1,
            this.wIDDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.pURCHASEBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(689, 300);
            this.dataGridView2.TabIndex = 2;
            // 
            // pIDDataGridViewTextBoxColumn1
            // 
            this.pIDDataGridViewTextBoxColumn1.DataPropertyName = "P_ID";
            this.pIDDataGridViewTextBoxColumn1.HeaderText = "P_ID";
            this.pIDDataGridViewTextBoxColumn1.Name = "pIDDataGridViewTextBoxColumn1";
            // 
            // cIDDataGridViewTextBoxColumn1
            // 
            this.cIDDataGridViewTextBoxColumn1.DataPropertyName = "C_ID";
            this.cIDDataGridViewTextBoxColumn1.HeaderText = "C_ID";
            this.cIDDataGridViewTextBoxColumn1.Name = "cIDDataGridViewTextBoxColumn1";
            // 
            // mIDDataGridViewTextBoxColumn
            // 
            this.mIDDataGridViewTextBoxColumn.DataPropertyName = "M_ID";
            this.mIDDataGridViewTextBoxColumn.HeaderText = "M_ID";
            this.mIDDataGridViewTextBoxColumn.Name = "mIDDataGridViewTextBoxColumn";
            // 
            // pUQUANTDataGridViewTextBoxColumn1
            // 
            this.pUQUANTDataGridViewTextBoxColumn1.DataPropertyName = "PU_QUANT";
            this.pUQUANTDataGridViewTextBoxColumn1.HeaderText = "PU_QUANT";
            this.pUQUANTDataGridViewTextBoxColumn1.Name = "pUQUANTDataGridViewTextBoxColumn1";
            // 
            // pPRICEDataGridViewTextBoxColumn1
            // 
            this.pPRICEDataGridViewTextBoxColumn1.DataPropertyName = "P_PRICE";
            this.pPRICEDataGridViewTextBoxColumn1.HeaderText = "P_PRICE";
            this.pPRICEDataGridViewTextBoxColumn1.Name = "pPRICEDataGridViewTextBoxColumn1";
            // 
            // pSTATEDataGridViewTextBoxColumn1
            // 
            this.pSTATEDataGridViewTextBoxColumn1.DataPropertyName = "P_STATE";
            this.pSTATEDataGridViewTextBoxColumn1.HeaderText = "P_STATE";
            this.pSTATEDataGridViewTextBoxColumn1.Name = "pSTATEDataGridViewTextBoxColumn1";
            // 
            // pDATEDataGridViewTextBoxColumn1
            // 
            this.pDATEDataGridViewTextBoxColumn1.DataPropertyName = "P_DATE";
            this.pDATEDataGridViewTextBoxColumn1.HeaderText = "P_DATE";
            this.pDATEDataGridViewTextBoxColumn1.Name = "pDATEDataGridViewTextBoxColumn1";
            // 
            // pDSERIALDataGridViewTextBoxColumn1
            // 
            this.pDSERIALDataGridViewTextBoxColumn1.DataPropertyName = "PD_SERIAL";
            this.pDSERIALDataGridViewTextBoxColumn1.HeaderText = "PD_SERIAL";
            this.pDSERIALDataGridViewTextBoxColumn1.Name = "pDSERIALDataGridViewTextBoxColumn1";
            // 
            // wIDDataGridViewTextBoxColumn
            // 
            this.wIDDataGridViewTextBoxColumn.DataPropertyName = "W_ID";
            this.wIDDataGridViewTextBoxColumn.HeaderText = "W_ID";
            this.wIDDataGridViewTextBoxColumn.Name = "wIDDataGridViewTextBoxColumn";
            // 
            // pURCHASEBindingSource1
            // 
            this.pURCHASEBindingSource1.DataMember = "PURCHASE";
            this.pURCHASEBindingSource1.DataSource = this.managef;
            // 
            // Worker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(747, 426);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "Worker";
            this.Text = "Worker";
            this.Load += new System.EventHandler(this.Worker_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pURCHASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managef)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pURCHASEBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Managef managef;
        private System.Windows.Forms.BindingSource pURCHASEBindingSource;
        private ManagefTableAdapters.PURCHASETableAdapter pURCHASETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSTATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDSERIALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pUQUANTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pUQUANTDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPRICEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSTATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDATEDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDSERIALDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn wIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pURCHASEBindingSource1;
    }
}