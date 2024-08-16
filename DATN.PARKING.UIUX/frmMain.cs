using System;
using System.Windows.Forms;

namespace DATN.PARKING.UIUX
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

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
            var frm = new frmLogin();
            frm.ShowDialog();
        }
    }
}
