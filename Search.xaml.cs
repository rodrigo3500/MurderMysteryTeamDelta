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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CuHackingMurder
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search(object sender)
        {
            InitializeComponent();
            Parser p = new Parser();

            string action = "";
            string time = "";
            string device_id = "";

            foreach(Device e in p.getDevices())
            {
                foreach(Event ev in e.GetEvents())
                {
                    if(ev.getGuestID().getName() == (sender as Button).Tag.ToString())
                    {
                        action += ev.getEventName() + "\n";
                        time += ev.getEventTime() + "\n";
                        device_id += e.getDeviceID() + "\n";
                    }
                }
            }
            Action.Text = action;
            Time.Text = time;
            Location.Text = device_id;
        }
    }
}
