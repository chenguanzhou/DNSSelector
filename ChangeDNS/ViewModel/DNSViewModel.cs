using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeDNS.ViewModel
{
    public class DNSViewModel : ViewModelBase
    {
        public DNSViewModel()
        {
        }

        public void RefreshSystemDNS()
        {
            string[] dns = NetworkSetting.GetSystemDNS();
            if (dns.Count()>0)
                DNS1 = dns[0];
            if (dns.Count()>1)
                DNS2 = dns[1];
        }

        private string dns1 = null;
        public string DNS1
        {
            get
            {
                return dns1;
            }
            set
            {
                dns1 = value;
                RaisePropertyChanged("DNS1");
            }
        }

        private string dns2 = null;
        public string DNS2
        {
            get
            {
                return dns2;
            }
            set
            {
                dns2 = value;
                RaisePropertyChanged("DNS2");
            }
        }
    }
}
