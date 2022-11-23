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
    public partial class CreateReview : MetroFramework.Forms.MetroForm
    {
        public CreateReview()
        {
            InitializeComponent();
        }

        public static string rep_pd_serial;
        public static string rep_c_id;
        public static string rep_p_id;

        public static DataTable reply;

        private void CreateReview_Load(object sender, EventArgs e)
        {
            label3.Text = rep_c_id;
            label5.Text = rep_pd_serial;

            replyTableAdapter1.Fill(managef1.REPLY);
            reply = managef1.Tables["REPLY"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string eq = "";

            if (MessageBox.Show("리뷰를 등록하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow[] selected;

                selected = managef1.REPLY.Select("P_ID = " + rep_p_id);

                foreach (DataRow row1 in selected)
                {
                    eq = row1["REP_ID"].ToString();
                }

                if(string.IsNullOrEmpty(eq))
                {
                    string title = "";
                    string detail = "";

                    title = textBox1.Text.ToString();
                    detail = richTextBox1.Text.ToString();

                    DataRow newRow = reply.NewRow();
                    newRow["REP_ID"] = (int)replyTableAdapter1.REPLYNO();
                    newRow["C_ID"] = rep_c_id;
                    newRow["PD_SERIAL"] = rep_pd_serial;
                    newRow["REP_DETAIL"] = detail;
                    newRow["REP_DATE"] = (DateTime.Now.ToString("yyyy/MM/dd")).ToString();
                    newRow["RED_KEYW"] = title;
                    newRow["P_ID"] = rep_p_id;

                    reply.Rows.Add(newRow);

                    replyTableAdapter1.Update(managef1.REPLY);
                    replyTableAdapter1.Fill(managef1.REPLY);

                    textBox1.Clear();
                    richTextBox1.Clear();

                    MessageBox.Show("리뷰등록이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("현재의 거래내역에 리뷰가 이미 있습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            else
            {
                MessageBox.Show("리뷰등록이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
