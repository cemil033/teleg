using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;

namespace Teleg.model
{
    public class message:INotifyPropertyChanged
    {
        public HorizontalAlignment align;
        public string Message { get; set; }
        public string ImageSource { get; set; }
        public DateTime Time { get; set; }
        public HorizontalAlignment Align { get=>align; set { align = value;OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
