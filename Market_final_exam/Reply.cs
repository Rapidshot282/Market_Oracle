using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_final_exam
{
    public partial class Reply : MetroFramework.Forms.MetroForm
    {
        public Reply()
        {
            InitializeComponent();
        }

        public static string pd_serial;

        public static string rep_pd_serial;
        public static string rep_c_id;       

        public static DataTable reply;

        private void reply_Load(object sender, EventArgs e)
        {
            replyTableAdapter1.Fill(managef1.REPLY);
            reply = managef1.Tables["REPLY"];

            DataRow[] c_number;

            c_number = managef1.REPLY.Select("PD_SERIAL = " + "'" + pd_serial + "'");

            foreach (DataRow row in c_number)
            {
                listBox1.Items.Add(row["C_ID"].ToString());
            }

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] reply_1;

            string reply_detail = "";

            reply_detail = listBox1.SelectedItem.ToString();

            reply_1 = reply.Select("C_ID = " + "'" + reply_detail + "'");

            foreach (DataRow row in reply_1)
            {
                //선택된 메모 내용 출력
                label5.Text = row["PD_SERIAL"].ToString();
                label3.Text = row["REP_DETAIL"].ToString();
                label4.Text = row["REP_DATE"].ToString();
            }
        }
    }
}
