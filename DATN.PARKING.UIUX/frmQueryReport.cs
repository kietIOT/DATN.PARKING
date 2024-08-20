using DATN.PARKING.SERVICE.InterfaceMethod;

namespace DATN.PARKING.UIUX
{
    public partial class frmQueryReport : Form
    {
        private readonly IServiceParking _service;
        public frmQueryReport()
        {
            InitializeComponent();
        }
        public frmQueryReport(IServiceParking service)
        {
            _service = service;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtFromDate.DateTime >= dtToDate.DateTime)
                {
                    MessageBox.Show("Khoảng thời gian không hợp lệ. Vui lòng thử lại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lookVehicleType_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmQueryReport_Load(object sender, EventArgs e)
        {
            try
            {
                lookVehicleType.Properties.DataSource = _service.GetAllVehicleType();
            }

            catch(Exception ex)
                {
                throw new Exception(ex.Message);
            }
        }
    }
}
