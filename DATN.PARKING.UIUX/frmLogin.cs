using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.InterfaceMethod;

namespace DATN.PARKING.UIUX
{
    public partial class frmLogin : Form
    {
        private IServiceParking _service;
        private readonly IHardwareService _hardwareService;
        public frmLogin(IServiceParking service, IHardwareService hardwareService)
        {
            InitializeComponent();
            _service = service;
            _hardwareService = hardwareService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text.IsEmpty() ||  txtPassword.Text.IsEmpty())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản/ mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (!_service.Login(txtUsername.Text, txtPassword.Text))

                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.Hide();
                var frm = new frmMain(_hardwareService, _service);
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
