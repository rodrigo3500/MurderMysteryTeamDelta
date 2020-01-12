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
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : Window
    {

        public PopUp(object sender)
        {
            InitializeComponent();
            Action.Text = (sender as Button).Tag.ToString();

            Parser p = new Parser();
            List<Device> devices = p.getDevices();
            string device_id = (sender as Button).Tag.ToString();
            Device d = devices[0];

            if ((sender as Button).Name.Equals("Phone"))
            {
                foreach (Device div in devices)
                {
                    if (div is Phone && div.getDeviceID() == device_id)
                    {
                        d = div;
                    }
                }
            }
            else
            {
                foreach (Device div in devices)
                {
                    if (!(div is Phone) && div.getDeviceID() == device_id)
                    {
                        d = div;
                    }
                }
            }

            try
            {
                List<Event> events = d.GetEvents();
                string action = "";
                string time = "";
                string person = "";
                foreach (Event e in events)
                {
                    Console.WriteLine((sender as Button).Name.ToString());
                    if ((sender as Button).Name.ToString().Contains("room"))
                    {
                        if (!e.getEventName().Contains("hook"))
                        {
                            action += e.getEventName() + "\n";
                            time += e.getEventTime() + "\n";
                            person += e.getGuestID().getName() + "\n";
                        }
                    }
                    if ((sender as Button).Name.ToString().Contains("phone"))
                    {
                        if (e.getEventName().Contains("hook"))
                        {
                            action += e.getEventName() + "\n";
                            time += e.getEventTime() + "\n";
                            person += e.getGuestID().getName() + "\n";
                        }
                    }
                    if ((sender as Button).Name.ToString().Contains("wifi")|| (sender as Button).Name.ToString().Contains("sensor"))
                    {
                            action += e.getEventName() + "\n";
                            time += e.getEventTime() + "\n";
                            person += e.getGuestID().getName() + "\n";
                        
                    }
                    
                }
                Action.Text = action;
                Time.Text = time;
                Person.Text = person;
            }
            catch
            {
                Action.Text = "";
                Time.Text = "";
                Person.Text = "";
                Console.WriteLine("Null Pointer Exception");
            }

        }

    }
}
