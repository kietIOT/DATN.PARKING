using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.InterfaceMethod;

namespace DATN.PARKING.UIUX
{
    public partial class frmLogin : Form
    {
        private IServiceParking _service;
      
        public frmLogin(IServiceParking service)
        {
            InitializeComponent();
            _service = service;
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!_service.Login(txtUsername.Text, txtPassword.Text))

                //{
                //    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                this.Hide();
                var frm = new frmMain();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
