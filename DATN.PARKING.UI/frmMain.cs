using System;
using System.Windows.Forms;

namespace DATN.PARKING.UI
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
            if(btnAuto.Checked)
            {
                if(MessageBox.Show("Bạn có muốn bật chế độ tự động ?","Warming",MessageBoxButtons.YesNo) == BooleanType.Yes)

                cbBike.Checked = cbCar.Checked = cbMotoBike.Checked = cbBike.Enabled = cbCar.Enabled = cbMotoBike.Enabled = false;
            }
        }
    }
}
