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
    public partial class Register : MetroFramework.Forms.MetroForm
    {
        public Register()
        {
            InitializeComponent();
        }

        public static DataTable admin_r;
        public static DataTable customer_r;
        public static DataTable worker_r;
        public static DataTable register;
        public static DataTable market;

        private void Register_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.MARKET' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.mARKETTableAdapter.Fill(this.managef.MARKET);
            market = managef.Tables["MARKET"];

            administratorTableAdapter1.Fill(people11.ADMINISTRATOR);
            admin_r = people11.Tables["ADMINISTRATOR"];

            customerTableAdapter2.Fill(rcdata1.CUSTOMER);
            customer_r = rcdata1.Tables["CUSTOMER"];

            workerTableAdapter1.Fill(people11.WORKER);
            worker_r = people11.Tables["WORKER"];

            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];

            MessageBox.Show("안녕하세요. 쑤야유통입니다. \n우선, 저희 로그인서비스를 이용해주셔서 감사합니다.\n"
                + "\n" +"몇 가지 안내사항을 안내해드리오니 꼭 읽으시고 \n회원가입을 진행해주시면 감사하겠습니다. \n"
                + "\n" + "1. 고객회원은 관리자 번호를 제외한 아이디, 이름을 \n입력해주시면 가입가능합니다.\n"
                + "\n" + "2. 아이디 입력시 중복확인 버튼을 클릭해주세요. \n만약 오류팝업이 나오지 않는다면 중복이 아닙니다.\n"
                + "\n" +"3. 관리자회원은 관리자 키를 필수로 지참하셔야 하며, \n미소지시 회원가입이 불가합니다.\n"
                + "\n" +"4. 저희 매장은 오프라인 실명 회원제 매장입니다. 가입시 즉시가입이 아닌 승인절차 후 가입이 진행됩니다.\n"
                + "\n" +"5. 매장선택은 자신이 자주 이용하는 매장이나 자신이 일하는 곳을 선택하시면 됩니다.", 
                "안내사항", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m_name = comboBox2.SelectedItem.ToString();
            string state = comboBox1.SelectedItem.ToString();
            string m_num = "";
            string manager_num = textBox2.Text.ToString();
            string manager_auth = "2435";
            string manager_auth2 = "관리자";

            DataRow[] m_id; 
            m_id = market.Select("M_NAME = " + "'" + m_name + "'");

            foreach (DataRow row in m_id)
            {
                m_num = row["M_ID"].ToString();
            }

            DataRow newRow = register.NewRow();
            newRow["REGISTER_ID"] = textBox1.Text;
            newRow["M_ID"] = m_num;
            newRow["R_KIND"] = state;
            newRow["R_STATE"] = "승인요청";
            newRow["R_NAME"] = textBox3.Text;

            if (state == manager_auth2 && manager_num != manager_auth)
            {
                MessageBox.Show("관리자 번호를 입력해주세요.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                register.Rows.Add(newRow);

                registerTableAdapter1.Update(rcdata1.REGISTER);
                MessageBox.Show("회원신청이 완료되었습니다.\n승인을 기다려주세요.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.Close();
            }

            textBox1.Text = "";
            textBox2.Text = "";
            registerTableAdapter1.Fill(rcdata1.REGISTER);
            register = rcdata1.Tables["REGISTER"];
            

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string r_id = textBox1.Text.ToString();
   
            DataRow[] login_c;
            DataRow[] login_a;
            DataRow[] login_b;
            DataRow[] register_r;

            login_a = admin_r.Select("AD_ID = " + "'" + r_id + "'");
            login_c = customer_r.Select("C_ID = " + "'" + r_id + "'");
            login_b = worker_r.Select("W_ID = " + "'" + r_id + "'");
            register_r = register.Select("REGISTER_ID = " + "'" + r_id + "'");

            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("입력된 아이디가 없습니다. 아이디를 입력해주세요", "아이디 중복확인",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                foreach (DataRow row in login_c)
                {
                    MessageBox.Show("아이디가 중복됩니다. 다른 아이디로 입력하세요.", "아이디 중복확인",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (DataRow row in login_b)
                {
                    MessageBox.Show("아이디가 중복됩니다. 다른 아이디로 입력하세요.", "아이디 중복확인",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                foreach (DataRow row in login_a)
                {
                    MessageBox.Show("아이디가 중복됩니다. 다른 아이디로 입력하세요.", "아이디 중복확인",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                foreach (DataRow row in register_r)
                {
                    MessageBox.Show("아이디가 중복됩니다. 다른 아이디로 입력하세요.", "아이디 중복확인",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}
