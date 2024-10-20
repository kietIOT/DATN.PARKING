using DATN.PARKING.DLL;
using DATN.PARKING.DLL.Models.DbTable;
using DATN.PARKING.SERVICE.InterfaceMethod;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.IO.Ports;

namespace DATN.PARKING.UIUX
{
    public partial class frmMain : Form
    {
        private readonly IHardwareService _hardwareService;
        private readonly IServiceParking _serviceParking;
        private readonly SerialPort serialPortIn;
        private SerialPort serialPortOut;
        private VideoCapture _cameraGateIn;
        private VideoCapture _cameraGateOut;
        private bool _isRunning;
        private readonly object _lock = new object();


        public frmMain(IHardwareService hardwareService,IServiceParking serviceParking)
        {
            try
            {
                InitializeComponent();
                _serviceParking = serviceParking;
                _hardwareService = hardwareService;
                _serviceParking.TcpInit();

          //      _hardwareService.ServoInit("COM3", 9600);
          
           //     _hardwareService.QrScanInit("COM5", 9600, ref serialPortIn, SerialPortGateIn_DataReceived);
              //  _hardwareService.QrScanInit("COM5", 9600, ref serialPortIn, SerialPortGateOut_DataReceived);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void SerialPortGateIn_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Đọc dữ liệu từ SerialPort
            string data = _hardwareService.ReadDataQrScan(serialPortIn);
            if (data == null)
            {
                MessageBox.Show($"Không đọc được CCCD", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var parkingSesson = new ParkingSession();

            parkingSesson.EntryTime = DateTime.Now;
            parkingSesson.IsPaid = true;
            parkingSesson.Vehicle = new Vehicle();
            parkingSesson.Vehicle.Customer = new Customer();    
            parkingSesson.Vehicle.Customer.CCCD = data.Trim();
            


            Invoke(new MethodInvoker(delegate
            {

            }));
            GateIn(parkingSesson);

            _serviceParking.AddParkingSession(parkingSesson);

            //txtBienSoVao.Text = parkingSesson.Vehicle.LicensePlate.Trim();


        }
        private void SerialPortGateOut_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Đọc dữ liệu từ SerialPort
            //_hardwareService.QrScanGateIn(serialPortIn);
            string data = _hardwareService.ReadDataQrScan(serialPortOut);
            
            if(data == null)
            {
                MessageBox.Show($"Không đọc được CCCD", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            Invoke(new MethodInvoker(delegate
            {

            }));
            

            GateOut();

        }


        private async void frmMain_Load(object sender, EventArgs e)
        {
            try
            {

                Label lbGateIn = new Label();
                Label lbGateOut = new Label();
                lbGateIn.Text = "Xe vào";
                lbGateOut.Text = "Xe ra";
                lbGateIn.ForeColor = lbGateOut.ForeColor = Color.Red;
                lbGateIn.BackColor = lbGateOut.BackColor = Color.Transparent; // Để nền của label trong suốt
                lbGateIn.AutoSize = lbGateOut.AutoSize = true; // Tự động điều chỉnh kích thước theo nội dung
                lbGateIn.Font = lbGateOut.Font = new Font("Arial", 30, FontStyle.Bold); // Đặt font với kích thước lớn (30)

                // Đặt vị trí cho Label (vị trí này là tương đối so với PictureBox)
                lbGateIn.Location = lbGateOut.Location = new System.Drawing.Point(10, 10); // Đặt tại góc trên bên trái của PictureBox
                videoGateIn.Controls.Add(lbGateIn);
                videoGateOut.Controls.Add(lbGateOut);
                lbGateIn.BringToFront();
                lbGateOut.BringToFront();

                _cameraGateIn = new VideoCapture(0); // 0 cho camera mặc định
                // _cameraGateOut = new VideoCapture(1);
                _isRunning = true;

                // Tạo một task để xử lý video trong background

                     Task.Run(() => ProcessVideoCameraGateIn());
                //     Task.Run(() => ProcessVideoCameraGateOut());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ProcessVideoCameraGateIn()
        {
            try
            {
                while (_isRunning)
                {
                    using var frame = new Mat();
                    _cameraGateIn.Read(frame); // Đọc khung hình từ camera

                    if (frame.Empty())
                    {
                        Console.WriteLine("Không thể đọc từ camera.");
                        break;
                    }

                    // Chuyển đổi khung hình từ OpenCV (Mat) sang Bitmap để hiển thị
                    var image = frame.ToBitmap();

                    // Cập nhật hình ảnh trên PictureBox trong luồng UI
                    UpdatePictureBox(image);
                }

                _cameraGateIn.Release();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ProcessVideoCameraGateOut()
        {
            try
            {
                while (_isRunning)
                {
                    using var frame = new Mat();
                    _cameraGateOut.Read(frame); // Đọc khung hình từ camera

                    if (frame.Empty())
                    {
                        MessageBox.Show("Không thể đọc từ camera. Vui lòng kiểm tra và thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chuyển đổi khung hình từ OpenCV (Mat) sang Bitmap để hiển thị
                    var image = frame.ToBitmap();

                    // Cập nhật hình ảnh trên PictureBox trong luồng UI
                    UpdatePictureBox(image);
                }

                _cameraGateOut.Release();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdatePictureBox(Bitmap image)
        {
            try
            {
                // Sử dụng lock để đảm bảo việc cập nhật PictureBox được đồng bộ
                lock (_lock)
                {
                    // Cập nhật PictureBox trong luồng UI
                    if (videoGateOut.InvokeRequired)
                    {
                        videoGateOut.Invoke(new Action(() =>
                        {
                            videoGateOut.Image?.Dispose(); // Giải phóng tài nguyên ảnh cũ
                            videoGateOut.Image = image;
                        }));
                    }
                    if (videoGateIn.InvokeRequired)
                    {
                        videoGateIn.Invoke(new Action(() =>
                        {
                            videoGateIn.Image?.Dispose(); // Giải phóng tài nguyên ảnh cũ
                            videoGateIn.Image = image;
                        }));
                    }
                    else
                    {
                        videoGateIn.Image?.Dispose();
                        videoGateIn.Image = image;
                        videoGateOut.Image?.Dispose();
                        videoGateOut.Image = image;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _isRunning = false;
            base.OnFormClosing(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

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
            var frm = new frmLogin(null, null);
            frm.ShowDialog();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isRunning = false;
            base.OnFormClosing(e);

        }
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
                case Keys.I:
                    _hardwareService.Servo("GateIn");
                    break;

                case Keys.O:
                    _hardwareService.Servo("GateOut");
                    break;
                case Keys.F:
                    _serviceParking.SendDataToRegonize(@"D:\DATN_DEV\DATN.PARKING\Auto_parking\bin\Debug\ImageTest\keit.jpg");
                    break;

            }

        }

        private async void GateIn(ParkingSession parkingSession)
        {
            try
            {
                // Đọc khung hình hiện tại từ camera videoGateIn
                using var frame = new Mat();
                _cameraGateIn.Read(frame);

                if (!frame.Empty())
                {
                    var image = frame.ToBitmap();

                    // Cập nhật PictureBox picGateIn với hình ảnh vừa chụp
                    if (picGateIn.InvokeRequired)
                    {
                        picGateIn.Invoke(new Action(() =>
                        {
                            picGateIn.Image?.Dispose(); // Giải phóng tài nguyên ảnh cũ
                            picGateIn.Image = image;    // Hiển thị ảnh mới
                        }));
                    }
                    else
                    {
                        picGateIn.Image?.Dispose();
                        picGateIn.Image = image;
                    }

                    if (!_serviceParking.SaveCapturedImage(image,"GateIn"))
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var plateLicense = await _serviceParking.SendDataToRegonize("");
                    if (plateLicense.IsEmpty())
                    {
                        MessageBox.Show($"Không đọc được biển số xe, vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    parkingSession.Vehicle.LicensePlate = plateLicense;

                }
                else
                {
                    MessageBox.Show("Không thể chụp ảnh từ camera. Vui lòng thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (btnAuto.Checked)
                {
                    _hardwareService.Servo("GateIn");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GateOut()
        {
            try
            {
                #region Chup anh va luu anh
                // Đọc khung hình hiện tại từ camera videoGateIn
                using var frame = new Mat();
                _cameraGateOut.Read(frame);

                if (!frame.Empty())
                {
                    var image = frame.ToBitmap();

                    // Cập nhật PictureBox picGateIn với hình ảnh vừa chụp
                    if (picGateIn.InvokeRequired)
                    {
                        picGateIn.Invoke(new Action(() =>
                        {
                            picGateIn.Image?.Dispose(); // Giải phóng tài nguyên ảnh cũ
                            picGateIn.Image = image;    // Hiển thị ảnh mới
                        }));
                    }
                    else
                    {
                        picGateIn.Image?.Dispose();
                        picGateIn.Image = image;
                    }

                    if (!_serviceParking.SaveCapturedImage(image,"GateOut"))
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu ảnh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Không thể chụp ảnh từ camera. Vui lòng thử lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                #endregion
                #region Doc CCCD / van tay/ rfid
                #endregion
                _hardwareService.Servo("GateIn");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void cmtAreaParkingMap_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmParkingArea(_serviceParking);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
