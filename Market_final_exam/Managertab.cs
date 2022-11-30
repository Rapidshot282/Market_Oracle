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

        public static string serial;
        public static string pd_serial;
        public static string ch_price;
        public static string st_id_m;
        public static string m_id;

        public static string m_id_st;
        public static string serial_st;
        public static string st_id_st;
        public static string ch_stock;

        public static string m_id_new;
        public static string pd_id_new;
        public static string serial_new;
        public static string st_id_new;
        public static string new_stock;

        public static string pd_serial_ch;
        private void Managertab_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.STOCK' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.stockTableAdapter1.Fill(this.managef.STOCK);
            this.productTableAdapter1.Fill(this.managef.PRODUCT);

            this.registerTableAdapter1.Fill(this.rcdata1.REGISTER);

            this.purchaseTableAdapter1.Fill(this.managef.PURCHASE);
            this.proD_CHANGETableAdapter1.Fill(this.managef.PROD_CHANGE);

            marketTableAdapter1.Fill(managef1.MARKET);
            market = managef1.Tables["MARKET"];

            stockTableAdapter1.Fill(managef1.STOCK);
            stock = managef1.Tables["STOCK"];

            proD_CHANGETableAdapter1.Fill(managef1.PROD_CHANGE);
            prod_change = managef1.Tables["PROD_CHANGE"];

            productTableAdapter1.Fill(managef1.PRODUCT);
            product = managef1.Tables["PRODUCT"];

            pD_DETAILTableAdapter1.Fill(managef1.PD_DETAIL);
            pd_detail = managef1.Tables["PD_DETAIL"];

            administratorTableAdapter1.Fill(people11.ADMINISTRATOR);
            admin = people11.Tables["ADMINISTRATOR"];

            customerTableAdapter1.Fill(rcdata1.CUSTOMER);
            customer = rcdata1.Tables["CUSTOMER"];

            workerTableAdapter1.Fill(people11.WORKER);
            worker = people11.Tables["WORKER"];

            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];

            refundTableAdapter1.Fill(managef.REFUND);
            refund = managef.Tables["REFUND"];

            listBox1.Items.Clear();

            foreach (DataRow row in market.Rows)
            {
                listBox1.Items.Add(row["M_ID"].ToString());
            }

            listBox4.Items.Clear();
            foreach (DataRow row_1 in market.Rows)
            {
                listBox4.Items.Add(row_1["M_ID"].ToString());
            }

            listBox6.Items.Clear();
            foreach (DataRow row_2 in market.Rows)
            {
                listBox6.Items.Add(row_2["M_ID"].ToString());
            }

            listBox5.Items.Clear();
            foreach (DataRow row_2 in product.Rows)
            {
                listBox5.Items.Add(row_2["PD_ID"].ToString());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_id = listBox1.SelectedItem.ToString();

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
            serial = listBox2.SelectedItem.ToString();

            DataRow[] selected;

            selected = managef1.STOCK.Select("M_ID = " + m_id + " AND PD_SERIAL = " + serial);

            foreach (DataRow row in selected)
            {
                textBox1.Text = row["M_PRICE"].ToString();
                st_id_m = row["ST_ID"].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("가격 변동사항을 저장하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ch_price = textBox2.Text.ToString();

                DataRow newRow = prod_change.NewRow();
                newRow["PRCH_ID"] = (int)proD_CHANGETableAdapter1.PRCH();
                newRow["BF_PRICE"] = textBox1.Text;
                newRow["AF_PRICE"] = ch_price;
                newRow["M_ID"] = m_id;
                newRow["PD_SERIAL"] = serial;

                prod_change.Rows.Add(newRow);

                proD_CHANGETableAdapter1.Update(managef1.PROD_CHANGE);

                DataRow[] selected;

                selected = managef1.STOCK.Select("ST_ID = " + st_id_m);

                foreach (DataRow row in selected)
                {
                    row["M_PRICE"] = textBox2.Text.ToString();
                }

                stockTableAdapter1.Update(managef1.STOCK);
                stockTableAdapter1.Fill(managef1.STOCK);
                stockTableAdapter1.Fill(managef.STOCK);

                textBox1.Clear();
                textBox2.Clear();

                MessageBox.Show("변동사항이 저장되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("변동사항 저장이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        

        private void button3_Click(object sender, EventArgs e)
        {
            Chart_stock showFrom8 = new Chart_stock();

            showFrom8.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Chart_total_margin showFrom13 = new Chart_total_margin();

            showFrom13.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Chart_price_Top5 showFrom10 = new Chart_price_Top5();

            showFrom10.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Chart_customer_Top5 showFrom11 = new Chart_customer_Top5();

            showFrom11.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Chart_market_Top5 showFrom12 = new Chart_market_Top5();

            showFrom12.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Chart_total_refund showFrom14 = new Chart_total_refund();

            showFrom14.ShowDialog();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            m_id_st = listBox4.SelectedItem.ToString();

            DataRow[] selected;

            listBox3.Items.Clear();

            selected = managef1.STOCK.Select("M_ID = " + m_id_st);

            foreach (DataRow row in selected)
            {
                listBox3.Items.Add(row["PD_SERIAL"].ToString());
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            serial_st = listBox3.SelectedItem.ToString();

            DataRow[] selected;

            selected = managef1.STOCK.Select("M_ID = " + m_id_st + " AND PD_SERIAL = " + serial_st);

            foreach (DataRow row in selected)
            {
                textBox4.Text = row["ST_REMAIN"].ToString();
                st_id_st = row["ST_ID"].ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("상품 입고사항을 저장하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string pu_quant = "";
                string bf_quant_st = "";
                string af_quant_st = "";
                int bf_quant = 0;
                int af_quant = 0;
                int quant_result_int = 0;
                string quant_result = "";

                DataRow[] selected;

                selected = managef1.STOCK.Select("ST_ID = " + st_id_st);

                foreach (DataRow row in selected)
                {
                    bf_quant_st = row["ST_REMAIN"].ToString();
                }

                af_quant_st = textBox3.Text.ToString();

                bf_quant = int.Parse(bf_quant_st);
                af_quant = int.Parse(af_quant_st);

                quant_result_int = bf_quant + af_quant;

                quant_result = quant_result_int.ToString();

                DataRow[] selected2;

                selected2 = managef1.STOCK.Select("ST_ID = " + st_id_st);

                foreach (DataRow row in selected2)
                {
                    row["ST_REMAIN"] = quant_result;
                }

                stockTableAdapter1.Update(managef1.STOCK);
                stockTableAdapter1.Fill(managef1.STOCK);
                stockTableAdapter1.Fill(managef.STOCK);

                textBox3.Clear();
                textBox4.Clear();

                MessageBox.Show("변동사항이 저장되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("변동사항 저장이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_id_new = listBox6.SelectedItem.ToString();

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            pd_id_new = listBox5.SelectedItem.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("신규상품 입고사항을 저장하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int pd_serial_new;
                pd_serial_new = (int)pD_DETAILTableAdapter1.pd_detail_serial();

                DataRow newRow = pd_detail.NewRow();
                newRow["PD_SERIAL"] = pd_serial_new;
                newRow["PD_ID"] = pd_id_new;
                newRow["PD_NAME"] = textBox7.Text;

                pd_detail.Rows.Add(newRow);

                pD_DETAILTableAdapter1.Update(managef1.PD_DETAIL);

                DataRow newRow_1 = stock.NewRow();
                newRow_1["ST_ID"] = (int)stockTableAdapter1.new_stock_id();
                newRow_1["ST_REMAIN"] = textBox5.Text;
                newRow_1["M_PRICE"] = textBox6.Text;
                newRow_1["M_ID"] = m_id_new;
                newRow_1["PD_SERIAL"] = pd_serial_new;

                stock.Rows.Add(newRow_1);

                stockTableAdapter1.Update(managef1.STOCK);
                stockTableAdapter1.Fill(managef1.STOCK);
                stockTableAdapter1.Fill(managef.STOCK);

                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();

                MessageBox.Show("신규상품이 입고되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("신규상품 입고가 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Chart_refund_top5 showFrom15 = new Chart_refund_top5();

            showFrom15.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃 하시겠습니까?", "쑤야유통 로그인서비스", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("로그아웃 되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Login showForm_1 = new Login();
                this.Hide();
                showForm_1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("로그아웃이 취소되었습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
