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

namespace Project_KTPMUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
             if ((bool)XaRadioButton.IsChecked)
            {
                // Mở cửa sổ dành cho Đơn vị hành chính cấp Xã
                XaWindow xaWindow = new XaWindow();
                xaWindow.Show();
                this.Close();
            }
            
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò đăng nhập!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void RegisterLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }
    }

}
