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

        public static string w_name;
        private void Worker_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'managef.PURCHASE' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.pURCHASETableAdapter.Fill(this.managef.PURCHASE);

            
            pURCHASEBindingSource1.Filter = "P_STATE = " + "'" + "환불요청" + "'";

        }
    }
}
