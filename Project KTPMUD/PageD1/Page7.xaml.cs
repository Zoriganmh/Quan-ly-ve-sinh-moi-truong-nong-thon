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

namespace Project_KTPMUD.PageD1
{
    /// <summary>
    /// Interaction logic for Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {
        public Page7()
        {
            InitializeComponent();
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
