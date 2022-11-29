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
    public partial class Chart_market_Top5 : MetroFramework.Forms.MetroForm
    {
        public Chart_market_Top5()
        {
            InitializeComponent();
        }

        private void Chart_market_Top5_Load(object sender, EventArgs e)
        {
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
            series1.Name = "원";
            series2.Name = "";
            chart1.Series.Add(series1);

            chart1.Size = new System.Drawing.Size(592, 321); //chart size

            Controls.Add(chart1);

        }

        private void add_data_st_ch()
        {

            oracleCommand1.CommandText = "SELECT MARKET.M_NAME as 마트명, SUM(purchase.p_price) as 마트매출 FROM MARKET, PURCHASE WHERE MARKET.M_ID = purchase.m_id AND ROWNUM <= 7 GROUP BY market.m_name";

            OracleDataReader rdr = oracleCommand1.ExecuteReader();

            while (rdr.Read())
            {
                //series point에 데이터 입력
                chart1.Series[0].Points.AddXY(rdr["마트명"], rdr["마트매출"]);
            }
            rdr.Close();
            oracleConnection1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_chart_stock();
            add_data_st_ch();
        }
    }
}
