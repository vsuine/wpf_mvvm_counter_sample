using System.Windows;
using Sample.Model;
using Sample.ViewModel;

namespace Sample.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // DataContextに対応するViewModelを代入して紐づける
            this.DataContext = new MainWindowViewModel(new CounterModel()); // 依存性注入
            InitializeComponent();
        }
    }
}
