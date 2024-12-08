using System.Windows;

namespace Project_KTPMUD
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy thông tin từ các ô nhập liệu
            string fullName = FullNameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // Kiểm tra xem các trường có để trống không
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp không
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu và Xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Xử lý lưu thông tin đăng ký (tạm thời hiển thị thông báo thành công)
            MessageBox.Show($"Đăng ký thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            // Đóng cửa sổ sau khi đăng ký
            this.Close();
        }


    }
}