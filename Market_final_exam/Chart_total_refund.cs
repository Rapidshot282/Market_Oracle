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
    public partial class Chart_total_refund : MetroFramework.Forms.MetroForm
    {
        public Chart_total_refund()
        {
            InitializeComponent();
        }

        private void Chart_total_refund_Load(object sender, EventArgs e)
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

            oracleCommand1.CommandText = "SELECT REFUND.REF_DATE as 날짜, SUM(REFUND.REF_price) as 환불액 FROM REFUND WHERE REFUND.REF_date = '" + date +"' AND REF_STATE = '환불승인' GROUP BY REFUND.REF_date";

            OracleDataReader rdr = oracleCommand1.ExecuteReader();

            while (rdr.Read())
            {
                //series point에 데이터 입력
                chart1.Series[0].Points.AddXY(rdr["날짜"], rdr["환불액"]);
            }
            rdr.Close();
            oracleConnection1.Close();

        }

        private void total_refund()
        {
            oracleConnection1.Open();

            string refund_cost = "";
            oracleCommand2.CommandText = "SELECT REFUND.REF_DATE as 날짜, SUM(REFUND.REF_price) as 환불액 FROM REFUND WHERE REFUND.REF_date = '" + date + "' AND REF_STATE = '환불승인 GROUP BY REFUND.REF_date";

            OracleDataReader rdr2 = oracleCommand1.ExecuteReader();

            while (rdr2.Read())
            {
                //series point에 데이터 입력
                refund_cost = rdr2["환불액"].ToString();
            }

            label1.Text = refund_cost + "원";

            rdr2.Close();
            oracleConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Create_chart();
            add_data_st_ch();
            total_refund();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Chart_total_margin showFrom13 = new Chart_total_margin();
            showFrom13.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            date = comboBox1.SelectedItem.ToString();
        }
    }
}
