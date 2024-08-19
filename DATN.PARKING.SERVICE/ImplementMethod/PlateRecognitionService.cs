using DATN.PARKING.SERVICE.InterfaceMethod;
using IronOcr;
using OpenCvSharp;
namespace DATN.PARKING.SERVICE.ImplementMethod
{
    public  class PlateRecognitionService: IPlateRecognitonService
    {
        private readonly IronTesseract _ocr;
        public PlateRecognitionService()
        {
            _ocr = new IronTesseract
            {
                Language = IronOcr.OcrLanguage.English
            };
        }
        public string RecognizePlate(Mat frame)
        {
            // Convert to grayscale
            Mat gray = new Mat();
            Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);

            // Apply Gaussian blur to reduce noise
            Mat blurred = new Mat();
            Cv2.GaussianBlur(gray, blurred, new Size(5, 5), 0);

            // Detect edges using Canny edge detection
            Mat edged = new Mat();
            Cv2.Canny(blurred, edged, 75, 200);

            // Find contours
            Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(edged, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            Mat plate = null;
            foreach (var contour in contours)
            {
                var peri = Cv2.ArcLength(contour, true);
                var approx = Cv2.ApproxPolyDP(contour, 0.018 * peri, true);
                if (approx.Length == 4)
                {
                    // Assume the contour with four vertices is the plate
                    var rect = Cv2.BoundingRect(approx);
                    plate = new Mat(frame, rect);
                    break;
                }
            }

            if (plate == null)
            {
                throw new Exception("License plate could not be detected.");
            }

            // Show detected plate (optional)
            Cv2.ImShow("Detected Plate", plate);
            Cv2.WaitKey(0);

            // Perform OCR on the detected plate
            using (var ocrInput = new OcrInput(plate.ToBytes()))
            {
                var result = _ocr.Read(ocrInput);
                return result.Text;
            }
        }
    }
}
