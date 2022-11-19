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
    public partial class Customer : MetroFramework.Forms.MetroForm
    {
        public Customer()
        {
            InitializeComponent();
        }

        public static DataTable market;
        public static DataTable product;
        public static DataTable pd_detail;
        public static DataTable prod_change;
        public static DataTable purchase;
        public static DataTable stock;
        public static DataTable refund;
        public static DataTable reply;
        public static DataTable register;
        public static DataTable admin;
        public static DataTable customer;
        public static DataTable worker;

        public static string pd_name;
        public static string pd_num;
        public static string stock_price;
        public static string c_num;
        public static string market_in;

        public static string name;
        public static string m_name;
        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.PD_DETAIL' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pD_DETAILTableAdapter1.Fill(this.managef.PD_DETAIL);
            // TODO: 이 코드는 데이터를 'managef.PRODUCT' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pRODUCTTableAdapter.Fill(this.managef.PRODUCT);
            this.purchaseTableAdapter1.Fill(this.managef.PURCHASE);

            purchaseTableAdapter1.Fill(managef1.PURCHASE);
            purchase = managef1.Tables["PURCHASE"];

            marketTableAdapter1.Fill(managef1.MARKET);
            market = managef1.Tables["MARKET"];

            stockTableAdapter1.Fill(managef1.STOCK);
            stock = managef1.Tables["STOCK"];

            customerTableAdapter1.Fill(rcdata1.CUSTOMER);
            customer = rcdata1.Tables["CUSTOMER"];

            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];

            pD_DETAILTableAdapter1.Fill(managef1.PD_DETAIL);
            pd_detail = managef1.Tables["PD_DETAIL"];

            replyTableAdapter1.Fill(managef1.REPLY);
            reply = managef1.Tables["REPLY"];

            label2.Text = name.ToString();

            DataRow[] selected;

            selected = rcdata1.CUSTOMER.Select("C_NAME = " + "'" + name + "'");

            foreach (DataRow row1 in selected)
            {
                c_num = row1["C_ID"].ToString();
                market_in = row1["M_ID"].ToString();
            }

            pURCHASEBindingSource2.Filter = "C_ID = " + "'" + c_num + "'";

            DataRow[] c_number;

            c_number = managef1.REPLY.Select("C_ID = " + "'" + c_num + "'");

            foreach (DataRow row in c_number)
            {
                listBox1.Items.Add(row["PD_SERIAL"].ToString());
            }

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pd_name = "";
            pd_num = "";
            stock_price = "";
            
            DataGridViewRow dgvr = dataGridView4.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            // TextBox에 그리드 데이터를 넣는다.
            pd_name = row["PD_NAME"].ToString();
            pd_num = row["PD_SERIAL"].ToString();

            textBox1.Text = pd_name;
            textBox3.Text = pd_num;

            DataRow[] selected;

            selected = managef1.STOCK.Select("PD_SERIAL = " + pd_num);

            foreach (DataRow row1 in selected)
            {
                stock_price = row1["M_PRICE"].ToString();
            }

            textBox4.Text = stock_price;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataRow newRow = purchase.NewRow();
            newRow["P_ID"] = (int)purchaseTableAdapter1.PURCHNO();
            newRow["C_ID"] = c_num;
            newRow["M_ID"] = market_in;
            newRow["PU_QUANT"] = textBox2.Text;
            newRow["P_PRICE"] = stock_price;
            newRow["P_STATE"] = "장바구니";
            newRow["P_DATE"] = (DateTime.Today).ToString();
            newRow["PD_SERIAL"] = pd_num;

            purchase.Rows.Add(newRow);

            purchaseTableAdapter1.Update(managef1.PURCHASE);

            purchaseTableAdapter1.Fill(managef.PURCHASE);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("장바구니에서 삭제하겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pURCHASEBindingSource2.RemoveCurrent();
                purchaseTableAdapter1.Update(managef.PURCHASE);
                purchaseTableAdapter1.Fill(managef.PURCHASE);

                MessageBox.Show("장바구니에서 삭제했습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("장바구니에서 삭제되지 않았습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow[] reply_1;

            string reply_detail = "";

            reply_detail = listBox1.SelectedItem.ToString();

            reply_1 = reply.Select("PD_SERIAL = " + "'" + reply_detail + "'");

            foreach (DataRow row in reply_1)
            {
                //선택된 메모 내용 출력
                label5.Text = row["PD_SERIAL"].ToString();
                label3.Text = row["REP_DETAIL"].ToString();
                label4.Text = row["REP_DATE"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
