using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tesseract;
namespace Auto_parking.Service
{
    public class RegonizePlateLicense : IRegonizePlateLicense
    {
        #region định nghĩa
        List<Image<Bgr, byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        Image Plate_Draw;
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();

        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private const string m_lang = "eng";

        private readonly HttpListener _listener;
        #endregion
        public RegonizePlateLicense()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://localhost:8080/");
        }

        public void StartListening()
        {
            _listener.Start();
            Console.WriteLine("Listening for API requests on http://localhost:8080/...");
            Task.Run(() => Listen());
        }

        private async Task Listen()
        {
            while (true)
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                await HandlePostRequest(context);
            }
        }
        private async Task HandlePostRequest(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            RegonizeInit();
            // Đọc dữ liệu POST gửi đến
            using (var reader = new System.IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding))
            {
                string requestBody = await reader.ReadToEndAsync();
                Console.WriteLine("POST data received: " + requestBody);

                string responseString = ReadPlateLicenseNumber().Trim();
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }
        public string ReadPlateLicenseNumber()
        {
            string startupPath = Application.StartupPath + "\\ImageTest\\keit.jpg"; // Replace with your image path

            Image temp1;
            string temp2, temp3;
            Reconize(startupPath, out temp1, out temp2, out temp3);
            if (temp3 == "")
                return "Cannot recognize license plate!";
            else
                return temp3;

        }
        public void RegonizeInit()
        {
            full_tesseract = new TesseractProcessor();
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTVXY1234567890").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFHKLMNPRSTUVXY").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Tesseract initialization failed. The application will exit.");
                Application.Exit();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();
            m_path = System.Environment.CurrentDirectory + "\\";

        }
        public void Reconize(string link, out Image hinhbienso, out string bienso, out string bienso_text)
        {
            try
            {
                hinhbienso = null;
                bienso = "";
                bienso_text = "";
                ProcessImage(link);
                if (PlateImagesList.Count != 0)
                {
                    Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                    Bitmap grayframe;
                    FindContours con = new FindContours();
                    Bitmap color;
                    int c = con.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);  // find contour
                                                                                                                      //int z = con.count;
                                                                                                                      // pictureBox_BiensoVAO.Image = color;
                                                                                                                      // IF.pictureBox1.Image = color;
                    hinhbienso = Plate_Draw;
                    Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                    grayframe = dst.ToBitmap();
                    string zz = "";

                    // lọc và sắp xếp số
                    List<Bitmap> bmp = new List<Bitmap>();
                    List<int> erode = new List<int>();
                    List<Rectangle> up = new List<Rectangle>();
                    List<Rectangle> dow = new List<Rectangle>();
                    int up_y = 0, dow_y = 0;
                    bool flag_up = false;

                    int di = 0;

                    if (listRect == null) return;

                    for (int i = 0; i < listRect.Count; i++)
                    {
                        Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                        int cou = 0;
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        string temp = full_tesseract.Apply(ch);
                        while (temp.Length > 3)
                        {
                            Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                            temp2 = temp2.Erode(2);
                            ch = temp2.ToBitmap();
                            full_tesseract.Clear();
                            full_tesseract.ClearAdaptiveClassifier();
                            temp = full_tesseract.Apply(ch);
                            cou++;
                            if (cou > 10)
                            {
                                listRect.RemoveAt(i);
                                i--;
                                di = 0;
                                break;
                            }
                            di = cou;
                        }
                    }

                    for (int i = 0; i < listRect.Count; i++)
                    {
                        for (int j = i; j < listRect.Count; j++)
                        {
                            if (listRect[i].Y > listRect[j].Y + 100)
                            {
                                flag_up = true;
                                up_y = listRect[j].Y;
                                dow_y = listRect[i].Y;
                                break;
                            }
                            else if (listRect[j].Y > listRect[i].Y + 100)
                            {
                                flag_up = true;
                                up_y = listRect[i].Y;
                                dow_y = listRect[j].Y;
                                break;
                            }
                            if (flag_up == true) break;
                        }
                    }

                    for (int i = 0; i < listRect.Count; i++)
                    {
                        if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                        {
                            up.Add(listRect[i]);
                        }
                        else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                        {
                            dow.Add(listRect[i]);
                        }
                    }

                    if (flag_up == false) dow = listRect;

                    for (int i = 0; i < up.Count; i++)
                    {
                        for (int j = i; j < up.Count; j++)
                        {
                            if (up[i].X > up[j].X)
                            {
                                Rectangle w = up[i];
                                up[i] = up[j];
                                up[j] = w;
                            }
                        }
                    }
                    for (int i = 0; i < dow.Count; i++)
                    {
                        for (int j = i; j < dow.Count; j++)
                        {
                            if (dow[i].X > dow[j].X)
                            {
                                Rectangle w = dow[i];
                                dow[i] = dow[j];
                                dow[j] = w;
                            }
                        }
                    }

                    int x = 12;
                    int c_x = 0;

                    for (int i = 0; i < up.Count; i++)
                    {
                        Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                        Bitmap o = ch;
                        string temp;
                        if (i < 2)
                        {
                            temp = Ocr(ch, false, true); // nhan dien so
                        }
                        else
                        {
                            temp = Ocr(ch, false, false);// nhan dien chu
                        }

                        zz += temp.Replace("\n\n", "");

                        c_x++;
                    }

                    for (int i = 0; i < dow.Count; i++)
                    {
                        Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                        //ch = con.Erodetion(ch);
                        string temp = Ocr(ch, false, true); // nhan dien so
                        zz += temp.Replace("\n\n","");

                    }
                    bienso = zz;
                    bienso = bienso;
                    bienso_text = zz;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string Ocr(Bitmap image_s, bool isFull, bool isNum = false)
        {
            string temp = "";
            Image<Gray, byte> src = new Image<Gray, byte>(image_s);
            double ratio = 1;
            while (true)
            {
                ratio = (double)CvInvoke.cvCountNonZero(src) / (src.Width * src.Height);
                if (ratio > 0.5) break;
                src = src.Dilate(2);
            }
            Bitmap image = src.ToBitmap();

            TesseractProcessor ocr;
            if (isFull)
                ocr = full_tesseract;
            else if (isNum)
                ocr = num_tesseract;
            else
                ocr = ch_tesseract;

            int cou = 0;
            ocr.Clear();
            ocr.ClearAdaptiveClassifier();
            temp = ocr.Apply(image);
            while (temp.Length > 3)
            {
                Image<Gray, byte> temp2 = new Image<Gray, byte>(image);
                temp2 = temp2.Erode(2);
                image = temp2.ToBitmap();
                ocr.Clear();
                ocr.ClearAdaptiveClassifier();
                temp = ocr.Apply(image);
                cou++;
                if (cou > 10)
                {
                    temp = "";
                    break;
                }
            }
            return temp;
        }
        private void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            FileStream fs = new FileStream(urlImage, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap image = new Bitmap(img);
            //pictureBox2.Image = image;
            //IF.pictureBox2.Image = image;
            fs.Close();

            FindLicensePlate4(image, out Plate_Draw);

        }
        private void FindLicensePlate4(Bitmap image, out Image plateDraw)
        {
            plateDraw = null;
            Image<Bgr, byte> frame;
            bool isface = false;
            Bitmap src;
            //pictureBox2.Image = new Image<Gray, byte>(image).ToBitmap();
            Image dst = image;
            HaarCascade haar = new HaarCascade(Application.StartupPath + "\\output-hv-33-x25.xml");
            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {
                        var faces =
                       grayframe.DetectHaarCascade(haar, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(0, 0))[0];
                        foreach (var face in faces)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = face.rect;

                            frame.Draw(face.rect, new Bgr(Color.Blue), 2);

                            PlateImagesList.Add(tmp);

                            isface = true;
                        }
                        if (isface)
                        {
                            Image<Bgr, byte> showimg = frame.Clone();
                            plateDraw = (Image)showimg.ToBitmap();
                            //showimg = frame.Resize(imageBox1.Width, imageBox1.Height, 0);
                            //pictureBox1.Image = showimg.ToBitmap();
                            //IF.pictureBox2.Image = showimg.ToBitmap();
                            if (PlateImagesList.Count > 1)
                            {
                                for (int k = 1; k < PlateImagesList.Count; k++)
                                {
                                    if (PlateImagesList[0].Width < PlateImagesList[k].Width)
                                    {
                                        PlateImagesList[0] = PlateImagesList[k];
                                    }
                                }
                            }
                            PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                            return;
                        }

                    }
                }
            }

        }
        private static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }
    }
}
