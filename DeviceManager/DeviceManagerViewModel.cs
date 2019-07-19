using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace DeviceManager
{
    public class DeviceManagerViewModel : INotifyPropertyChanged
    {
        #region Property
        private string usbVersion = "Not known";
        public string USBVersion
        {
            get
            {
                return usbVersion;
            }
            set
            {
                usbVersion = value;
                OnPropertyChanged("USBVersion");
            }
        }

        private string deviceVersion = "Not known";
        public string DeviceVersion
        {
            get
            {
                return deviceVersion;
            }
            set
            {
                deviceVersion = value;
                OnPropertyChanged("DeviceVersion");
            }
        }
        #endregion

        #region Command
        public ICommand StartScanningCommand
        {
            get
            {
                return new DelegateCommand(OnStartScanningRaised);
            }
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new DelegateCommand(OnLoadRaised);
            }
        }
        #endregion

        private void OnLoadRaised()
        {
        }
            private void OnStartScanningRaised()
        {
            var devices = WPFUsbView.TreeViewUsbItem.AllUsbDevices;
            var axiocamCamera = WPFUsbView.TreeViewUsbItem.AxiocamCamera;
            if(axiocamCamera != null)
            {
                DeviceVersion = axiocamCamera.Value.DeviceVersion;
                USBVersion = axiocamCamera.Value.UsbVersion;
            }
            else
            {
                MessageBox.Show("No camera detected!!!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string strPropertyInfo)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyInfo));
            }
        }
    }
}
