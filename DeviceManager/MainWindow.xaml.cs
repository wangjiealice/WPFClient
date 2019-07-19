using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;


namespace DeviceManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public DeviceManagerViewModel ViewModel { get; } =
           (App.Current as App).Container.GetService<DeviceManagerViewModel>();
    }
}
