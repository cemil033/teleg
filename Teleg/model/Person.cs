using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleg.model
{
    public class Person
    {
        public string Name { get; set; }
        public string Nick { get; set; }
        public ObservableCollection<message> Messages { get; set; }
        public DateTime Time { get; set; }
        public Person()
        {
            Messages = new ObservableCollection<message>();
        }
    }
}
