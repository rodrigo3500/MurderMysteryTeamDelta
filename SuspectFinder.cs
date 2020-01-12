using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuHackingMurder
{
    class SuspectFinder
    {
        private DateTime murderTime = new DateTime(2019, 11, 20, 10, 00, 00);
        private Parser parsed;
        Dictionary<string, DateTime> people;

        public SuspectFinder()
        {
            people = new Dictionary<string, DateTime>();
            parsed = new Parser();
            // nearRoom = new List<Person>();
            people.Add("Veronica", new DateTime());
            people.Add("Jason", new DateTime());
            people.Add("Thomas", new DateTime());
            people.Add("Rob", new DateTime());
            people.Add("Kristina", new DateTime());
            people.Add("Marc-Andre", new DateTime());
            people.Add("Dave", new DateTime());
            people.Add("Salina", new DateTime());
            people.Add("Harrison", new DateTime());
            hasBeenNearRoom();
            predictMurderer();
        }

        public string predictMurderer()
        {
            Dictionary<string, DateTime> suspects = new Dictionary<string, DateTime>();
            foreach (KeyValuePair<string, DateTime> entry in people)
            {

                if (entry.Value.TimeOfDay < murderTime.TimeOfDay)
                {
                    suspects.Add(entry.Key, entry.Value);
                }
            }
            foreach (KeyValuePair<string, DateTime> entry in suspects)
            {
                var sortedDict = from e in suspects orderby entry.Value ascending select entry;
            }
            return suspects.First().Key;
        }

        public void hasBeenNearRoom()
        {
            foreach (Device d in parsed.getDevices())
            {
                if (d.getDeviceID() == "210")
                {
                    foreach (Event e in d.GetEvents())
                    {
                        people[e.getGuestID().getName()] = e.getEventTime();
                    }
                }
            }

        }

    }
}
