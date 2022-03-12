using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

using Teleg.model;

namespace Teleg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        
        private ObservableCollection<message> message1 = new ObservableCollection<message>();
        public ObservableCollection<message> Message1 { get => message1; set { message1 =value; OnPropertyChanged(); } }
        public ObservableCollection<Person> people { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>()
            {
            new Person(){
                Name ="Cemil Ibra",
                Nick="CI",
                Time=DateTime.Now,                
            },
            new Person(){
                Name ="Kamil Ibra",
                Nick="KI",
                Time=DateTime.Now,                
            }
            };
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void listpeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listpeople.SelectedItem != null)
            {
                message1.Clear();
                foreach (var item in (listpeople.SelectedItem as Person).Messages)
                {
                    message1.Add(new message() { Message = (item as message).Message, ImageSource = (item as message).ImageSource, Time = (item as message).Time, Align = (item as message).Align });
                }
                pname.Text = (listpeople.SelectedItem as Person).Name;
                pstatus.Text = "online";
            }
        }
        public string source2="";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            message1.Add(new message() { Message = msgtext.Text, Align = HorizontalAlignment.Right, ImageSource = source2, Time = DateTime.Now });           
            message1.Add(new message() { Message = "Indi meshqulam daha sonra yazacam.", Align = HorizontalAlignment.Left, ImageSource = "", Time = DateTime.Now });
            (listpeople.SelectedItem as Person).Messages.Add(new message() { Message = msgtext.Text, Align = HorizontalAlignment.Right, ImageSource = source2, Time = DateTime.Now });
            (listpeople.SelectedItem as Person).Messages.Add(new message() { Message = "Indi meshqulam daha sonra yazacam.", Align = HorizontalAlignment.Left, ImageSource = "", Time = DateTime.Now });
            msgtext.Text = "";
            source2 = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                source2 = op.FileName;
            }
        }
    }
    
}
