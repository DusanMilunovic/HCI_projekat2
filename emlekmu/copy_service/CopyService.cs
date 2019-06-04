using emlekmu.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.copy_service
{
    public class CopyService: INotifyPropertyChanged
    {
        private static CopyService instance = null;
        private static readonly object padlock = new object();
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        public Monument copied;
        public Monument Copied
        {
            get
            {
                return copied;
            }
            set
            {
                if (value != copied)
                {
                    copied = value;
                    OnPropertyChanged("Copied");
                }
            }
        }
        CopyService()
        {
        }

        public static CopyService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CopyService();
                    }
                    return instance;
                }
            }
        }
    }
}
