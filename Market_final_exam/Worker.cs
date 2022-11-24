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
    public partial class Worker : MetroFramework.Forms.MetroForm
    {
        public Worker()
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

        public static string st_id_3;

        public static string w_name;

        public static string p_id_1;
        public static string st_id_5;
        private void Worker_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef2.REFUND' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.rEFUNDTableAdapter.Fill(this.managef2.REFUND);
            // TODO: 이 코드는 데이터를 'managef3.REFUND' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.rEFUNDTableAdapter.Fill(this.managef3.REFUND);
            // TODO: 이 코드는 데이터를 'managef3.STOCK' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.sTOCKTableAdapter.Fill(this.managef3.STOCK);


            // TODO: 이 코드는 데이터를 'managef1.PURCHASE' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pURCHASETableAdapter.Fill(this.managef1.PURCHASE);
            // TODO: 이 코드는 데이터를 'managef1.REFUND' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.rEFUNDTableAdapter.Fill(this.managef1.REFUND);

            this.sTOCKTableAdapter.Fill(this.managef1.STOCK);

            pURCHASETableAdapter.Fill(managef1.PURCHASE);
            purchase = managef1.Tables["PURCHASE"];

            rEFUNDTableAdapter.Fill(managef1.REFUND);
            refund = managef1.Tables["REFUND"];

            sTOCKTableAdapter.Fill(managef1.STOCK);
            stock = managef1.Tables["STOCK"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("현재 거래에 대해 구매승인을 하시겠습니까?", "쑤야유통 관리서비스", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                st_id_3 = "";
                string pu_quant = "";
                string af_quant_st = "";
                int af_quant = 0;
                int bf_quant = 0;
                int quant_result_int = 0;
                string quant_result = "";

                DataGridViewRow dgvr = dataGridView2.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_1 = (dgvr.DataBoundItem as DataRowView).Row;
                st_id_3 = row_1["ST_ID"].ToString();
                af_quant_st = row_1["PU_QUANT"].ToString();

                DataRow[] selected;

                selected = managef1.STOCK.Select("ST_ID = " + "'" + st_id_3 + "'");

                foreach (DataRow row1 in selected)
                {
                    pu_quant = row1["ST_REMAIN"].ToString();
                }

                bf_quant = int.Parse(pu_quant);
                af_quant = int.Parse(af_quant_st);

                quant_result_int = bf_quant - af_quant;

                if (bf_quant < af_quant)
                {
                    MessageBox.Show("구매수량보다 재고가 없습니다. 구매거절요망", "쑤야유통 관리서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataGridViewRow dgvr_1 = dataGridView4.CurrentRow;

                    // 선택한 Row의 데이터를 가져온다.
                    DataRow row_6 = (dgvr_1.DataBoundItem as DataRowView).Row;


                    row_6["ST_REMAIN"] = quant_result_int.ToString();

                    pURCHASETableAdapter.Update(managef1.PURCHASE);
                    pURCHASETableAdapter.Fill(managef1.PURCHASE);

                    sTOCKTableAdapter.Update(managef1.STOCK);
                    sTOCKTableAdapter.Fill(managef1.STOCK);

                    pURCHASETableAdapter.Fill(managef1.PURCHASE);

                    MessageBox.Show("구매승인이 정상적으로 처리되었습니다.", "쑤야유통 관리서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("구매승인이 취소되었습니다.", "쑤야유통 관리서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("현재 거래에 대해 구매거절 하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string eq = "";
                string eq_error = "구매신청";
                DataGridViewRow dgvr = dataGridView2.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_1 = (dgvr.DataBoundItem as DataRowView).Row;
                eq = row_1["P_STATE"].ToString();
                int rowIndex_1 = dataGridView2.CurrentRow.Index;

                if (eq_error.Equals(eq))
                {
                    
                    

                    pURCHASETableAdapter.Update(managef1.PURCHASE);
                    pURCHASETableAdapter.Fill(managef1.PURCHASE);

                    MessageBox.Show("구매거절이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("구매승인이 아닌 거래내역은 구매거절을 할 수 없습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            else
            {
                MessageBox.Show("구매거절이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("현재 거래에 대해 환불승인 하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                string pu_quant = "";
                string af_quant_st = "";
                int af_quant = 0;
                int bf_quant = 0;
                string bf_quant_st = "";
                int quant_result_int = 0;

                DataGridViewRow dgvr = dataGridView3.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_1 = (dgvr.DataBoundItem as DataRowView).Row;
                

                DataRow[] selected;

                selected = managef1.REFUND.Select("P_ID = " + "'" + p_id_1 + "'");

                foreach (DataRow row1 in selected)
                {
                    af_quant_st = row1["PU_QUANT"].ToString();
                    
                }

                af_quant = int.Parse(af_quant_st);

                    DataRow[] selected_3;

                    selected_3 = managef3.STOCK.Select("ST_ID = " + "'" + st_id_5 + "'");

                    foreach (DataRow row3 in selected_3)
                    {
                        bf_quant_st = row3["ST_REMAIN"].ToString();
                    }

                    bf_quant = int.Parse(bf_quant_st);

                    quant_result_int = af_quant + bf_quant;

                    int rowIndex_1 = dataGridView4.CurrentRow.Index;

                    stock.Rows[rowIndex_1]["ST_REMAIN"] = quant_result_int.ToString();

                    

                    pURCHASETableAdapter.Update(managef1.PURCHASE);
                    pURCHASETableAdapter.Fill(managef1.PURCHASE);

                    sTOCKTableAdapter.Update(managef1.STOCK);
                    sTOCKTableAdapter.Fill(managef1.STOCK);

                    rEFUNDTableAdapter.Update(managef3.REFUND);
                    rEFUNDTableAdapter.Fill(managef3.REFUND);

                    MessageBox.Show("환불승인이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
            }         
            
            else
            {
                MessageBox.Show("환불승인이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("현재 거래에 대해 환불거절 하시겠습니까?", "쑤야유통", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                               
                string pu_quant = "";
                string af_quant_st = "";
                int af_quant = 0;
                int bf_quant = 0;
                int quant_result_int = 0;

                string pu_price = "";
                string af_ref_price = "";
                int af_price = 0;
                int bf_price = 0;
                int price_result_int = 0;

                DataGridViewRow dgvr = dataGridView3.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_1 = (dgvr.DataBoundItem as DataRowView).Row;

                DataRow[] selected;

                selected = managef3.REFUND.Select("P_ID = " + "'" + p_id_1 + "'");

                foreach (DataRow row1 in selected)
                {
                    af_quant_st = row1["PU_QUANT"].ToString();
                }

                DataRow[] selected_2;

                selected_2 = managef3.REFUND.Select("P_ID = " + "'" + p_id_1 + "'");

                foreach (DataRow row2 in selected_2)
                {
                    af_ref_price = row2["REF_PRICE"].ToString();
                }

                DataGridViewRow dgvr_1 = dataGridView2.CurrentRow;

                // 선택한 Row의 데이터를 가져온다.
                DataRow row_2 = (dgvr_1.DataBoundItem as DataRowView).Row;
                pu_quant = row_2["PU_QUANT"].ToString();
                pu_price = row_2["P_PRICE"].ToString();

                bf_quant = int.Parse(pu_quant);
                af_quant = int.Parse(af_quant_st);
                bf_price = int.Parse(pu_price);
                af_price = int.Parse(af_ref_price);

                price_result_int = bf_price + af_price;
                quant_result_int = bf_quant + af_quant;

                row_2["PU_QUANT"] = quant_result_int.ToString();

                row_2["P_PRICE"] = price_result_int.ToString();

                rEFUNDTableAdapter.Update(managef3.REFUND);
                rEFUNDTableAdapter.Fill(managef3.REFUND);

                pURCHASETableAdapter.Update(managef1.PURCHASE);
                pURCHASETableAdapter.Fill(managef1.PURCHASE);

                MessageBox.Show("환불거절이 정상적으로 처리되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("환불거절이 취소되었습니다.", "쑤야유통", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            DataGridViewRow dgvr_1 = dataGridView2.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row_2 = (dgvr_1.DataBoundItem as DataRowView).Row;

            row_2["W_ID"] = w_name;
            

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvr_1 = dataGridView3.CurrentRow;

            // 선택한 Row의 데이터를 가져온다.
            DataRow row_2 = (dgvr_1.DataBoundItem as DataRowView).Row;

            row_2["W_ID"] = w_name;
            p_id_1 = row_2["P_ID"].ToString();
            st_id_5 = row_2["ST_ID"].ToString();
            
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
