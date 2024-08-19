using DATN.PARKING.DLL;
using DATN.PARKING.SERVICE.ImplementMethod;

namespace DATN.PARKING.UIUX
{
    public partial class frmQueryInfo : Form
    {
        private readonly ServiceParking _service;
        public frmQueryInfo(ServiceParking service)
        {
            _service = service;
        }
        public frmQueryInfo()
        {
            InitializeComponent();
        }


        private void frmQueryInfo_Load(object sender, EventArgs e)
        {
            try
            {
                var lstVehicleType = _service.GetAllVehicleType();
                lookVehicleType.Properties.DataSource = lstVehicleType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtGateIn.DateTime >= dtGateOut.DateTime)
                {
                    MessageBox.Show("Khoảng thời gian không hợp lệ. Vui lòng nhập lại !", "Cảnh Báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                gridData.DataSource = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
