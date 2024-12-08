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
using System.Diagnostics;
using System.IO;


namespace Project_KTPMUD.PageD1
{
    
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

        }


        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            // Lấy nút vừa được click
            var button = sender as Button;

            // Lấy đường dẫn file từ thuộc tính Tag
            string filePath = button?.Tag as string;

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Không có file để mở!");
                return;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    // Mở file bằng trình duyệt mặc định hoặc Google Chrome
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở file: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("File không tồn tại!");
            }
        }

        private void BackToHuyen_Click(object sender, RoutedEventArgs e)
        {
            // Chuyển hướng về Window Huyện
            HuyenWindow HuyenWindow = new HuyenWindow(); // Tạo cửa sổ Huyện
            HuyenWindow.Show(); // Hiển thị cửa sổ Huyện
            Window.GetWindow(this).Close(); // Đóng trang hiện tại
        }
    }
}
