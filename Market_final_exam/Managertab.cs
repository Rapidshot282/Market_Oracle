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
    public partial class Managertab : MetroFramework.Forms.MetroForm
    {
        public Managertab()
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
        private void Managertab_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.STOCK' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.stockTableAdapter1.Fill(this.managef.STOCK);

            this.registerTableAdapter1.Fill(this.rcdata1.REGISTER);

            this.purchaseTableAdapter1.Fill(this.managef.PURCHASE);

            marketTableAdapter1.Fill(managef1.MARKET);
            market = managef1.Tables["MARKET"];

            stockTableAdapter1.Fill(managef1.STOCK);
            stock = managef1.Tables["STOCK"];

            proD_CHANGETableAdapter1.Fill(managef1.PROD_CHANGE);
            prod_change = managef1.Tables["PROD_CHANGE"];

            administratorTableAdapter1.Fill(people11.ADMINISTRATOR);
            admin = people11.Tables["ADMINISTRATOR"];

            customerTableAdapter1.Fill(rcdata1.CUSTOMER);
            customer = rcdata1.Tables["CUSTOMER"];

            workerTableAdapter1.Fill(people11.WORKER);
            worker = people11.Tables["WORKER"];

            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];

            listBox1.Items.Clear();

            foreach (DataRow row in market.Rows)
            {
                listBox1.Items.Add(row["M_ID"].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m_id = listBox1.SelectedItem.ToString();

            DataRow[] selected;

            listBox2.Items.Clear();

            selected = managef1.STOCK.Select("M_ID = " + m_id);

            foreach (DataRow row in selected)
            {

                listBox2.Items.Add(row["PD_SERIAL"].ToString());

            }
        }

       
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serial = listBox2.SelectedItem.ToString();

            DataRow[] selected;

            selected = managef1.STOCK.Select("PD_SERIAL = " + serial);

            foreach (DataRow row in selected)
            {
                textBox1.Text = row["M_PRICE"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string serial = listBox1.SelectedItem.ToString();
            string pd_serial = listBox2.SelectedItem.ToString();
            
            DataRow newRow = prod_change.NewRow();
            newRow["PRCH_ID"] = (int)proD_CHANGETableAdapter1.PRCH();
            newRow["BF_PRICE"] = textBox1.Text;
            newRow["AF_PRICE"] = textBox2.Text;
            newRow["M_ID"] = serial;
            newRow["PD_SERIAL"] = pd_serial;

            prod_change.Rows.Add(newRow);

            proD_CHANGETableAdapter1.Update(managef1.PROD_CHANGE);

            try
            {
                this.sTOCKBindingSource.EndEdit();
                int ret = this.stockTableAdapter1.Update(this.managef.STOCK);
                if (ret > 0)
                {
                    MessageBox.Show("변동된 가격이 확정되었습니다.", "가격변동정보", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("가격 변경 실패", "가격변동정보", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                textBox1.Text = "";
                textBox2.Text = "";

            stockTableAdapter1.Fill(managef1.STOCK);
            stock = managef1.Tables["STOCK"];

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 현재 Row를 가져온다.
            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            // TextBox에 그리드 데이터를 넣는다.
            textBox2.Text = row["M_PRICE"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("가입을 승인하시겠습니까?", "쑤야유통 로그인서비스", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                DataGridViewRow dgvr = dataGridView3.CurrentRow;
                int rowIndex = dataGridView3.CurrentRow.Index;
               
                DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

                string auth = row["R_KIND"].ToString();
                string id = row["REGISTER_ID"].ToString();
                string m_id = row["M_ID"].ToString();
                string name = row["R_NAME"].ToString();

                string auth_a = "관리자";
                string auth_b = "고객";
                string auth_c = "직원";

                if (auth == auth_a)
                {
                    DataRow newRow = admin.NewRow();
                    newRow["AD_ID"] = id;
                    newRow["AD_PW"] = "null";
                    newRow["AD_NAME"] = name;

                    admin.Rows.Add(newRow);
                    administratorTableAdapter1.Update(people11.ADMINISTRATOR);

                    rEGISTERBindingSource3.RemoveCurrent();
                    registerTableAdapter1.Update(rcdata1.REGISTER);

                    MessageBox.Show("승인되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                else if (auth == auth_b)
                {
                    DataRow newRow1 = customer.NewRow();
                    newRow1["C_ID"] = id;
                    newRow1["C_NAME"] = name;
                    newRow1["C_RANK"] = "BRONZE";
                    newRow1["M_ID"] = m_id;

                    customer.Rows.Add(newRow1);
                    customerTableAdapter1.Update(rcdata1.CUSTOMER);
          
                    rEGISTERBindingSource3.RemoveCurrent();
                    registerTableAdapter1.Update(rcdata1.REGISTER);

                    MessageBox.Show("승인되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                else if (auth == auth_c)
                {
                    DataRow newRow2 = customer.NewRow();
                    newRow2["W_ID"] = id;
                    newRow2["W_NAME"] = name;
                    newRow2["M_ID"] = m_id;

                    worker.Rows.Add(newRow2);
                    workerTableAdapter1.Update(people11.WORKER);

                    rEGISTERBindingSource3.RemoveCurrent();
                    registerTableAdapter1.Update(rcdata1.REGISTER);

                    MessageBox.Show("승인되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("승인이 취소되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
