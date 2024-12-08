using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace Project_KTPMUD
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();

            // Đường dẫn tương đối đến file PDF
            string relativePath = "Files/LuatTaiNguyenNuoc.pdf";
            string fullPath = GetAbsolutePath(relativePath);

            // Hiển thị file PDF
            LoadPdf(fullPath);
        }

        private string GetAbsolutePath(string relativePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return System.IO.Path.Combine(baseDirectory, relativePath);
        }

        private void LoadPdf(string filePath)
        {
            if (File.Exists(filePath))
            {
                PdfViewer.Navigate(new Uri(filePath));
            }
            else
            {
                throw new FileNotFoundException($"Không tìm thấy file PDF tại: {filePath}");
            }
        }
    }
}