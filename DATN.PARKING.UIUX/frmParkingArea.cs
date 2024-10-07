using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.SERVICE.InterfaceMethod;

namespace DATN.PARKING.UIUX
{
    public partial class frmParkingArea : Form
    {
        private IServiceParking _service;
        public frmParkingArea(IServiceParking service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmParkingArea_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var slots = _service.GetAllParkingSlot().ToList();

                AssignSlotToTextBox(txtA1, slots[0]);
                AssignSlotToTextBox(txtA2, slots[1]);
                AssignSlotToTextBox(txtA3, slots[2]);
                AssignSlotToTextBox(txtA4, slots[3]);

                AssignSlotToTextBox(txtB1, slots[4]);
                AssignSlotToTextBox(txtB2, slots[5]);
                AssignSlotToTextBox(txtB3, slots[6]);
                AssignSlotToTextBox(txtB4, slots[7]);

                AssignSlotToTextBox(txtC1, slots[8]);
                AssignSlotToTextBox(txtC2, slots[9]);
                AssignSlotToTextBox(txtC3, slots[10]);
                AssignSlotToTextBox(txtC4, slots[11]);

                AssignSlotToTextBox(txtD1, slots[12]);
                AssignSlotToTextBox(txtD2, slots[13]);
                AssignSlotToTextBox(txtD3, slots[14]);
                AssignSlotToTextBox(txtD4, slots[15]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AssignSlotToTextBox(TextBox textBox, ParkingSlot slot)
        {
            if (slot != null)
            {
                // Gán SlotNumber vào TextBox

                // Kiểm tra xem vị trí đã bị chiếm chưa (IsOccupied)
                if (slot.IsOccupied == true)
                {
                    // Thay đổi màu nền của TextBox thành màu đỏ nếu đã có xe đậu
                    textBox.BackColor = Color.Red;
                }
                else
                {
                    // Nếu vị trí trống, đặt màu nền về mặc định
                    textBox.BackColor = Color.White;
                }
            }
        }
    }
}
