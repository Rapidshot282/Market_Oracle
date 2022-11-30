using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Market_final_exam
{
    public partial class Chart_stock : MetroFramework.Forms.MetroForm
    {
        public Chart_stock()
        {
            InitializeComponent();
        }

        public static string pd_serial_ch;

        public static DataTable pd_detail;

        private void Chart_stock_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.PD_DETAIL' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pD_DETAILTableAdapter.Fill(this.managef.PD_DETAIL);
            pd_detail = managef.Tables["PD_DETAIL"];
            // TODO: 이 코드는 데이터를 'managef.STOCK' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.sTOCKTableAdapter.Fill(this.managef.STOCK);

            listBox1.Items.Clear();
            foreach (DataRow row in pd_detail.Rows)
            {
                listBox1.Items.Add(row["PD_SERIAL"].ToString());
            }

            oracleConnection1.Open();
        }

        private void Create_chart_stock()
        {
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();

            //2개의 시리즈 사용
            Series series1 = new Series();
            Series series2 = new Series();

            chart1 = new Chart();
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new System.Drawing.Point(24, 100); //chart location
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "재고량";
            series2.Name = "";
            chart1.Series.Add(series1);

            chart1.Size = new System.Drawing.Size(592, 321); //chart size

            Controls.Add(chart1);

        }

        private void add_data_st_ch()
        {
            
            oracleCommand1.CommandText = "SELECT MARKET.M_ID as 마트번호, stock.st_remain as 재고량 FROM MARKET LEFT OUTER JOIN STOCK on MARKET.M_ID = STOCK.M_ID WHERE STOCK.PD_SERIAL = " + "'" + pd_serial_ch + "'";

            OracleDataReader rdr = oracleCommand1.ExecuteReader();

            while (rdr.Read())
            {
                //series point에 데이터 입력
                chart1.Series[0].Points.AddXY(rdr["마트번호"], rdr["재고량"]);
            }
            rdr.Close();
            oracleConnection1.Close();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string a = "재고량";
            Create_chart_stock();
            add_data_st_ch();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Chart_stock showFrom9 = new Chart_stock();
            showFrom9.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pd_serial_ch = listBox1.SelectedItem.ToString();
        }
    }
}
