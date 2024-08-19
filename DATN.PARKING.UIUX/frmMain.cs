using System;
using System.Windows.Forms;
using DATN.PARKING.SERVICE.ImplementMethod;
using DATN.PARKING.SERVICE.InterfaceMethod;
using OpenCvSharp;
namespace DATN.PARKING.UIUX
{
    public partial class frmMain : Form
    {
        private readonly IPlateRecognitonService _serviceRecgPlate;

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(IPlateRecognitonService serviceRecgPlate)
        {
            _serviceRecgPlate = serviceRecgPlate;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            var capture = new VideoCapture(0); // 0 is the default camera
            Mat frame = new Mat();
            capture.Read(frame);
            try
            {
                // Recognize the plate
                string plateText = _serviceRecgPlate.RecognizePlate(frame);
                Console.WriteLine($"Detected Plate Text: {plateText}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Release the camera
            capture.Release();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("dd-mm-yyyy HH:mm:ss");
        }

        private void btnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAuto.Checked)
            {
                if (MessageBox.Show("Bạn có muốn bật/tắt chế độ tự động ?", "Warning",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                { cbBike.Checked = cbCar.Checked = cbMotoBike.Checked = false; }
                else { btnAuto.Checked = false; }
            }
        }

        private void cbCar_CheckedChanged(object sender, EventArgs e)
        {
            btnAuto.Checked = cbBike.Checked = cbMotoBike.Checked = false;
        }

        private void cbMotoBike_CheckedChanged(object sender, EventArgs e)
        {
            btnAuto.Checked = cbCar.Checked = cbBike.Checked = false;
        }

        private void cbBike_CheckedChanged(object sender, EventArgs e)
        {
            btnAuto.Checked = cbCar.Checked = cbMotoBike.Checked = false;
        }

        private void cmtQueryInfo_Click(object sender, EventArgs e)
        {
            var frm = new frmQueryInfo();
            frm.ShowDialog();
        }

        private void cmtReport_Click(object sender, EventArgs e)
        {
            var frm = new frmQueryReport();
            frm.ShowDialog();
        }

        private void cmtLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new frmLogin(null);
            frm.ShowDialog();
        }
    }
}
