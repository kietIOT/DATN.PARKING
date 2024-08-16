using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.ImplementMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DATN.PARKING.UIUX
{
    public partial class frmLogin : Form
    {
        private readonly ServiceParking _service;
        public frmLogin(ServiceParking service)
        {
            _service = service;
        }
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!_service.Login(txtUsername.Text,txtPassword.Text))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var frm = new frmMain();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
