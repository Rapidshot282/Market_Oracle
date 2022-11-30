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
        public static DataTable cart;

        public static string pd_name;
        public static string pd_num;
        public static string stock_price;
        public static string mar_id;
        public static string c_num;
        public static string market_in;
        public static string pd_num_11;
        public static string st_id_1;

        public static string pu_quant_1;
        public static int pu_quant_1_int;

        public static int stock_price_int;

        public static string stock_price_result;
        public static int stock_price_result_int;

        public static string bf_refund_price;
        public static int bf_refund_price_int;

        public static string af_refund_price;
        public static int af_refund_price_int;

        public static string eq_reply;

        public static string name;
        public static string m_name;

        
        public static string pr_af_price;
        public static string pr_bf_price;
        public static string pr_pd_serial;
        public static string pr_id_public;

        public static string my_mart;
        
        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef1.REFUND' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.refundTableAdapter1.Fill(this.managef1.REFUND);
            // TODO: 이 코드는 데이터를 'dataSet1.CART' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.cARTTableAdapter.Fill(this.dataSet1.CART);
            // TODO: 이 코드는 데이터를 'managef.PD_DETAIL' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pD_DETAILTableAdapter1.Fill(this.managef.PD_DETAIL);
            // TODO: 이 코드는 데이터를 'managef.PRODUCT' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pRODUCTTableAdapter.Fill(this.managef.PRODUCT);
            this.purchaseTableAdapter4.Fill(this.managef.PURCHASE);

            pRODUCTTableAdapter.Fill(managef.PRODUCT);
            product = managef.Tables["PRODUCT"];

            cARTTableAdapter.Fill(dataSet1.CART);
            cart = dataSet1.Tables["CART"];

            refundTableAdapter1.Fill(managef1.REFUND);
            refund = managef1.Tables["REFUND"];

            purchaseTableAdapter4.Fill(managef.PURCHASE);
            purchase = managef.Tables["PURCHASE"];

            marketTableAdapter1.Fill(managef.MARKET);
            market = managef.Tables["MARKET"];

            stockTableAdapter1.Fill(managef.STOCK);
            stock = managef.Tables["STOCK"];

            customerTableAdapter1.Fill(rcdata1.CUSTOMER);
            customer = rcdata1.Tables["CUSTOMER"];

            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];

            pD_DETAILTableAdapter1.Fill(managef.PD_DETAIL);
            pd_detail = managef.Tables["PD_DETAIL"];

            replyTableAdapter1.Fill(managef.REPLY);
            reply = managef.Tables["REPLY"];

            proD_CHANGETableAdapter1.Fill(managef1.PROD_CHANGE);
            prod_change = managef1.Tables["PROD_CHANGE"];

            label2.Text = name.ToString();

            DataRow[] selected;

            selected = rcdata1.CUSTOMER.Select("C_NAME = " + "'" + name + "'");

            foreach (DataRow row1 in selected)
            {
                c_num = row1["C_ID"].ToString();
                market_in = row1["M_ID"].ToString();
            }

            label6.Text = market_in;

            pURCHASEBindingSource5.Filter = "C_ID = " + "'" + c_num + "'";
            cARTBindingSource.Filter = "C_ID = " + "'" + c_num + "'";
            rEFUNDBindingSource.Filter = "C_ID = " + "'" + c_num + "'";

            DataRow[] c_number;

            c_number = managef.REPLY.Select("C_ID = " + "'" + c_num + "'");

            foreach (DataRow row in c_number)
            {
                listBox1.Items.Add(row["REP_ID"].ToString());
            }

            pDDETAILBindingSource.Filter = "PD_ID = " + "'" + pd_num_11 + "'";

            DataRow[] select_prch;
            select_prch = managef1.PROD_CHANGE.Select("M_ID = " + market_in);

            foreach (DataRow row_3 in select_prch)
            {
                listBox2.Items.Add(row_3["PRCH_ID"].ToString());
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pd_name = "";
            pd_num = "";
            stock_price = "";
            mar_id = "";
            string st_remain = "";
            
            DataGridViewRow dgvr = dataGridView4.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            // TextBox에 그리드 데이터를 넣는다.
            pd_name = row["PD_NAME"].ToString();
            pd_num = row["PD_SERIAL"].ToString();

            textBox1.Text = pd_name;
            textBox3.Text = pd_num;
            textBox6.Text = market_in;

            Reply.pd_serial = pd_num;

            DataRow[] selected;

            selected = managef.STOCK.Select("M_ID = " + market_in + " AND PD_SERIAL = " + pd_num);

            
            foreach (DataRow row1 in selected)
            {
                stock_price = row1["M_PRICE"].ToString();
                st_id_1 = row1["ST_ID"].ToString();
                st_remain = row1["ST_REMAIN"].ToString();
            }

            textBox4.Text = stock_price + "원";
            textBox7.Text = st_remain;
            stock_price_int = int.Parse(stock_price);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("장바구니에 추가하겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pu_quant_1 = textBox2.Text;
                pu_quant_1_int = int.Parse(pu_quant_1);

                stock_price_result_int = stock_price_int * pu_quant_1_int;
                stock_price_result = stock_price_result_int.ToString();

                DataRow newRow = cart.NewRow();
                newRow["CART_ID"] = (int)cARTTableAdapter.CARTNO();
                newRow["C_ID"] = c_num;
                newRow["M_ID"] = market_in;
                newRow["PU_QUANT"] = pu_quant_1;
                newRow["P_PRICE"] = stock_price_result;                
                newRow["P_DATE"] = (DateTime.Now.ToString("yyyy/MM/dd")).ToString();
                newRow["PD_SERIAL"] = pd_num;
                newRow["ST_ID"] = st_id_1;

                cart.Rows.Add(newRow);

                cARTTableAdapter.Update(dataSet1.CART);

                cARTTableAdapter.Fill(dataSet1.CART);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();

                MessageBox.Show("장바구니에 추가했습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("장바구니에 추가되지 않았습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("장바구니에서 삭제하겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cARTBindingSource.RemoveCurrent();
                cARTTableAdapter.Update(dataSet1.CART);
                cARTTableAdapter.Fill(dataSet1.CART);

                MessageBox.Show("장바구니에서 삭제했습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("장바구니에서 삭제되지 않았습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 상품을 구매요청 하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string pu_quant_2 = "";
                string p_price_2 = "";
                string pd_serial_2 = "";
                string st_id_2 = "";
                string ma_in = "";

                DataGridViewRow dgvr = dataGridView3.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

                pu_quant_2 = row["PU_QUANT"].ToString();
                p_price_2 = row["P_PRICE"].ToString();
                pd_serial_2 = row["PD_SERIAL"].ToString();
                st_id_2 = row["ST_ID"].ToString();
                ma_in = row["M_ID"].ToString(); 

                DataRow newRow = purchase.NewRow();
                newRow["P_ID"] = (int)purchaseTableAdapter4.PURCHNO();
                newRow["C_ID"] = c_num;
                newRow["M_ID"] = ma_in;
                newRow["PU_QUANT"] = pu_quant_2;
                newRow["P_PRICE"] = p_price_2;
                newRow["P_DATE"] = (DateTime.Now.ToString("yyyy/MM/dd")).ToString();
                newRow["P_STATE"] = "구매신청";
                newRow["PD_SERIAL"] = pd_serial_2;
                newRow["ST_ID"] = st_id_2;

                purchase.Rows.Add(newRow);

                purchaseTableAdapter4.Update(managef.PURCHASE);
                purchaseTableAdapter4.Fill(managef.PURCHASE);

                int selectedIndex = this.dataGridView3.CurrentCell.RowIndex;

                if (selectedIndex > -1)
                {
                    this.dataGridView3.Rows.RemoveAt(selectedIndex);

                    this.dataGridView3.Refresh();
                }
                cARTTableAdapter.Update(dataSet1.CART);
                cARTTableAdapter.Fill(dataSet1.CART);


                MessageBox.Show("구매요청이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("구매요청이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow[] reply_1;

            string reply_detail = "";

            reply_detail = listBox1.SelectedItem.ToString();

            reply_1 = reply.Select("REP_ID = " + "'" + reply_detail + "'");

            foreach (DataRow row in reply_1)
            {
                //선택된 메모 내용 출력
                label5.Text = row["RED_KEYW"].ToString();
                richTextBox1.Text = row["REP_DETAIL"].ToString();
                label4.Text = row["REP_DATE"].ToString();
                label7.Text = row["PD_SERIAL"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reply showFrom6 = new Reply();

            showFrom6.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pd_name_1;

            pd_name_1 = comboBox2.SelectedItem.ToString();

            DataRow[] pd_name_dr;

            pd_name_dr = managef.PRODUCT.Select("PD_NAME = " + "'" + pd_name_1 + "'");

            foreach (DataRow row5 in pd_name_dr)
            {
                pd_num_11 = row5["PD_ID"].ToString();
            }

            pDDETAILBindingSource1.Filter = "PD_ID = " + "'" + pd_num_11 + "'";
            pD_DETAILTableAdapter1.Fill(managef.PD_DETAIL);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 상품을 환불요청 하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string eq = "";
                string eq_error = "구매승인";

                string p_id_1 = "";
                string st_id_2 = "";
                string pu_quant_2 = ""; // textBox5 데이터 바인딩
                int pu_quant_2_int = 0;
                string pd_serial_3 = "";
                string pu_quant_3 = ""; // 변화된 환불갯수
                int pu_quant_3_int = 0;

                int pu_quant_result = 0;
                int pu_price_result = 0;

                int ch_stock_price_int = 0;

                DataGridViewRow dgvr_1 = dataGridView1.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_1 = (dgvr_1.DataBoundItem as DataRowView).Row;
                eq = row_1["P_STATE"].ToString();

                if (eq_error.Equals(eq))
                {

                    DataGridViewRow dgvr = dataGridView1.CurrentRow;

                    // 선택한 Row의 데이터를 가져온다.
                    DataRow row = (dgvr.DataBoundItem as DataRowView).Row;
                    int rowIndex = dataGridView1.CurrentRow.Index;

                    p_id_1 = row["P_ID"].ToString();
                    pu_quant_2 = row["PU_QUANT"].ToString();
                    pd_serial_3 = row["PD_SERIAL"].ToString();
                    st_id_2 = row["ST_ID"].ToString();
                    bf_refund_price = row["P_PRICE"].ToString();

                    pu_quant_2_int = int.Parse(pu_quant_2);

                    pu_quant_3 = textBox5.Text.ToString();

                    pu_quant_3_int = int.Parse(pu_quant_3);

                    DataRow[] selected;

                    selected = managef.STOCK.Select("ST_ID = " + st_id_2);

                    foreach (DataRow row1 in selected)
                    {
                        stock_price = row1["M_PRICE"].ToString();
                    }

                    ch_stock_price_int = int.Parse(stock_price);

                    bf_refund_price_int = int.Parse(bf_refund_price); //이전가격

                    pu_quant_result = pu_quant_2_int - pu_quant_3_int;
                    pu_price_result = pu_quant_3_int * ch_stock_price_int;

                    af_refund_price_int = bf_refund_price_int - pu_price_result;

                    af_refund_price = af_refund_price_int.ToString();

                    row["PU_QUANT"] = pu_quant_result.ToString();
                    row["P_PRICE"] = af_refund_price;

                    purchaseTableAdapter4.Update(managef.PURCHASE);
                    purchaseTableAdapter4.Fill(managef.PURCHASE);

                    if (pu_quant_2_int < pu_quant_3_int)
                    {
                        MessageBox.Show("구매수량보다 요청수량이 더 많습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {

                        purchaseTableAdapter4.Update(managef.PURCHASE);
                        purchaseTableAdapter4.Fill(managef.PURCHASE);

                        DataRow newRow = refund.NewRow();

                        newRow["REF_ID"] = (int)refundTableAdapter1.REFUNDNO();
                        newRow["C_ID"] = c_num;
                        newRow["P_ID"] = p_id_1;
                        newRow["REF_PRICE"] = pu_price_result.ToString();
                        newRow["REF_DATE"] = (DateTime.Now.ToString("yyyy/MM/dd")).ToString();
                        newRow["REF_STATE"] = "환불요청";
                        newRow["PU_QUANT"] = pu_quant_3_int.ToString();
                        newRow["PD_DETAIL"] = pd_serial_3;
                        newRow["ST_ID"] = st_id_2;

                        refund.Rows.Add(newRow);

                        if (pu_quant_result < 1 || pu_quant_result == 0)
                        {

                            int selectedIndex = this.dataGridView1.CurrentCell.RowIndex;

                            if (selectedIndex > -1)
                            {
                                this.dataGridView1.Rows.RemoveAt(selectedIndex);

                                this.dataGridView1.Refresh();
                            }

                            purchaseTableAdapter4.Update(managef.PURCHASE);
                            purchaseTableAdapter4.Fill(managef.PURCHASE);

                            refundTableAdapter1.Update(managef1.REFUND);
                            refundTableAdapter1.Fill(managef1.REFUND);

                            textBox5.Clear();

                            MessageBox.Show("환불요청이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            purchaseTableAdapter4.Update(managef.PURCHASE);
                            purchaseTableAdapter4.Fill(managef.PURCHASE);

                            refundTableAdapter1.Update(managef1.REFUND);
                            refundTableAdapter1.Fill(managef1.REFUND);

                            textBox5.Clear();

                            MessageBox.Show("환불요청이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("환불요청은 구매승인이 먼저 되어야 합니다.\n구매승인까지 기다려주세요.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("환불요청이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.purchaseTableAdapter4.Fill(this.managef.PURCHASE);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            

            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row = (dgvr.DataBoundItem as DataRowView).Row;

            // TextBox에 그리드 데이터를 넣는다.
            CreateReview.rep_p_id = row["P_ID"].ToString();
            eq_reply = row["P_STATE"].ToString();

                DataRow[] selected;

                selected = managef.PURCHASE.Select("P_ID = " + CreateReview.rep_p_id);

                foreach (DataRow row1 in selected)
                {
                    CreateReview.rep_c_id = row1["C_ID"].ToString();
                    CreateReview.rep_pd_serial = row1["PD_SERIAL"].ToString();
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string eq_error = "구매승인";
            if(eq_error.Equals(eq_reply))
            {
                CreateReview showFrom7 = new CreateReview();

                showFrom7.ShowDialog();
            }
            else
            {
                MessageBox.Show("리뷰작성은 구매승인 이후 작성가능합니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pr_id_public = listBox2.SelectedItem.ToString();
            string pr_name = "";

            DataRow[] select_prch_private;
            
            select_prch_private = managef1.PROD_CHANGE.Select("PRCH_ID = " + pr_id_public);

            foreach (DataRow pr_row in select_prch_private)
            {
         
                    pr_af_price = pr_row["AF_PRICE"].ToString();
                    pr_bf_price = pr_row["BF_PRICE"].ToString();
                    pr_pd_serial = pr_row["PD_SERIAL"].ToString();

            }

            DataRow[] select_pr_name;

            select_pr_name = managef.PD_DETAIL.Select("PD_SERIAL = " + pr_pd_serial);

            foreach(DataRow prd_row in select_pr_name)
            {
                pr_name = prd_row["PD_NAME"].ToString();
            }

            label8.Text = pr_name.ToString();
            label9.Text = pr_bf_price.ToString() + "원" + " ----> " + pr_af_price.ToString() + "원";
            label10.Text = pr_pd_serial.ToString();
        }
        
    }
}
