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
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        public static DataTable admin;
        public static DataTable customer;
        public static DataTable worker;

        
        private void login_Load(object sender, EventArgs e)
        {
            administratorTableAdapter1.Fill(people11.ADMINISTRATOR);
            admin = people11.Tables["ADMINISTRATOR"];
            
            customerTableAdapter1.Fill(rcdata1.CUSTOMER);
            customer = rcdata1.Tables["CUSTOMER"];

            workerTableAdapter1.Fill(people11.WORKER);
            worker = people11.Tables["WORKER"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.ToString();

            DataRow[] login_a;
            DataRow[] login_c;
            DataRow[] login_b;

            login_a = admin.Select("AD_ID = " + "'" + id + "'");
            login_c = customer.Select("C_ID = " + "'" + id + "'");
            login_b = worker.Select("W_ID = " + "'" + id + "'");

            if (String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("로그인 실패", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                foreach (DataRow row in login_a)
                {
                    MessageBox.Show("관리자 로그인 성공", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Managertab showForm2 = new Managertab();
                    this.Hide();
                    showForm2.ShowDialog();
                    this.Close();
                }


                foreach (DataRow row in login_c)
                {
                    string realname = "";
                    string m_id = "";
                    
                    realname = row["C_NAME"].ToString();
                    m_id = row["M_ID"].ToString();

                    Customer.name = realname;
                    Customer.m_name = m_id;

                    MessageBox.Show(Customer.name.ToString() + " 고객님 반갑습니다.", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Customer showForm3 = new Customer();
                    this.Hide();
                    showForm3.ShowDialog();
                    this.Close();
                }

                foreach (DataRow row in login_b)
                {
                    MessageBox.Show("직원 로그인 성공", "쑤야유통 로그인서비스", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Worker showForm4 = new Worker();
                    Worker.w_name = textBox1.Text.ToString();
                    this.Hide();
                    showForm4.ShowDialog();
                    this.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register showFrom5 = new Register();
            
            showFrom5.ShowDialog();
            
        }
    }
}
