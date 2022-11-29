using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using Oracle.ManagedDataAccess.Client;

namespace Market_final_exam
{
    public partial class Chart_total_margin : MetroFramework.Forms.MetroForm
    {
        public Chart_total_margin()
        {
            InitializeComponent();
        }

        private void Chart_total_margin_Load(object sender, EventArgs e)
        {
            oracleConnection1.Open();
        }

        public static string date;

        private void Create_chart()
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
           
            oracleCommand1.CommandText = "SELECT purchase.p_date as 날짜, SUM(purchase.p_price) as 매출 FROM PURCHASE WHERE purchase.p_date = '" + date +"' GROUP BY purchase.p_date";

            OracleDataReader rdr = oracleCommand1.ExecuteReader();

            while (rdr.Read())
            {
                //series point에 데이터 입력
                chart1.Series[0].Points.AddXY(rdr["날짜"], rdr["매출"]);
            }
            rdr.Close();
            oracleConnection1.Close();

        }

        private void margin()
        {
            oracleConnection1.Open();

            string margin_cost = "";
            oracleCommand2.CommandText = "SELECT purchase.p_date as 날짜, SUM(purchase.p_price) as 매출 FROM PURCHASE WHERE purchase.p_date = '" + date + "' GROUP BY purchase.p_date";

            OracleDataReader rdr2 = oracleCommand1.ExecuteReader();

            while (rdr2.Read())
            {
                //series point에 데이터 입력
                margin_cost = rdr2["매출"].ToString();
            }

            label1.Text = margin_cost + "원";

            rdr2.Close();
            oracleConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Chart_total_margin showFrom13 = new Chart_total_margin();
            showFrom13.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_chart();
            add_data_st_ch();
            margin();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            date = comboBox1.SelectedItem.ToString();
        }
    }
}
