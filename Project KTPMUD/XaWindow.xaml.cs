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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace Project_KTPMUD
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class XaWindow : Window
    {
        private ObservableCollection<ThốngKê> statistics = new ObservableCollection<ThốngKê>();
        private ObservableCollection<ThốngKê> additionalStatistics = new ObservableCollection<ThốngKê>();
        private ObservableCollection<FileDetails> fileDetailsList = new ObservableCollection<FileDetails>();
        private ObservableCollection<CongTrinhNuocCapNhoLe> congTrinhList = new ObservableCollection<CongTrinhNuocCapNhoLe>();
        private ObservableCollection<CoSoChanNuoi> coSoChanNuoiList = new ObservableCollection<CoSoChanNuoi>();
        private ObservableCollection<DieuKienCoSoChanNuoi> dieuKienCoSoChanNuoiList = new ObservableCollection<DieuKienCoSoChanNuoi>();
        private ObservableCollection<GiayChungNhan> giayChungNhanList = new ObservableCollection<GiayChungNhan>();
        private ObservableCollection<CoSoCheBien> coSoCheBienList = new ObservableCollection<CoSoCheBien>();

        private bool isMenuVisible = true; // Biến trạng thái của menu
        public XaWindow()
        {
            InitializeComponent();
            MenuColumn.Width = new GridLength(0);
            DataContext = this; // Đặt DataContext để liên kết dữ liệu
                                // Liên kết DataGrid với ObservableCollection
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { // This should also ensure the DataGrid is properly loaded
            StatisticsGrid1.ItemsSource = statistics;
            StatisticsGrid2.ItemsSource = statistics;
            StatisticsGrid3.ItemsSource = fileDetailsList;
            CongTrinhGrid.ItemsSource = congTrinhList;
            CoSoChanNuoiGrid.ItemsSource = coSoChanNuoiList;
            CoSoChanNuoiGrid.ItemsSource = dieuKienCoSoChanNuoiList;
            GiayChungNhanGrid.ItemsSource = giayChungNhanList;
            CoSoCheBienGrid.ItemsSource = coSoCheBienList;
        }

        private void ToggleMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuColumn.Width.Value == 0)
            {
                // Mở rộng thanh menu
                MenuColumn.Width = new GridLength(250); // Đặt chiều rộng mong muốn (ví dụ: 250px)
                ToggleMenuButton.Content = "✕"; // Đổi biểu tượng nút
            }
            else
            {
                // Thu hẹp thanh menu
                MenuColumn.Width = new GridLength(0); // Thu hẹp về 0
                ToggleMenuButton.Content = "☰"; // Đổi lại biểu tượng nút
            }

        }
        private void ManageButton_Click(object sender, RoutedEventArgs e)
        { // Hiển thị hoặc ẩn StackPanel chứa các tùy chọn quản lý
            MessageBox.Show("ManageButton Clicked"); if (ManagementOptions.Visibility == Visibility.Collapsed) { ManagementOptions.Visibility = Visibility.Visible; MessageBox.Show("ManagementOptions Visible"); } else { ManagementOptions.Visibility = Visibility.Collapsed; MessageBox.Show("ManagementOptions Collapsed"); }
        }


            private void UserIconButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Sự kiện nhấn nút tìm kiếm
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTextBox.Text == "Nhập từ khóa để tìm kiếm" && SearchTextBox.IsFocused)
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = Brushes.Black;
                SearchTextBox.CaretIndex = 0; // Đặt con trỏ tại đầu
            }
            else if (string.IsNullOrWhiteSpace(SearchTextBox.Text) && !SearchTextBox.IsFocused)
            {
                SearchTextBox.Text = "Nhập từ khóa để tìm kiếm";
                SearchTextBox.Foreground = Brushes.Gray;
            }
        }
        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            // Logic tìm kiếm của bạn ở đây
            MessageBox.Show("Bạn đang tìm kiếm: " + searchText);
        }


        private void ToggleSection2_Click(object sender, RoutedEventArgs e)
        {
            Section2Details.Visibility = Section2Details.Visibility == Visibility.Visible
                                         ? Visibility.Collapsed
                                         : Visibility.Visible;
            ToggleSection2Button.Content = Section2Details.Visibility == Visibility.Visible
                                            ? "Quản lý thông tin về nước sạch và vệ sinh môi trường nông thôn ▲"
                                            : "Quản lý thông tin về nước sạch và vệ sinh môi trường nông thôn ▼";
        }

        private void ToggleSection3_Click(object sender, RoutedEventArgs e)
        {
            Section3Details.Visibility = Section3Details.Visibility == Visibility.Visible
                                         ? Visibility.Collapsed
                                         : Visibility.Visible;
            ToggleSection3Button.Content = Section3Details.Visibility == Visibility.Visible
                                            ? "Báo cáo thống kê về CSDL nước sạch và vệ sinh môi trường nông thôn ▲"
                                            : "Báo cáo thống kê về CSDL nước sạch và vệ sinh môi trường nông thôn ▼";
        }

        private void ToggleSection4_Click(object sender, RoutedEventArgs e)
        {
            Section4Details.Visibility = Section4Details.Visibility == Visibility.Visible
                                         ? Visibility.Collapsed
                                         : Visibility.Visible;
            ToggleSection4Button.Content = Section4Details.Visibility == Visibility.Visible
                                            ? "Quản lý Văn bản pháp luật về CSDL nước sạch và vệ sinh môi trường nông thôn ▲"
                                            : "Quản lý Văn bản pháp luật về CSDL nước sạch và vệ sinh môi trường nông thôn ▼";
        }

        private void ToggleSection5_Click(object sender, RoutedEventArgs e)
        {
            Section5Details.Visibility = Section5Details.Visibility == Visibility.Visible
                                         ? Visibility.Collapsed
                                         : Visibility.Visible;
            ToggleSection5Button.Content = Section5Details.Visibility == Visibility.Visible
                                            ? "Quản lý CSDL các cơ sở chăn nuôi ▲"
                                            : "Quản lý CSDL các cơ sở chăn nuôi ▼";
        }

        // Mở Popup khi click vào biểu tượng người dùng
        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            // Mở hoặc đóng Popup
            UserMenuPopup.IsOpen = !UserMenuPopup.IsOpen;
        }

        // Xử lý khi chọn "Chỉnh sửa thông tin cá nhân"
        private void EditProfileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chức năng chỉnh sửa thông tin cá nhân!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Xử lý khi chọn "Đăng xuất"
        private void LogoutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Đăng xuất",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result == MessageBoxResult.Yes)
            {
                // Thực hiện hành động đăng xuất (ví dụ: đóng cửa sổ hiện tại và mở cửa sổ đăng nhập)


                MainWindow MainWindow = new MainWindow();
                MainWindow.Show();
                this.Close();

            }
        }
        // 13-12 thêm bảng thống kê quản lý công trình nước
        private void ToggleSection1_Click(object sender, RoutedEventArgs e)
        {
            if (Section1Details.Visibility == Visibility.Collapsed)
            {
                Section1Details.Visibility = Visibility.Visible;
                ToggleSection1Button.Content = "Quản lý quy hoạch nước sạch và vệ sinh môi trường nông thôn ▲";
            }
            else
            {
                Section1Details.Visibility = Visibility.Collapsed;
                ToggleSection1Button.Content = "Quản lý quy hoạch nước sạch và vệ sinh môi trường nông thôn ▼";
            }
        }

        // Quản lý Quy hoạch 
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenCongTrinh.Text) && !string.IsNullOrWhiteSpace(txtNgaydivaohoatdong.Text))
            {
                AddNewRow(txtTenCongTrinh.Text, chkHoatDong.IsChecked ?? false, txtNgaydivaohoatdong.Text);
                txtTenCongTrinh.Clear();
                chkHoatDong.IsChecked = false;
                txtNgaydivaohoatdong.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
            }
        }
        private void AddNewRow(string tenCongTrinh, bool hoatDong, string ngaydivaohoatdong)
        {

            int newIndex = statistics.Count + 1;
            var giayToList = new ObservableCollection<GiayTo>
            {
                new GiayTo { TenFile = "File1", DacTinhFile = "Đặc tính file 1" },
                new GiayTo { TenFile = "File2", DacTinhFile = "Đặc tính file 2" }
            };
            statistics.Add(new ThốngKê
            {
                STT = newIndex,
                TenCongTrinh = tenCongTrinh,
                HoatDong = hoatDong,
                GiayToList = giayToList

            });
        }
        private void OnDeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is ThốngKê selectedItem)
                {
                    statistics.Remove(selectedItem);
                    ReIndexStatistics(statistics); // Sắp xếp lại mà không cần đặt lại ItemsSource
                }
            }
        }

        private void OnDetailButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is ThốngKê selectedItem)
                { // Xử lý logic hiển thị chi
                  // tiết
                  //
                }
            }
        }
        private void ReIndexStatistics(ObservableCollection<ThốngKê> statistics)
        {
            for (int i = 0; i < statistics.Count; i++)
            {
                statistics[i].STT = i + 1;
            }
        }



        //Quan ly file
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is FileDetails fileDetails)
                { // Thay thế đường dẫn này với đường dẫn thực tế đến file trên máy tính của bạn
                    /*
                           string filePath = $"C:\\Path\\To\\Your\\Files\\{fileDetails.TenFile}";
                           try
                           {
                               Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                           }
                           catch (System.Exception ex)
                           {
                               MessageBox.Show($"Không thể mở file: {ex.Message}");
                           }
                    */
                }

            }
        }
        private void ReIndexStatistics(ObservableCollection<FileDetails> fileDetails)
        {
            for (int i = 0; i < statistics.Count; i++)
            {
                statistics[i].STT = i + 1;
            }
        }
        private void OnDetailButtonClickGCN(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is GiayChungNhan selectedGiayChungNhan)
                { // Hiển thị chi tiết giấy chứng nhận
                  MessageBox.Show($"Chi tiết về: {selectedGiayChungNhan.TenGiayChungNhan}", "Thông tin chi tiết", MessageBoxButton.OK, MessageBoxImage.Information); 
                } 
            } 
        }

       

    }

    public class GiayTo
    {
        public string TenFile { get; set; }
        public string DacTinhFile { get; set; }
    }
    public class CongTrinh
    {
        public int STT { get; set; }
        public string TenCongTrinh { get; set; }
        public string ThoiGianBatDau { get; set; }
        public string ThoiGianThiCong { get; set; }
        public string DienTich { get; set; }
    }
    public class FileDetails
    {
        public int STT { get; set; }
        public string TenFile { get; set; }
        public string NhanDanFile { get; set; }
    }
    /// <summary>
    /// Quản lý thông tin 
    /// </summary>
    public class ThốngKê
    {
        public int STT { get; set; }
        public string TenCongTrinh { get; set; }
        public bool HoatDong { get; set; }
        public ObservableCollection<GiayTo> GiayToList { get; set; } = new ObservableCollection<GiayTo>(); // Initialize with an empty collection
    }
    public class CongTrinhNuocCapNhoLe
    {
        public int STT { get; set; }
        public string TenCongTrinh { get; set; }
        public string LoaiCongTrinh { get; set; }
        public int NamXayDung { get; set; }
        public string ChuDauTu { get; set; }
        public string DonViQuanLy { get; set; }
    }

    //Quan ly co so chan nuoi
    public class CoSoChanNuoi
    {
        public int STT { get; set; }
        public string TenCoSo { get; set; }
        public string LoaiHinhChanNuoi { get; set; }
        public bool ToChuc { get; set; }
        public bool CaNhan { get; set; }
    }
    public class DieuKienCoSoChanNuoi
    {
        public int STT { get; set; }
        public string TenCoSo { get; set; }
        public string QuyMoChanNuoi { get; set; }
        public string GiayPhep { get; set; }

    }
    public class GiayChungNhan 
    { 
        public int STT { get; set; } 
        public string TenGiayChungNhan { get; set; }
    }
    public class CoSoCheBien 
    { 
        public int STT { get; set; } 
        public string TenCoSo { get; set; } 
        public string LoaiSanPham { get; set; } 
        public string SoDienThoai { get; set; } 
        public string MaSoThue { get; set; } 
    }
}
