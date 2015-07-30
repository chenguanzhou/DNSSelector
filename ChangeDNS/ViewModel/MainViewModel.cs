using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Collections.Generic;

namespace ChangeDNS.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}


            SystemDNS.RefreshSystemDNS();
        }

       

        #region Properties
        private DNSViewModel systemDNS = new DNSViewModel();
        public DNSViewModel SystemDNS
        {
            get
            {
                return systemDNS;
            }
            set
            {
                systemDNS = value;
                RaisePropertyChanged("SystemDNS");
            }
        }

        private Dictionary<string, DNSViewModel> innerDNS = new Dictionary<string, DNSViewModel>()
        {
            {"Google DNS", new DNSViewModel(){ DNS1="8.8.8.8", DNS2="8.8.4.4"} },
            {"114 DNS", new DNSViewModel(){ DNS1="114.114.114.114", DNS2="114.114.115.115"} },
            {"Ali DNS", new DNSViewModel(){ DNS1="223.5.5.5", DNS2="223.6.6.6"} }
        };

        public Dictionary<string, DNSViewModel>.KeyCollection DNSNames
        {
            get
            {
                return innerDNS.Keys;
            }
        }

        private string activeDNSName = null;
        public string ActiveDNSName
        {
            get
            {
                return activeDNSName;
            }
            set
            {
                if (activeDNSName == value)
                    return;
                activeDNSName = value;
                ActiveDNS = innerDNS[activeDNSName];
                RaisePropertyChanged("ActiveDNSName");
            }
        }

        private DNSViewModel activeDNS = new DNSViewModel();
        public DNSViewModel ActiveDNS
        {
            get
            {
                return activeDNS;
            }
            set
            {
                activeDNS = value;
                RaisePropertyChanged("ActiveDNS");
            }
        }

        #endregion

        #region Commands
        void RefreshSystemDNSExcute()
        {
            SystemDNS.RefreshSystemDNS();
        }

        public ICommand RefreshSystemDNS
        {
            get
            {
                return new RelayCommand(RefreshSystemDNSExcute);
            }
        }

        void SetCurrentDNSExcute()
        {
            string[] dns = new string[] {
                ActiveDNS.DNS1,
                ActiveDNS.DNS2
            };

            NetworkSetting.SetDNS(dns);
            SystemDNS.RefreshSystemDNS();
        }

        public ICommand SetCurrentDNS
        {
            get
            {
                return new RelayCommand(SetCurrentDNSExcute);
            }
        }
        #endregion
    }
}