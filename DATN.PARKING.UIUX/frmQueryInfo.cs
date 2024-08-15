using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DATN.PARKING.UIUX
{
    public partial class frmQueryInfo : Form
    {
        public frmQueryInfo()
        {
            InitializeComponent();
        }

        private void lookVehicleType_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void frmQueryInfo_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> lstVehicleType = new Dictionary<int, string>();
            lstVehicleType.Add(0, "Ô tô");
            lstVehicleType.Add(1, "Xe máy");
            lstVehicleType.Add(2, "Xe đạp");

            lookVehicleType.Properties.DataSource = lstVehicleType; 
        }
    }
}
