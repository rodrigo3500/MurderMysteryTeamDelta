using System;
using System.Linq; 
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CuHackingMurder
{
    class Parser
    {
        private List<Device> devices;
        private List<Person> people;

        public Parser(){
            devices = new List<Device>();
            people = new List<Person>();
            setUpPeople();
            LoadJson();
        }

        public void LoadJson()
        {
            String fileName = ("C:\\Users\\rodri\\source\\repos\\CuHackingMurder\\Murder-on-the-2nd-Floor-Raw-Data.json");
            String fson = File.ReadAllText(fileName);
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(fson);
            List<Action> actions = new List<Action>();

            foreach (KeyValuePair<string, object> entry in values)
            {
                String[] s = entry.Value.ToString().Trim('{').Split(',');
                String eTime = (entry.Key.Trim('{'));
                String device = (s[0].Trim().TrimStart('"', 'd', 'e', 'v', 'i', 'c', 'e', '"', ' ').Trim(':', ' ', '"').TrimEnd(' '));
                String device_id = s[1].Trim().Trim('"', 'd', 'e', 'v', 'i', 'c', 'e', '-', 'i', 'd', '"', ' ').Trim(' ', ':', '"');
                String action = s[2].Trim().Trim('"', 'e', 'v', 'e', 'n', 't', '"', ' ').Trim(' ', ':', '"');
                String guest_id = s[3].Trim().Trim('"', 'g', 'u', 'e', 's', 't', '-', 'i', 'd', '"', ' ').Trim(':', ' ', '"').TrimEnd().TrimEnd('}', '"', '\n', '\r', ' ', '"').Trim('"');

                long time = Convert.ToInt32(eTime);
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime timeF = epoch.AddSeconds(time);

                Person guest = people.Find(item=>item.getName() == guest_id);

                if (guest == null)
                {
                    guest = new Person("Unknown");
                }

                if (device == "access point")
                {
                    if (findDevice("access point", device_id) == null)
                    {
                        AccessPoint d = new AccessPoint(device_id);
                        d.addEvent(new Event(action, timeF, guest));
                        devices.Add(d);
                    }
                    else
                    {
                        Device d = findDevice("access point", device_id);
                        d.addEvent(new Event(action, timeF, guest));
                    }
                }
                else if (device == "motion sensor")
                {
                    if (findDevice("motion sensor", device_id) == null)
                    {
                        MotionSensor d = new MotionSensor(device_id);
                        d.addEvent(new Event(action, timeF, guest));
                        devices.Add(d);
                    }
                    else
                    {
                        Device d = findDevice("motion sensor", device_id);
                        d.addEvent(new Event(action, timeF, guest));
                    }
                }
                else if (device == "door sensor")
                {
                    if (findDevice("door sensor", device_id) == null)
                    {
                        DoorSensor d = new DoorSensor(device_id);
                        d.addEvent(new Event(action, timeF, guest));
                        devices.Add(d);
                    }
                    else
                    {
                        Device d = findDevice("door sensor", device_id);
                        d.addEvent(new Event(action, timeF, guest));
                    }
                }
                else if (device == "phone")
                {
                    if (findDevice("phone", device_id) == null)
                    {
                        Phone d = new Phone(device_id);
                        d.addEvent(new Event(action, timeF, guest));
                        devices.Add(d);
                    }
                    else
                    {
                        Device d = findDevice("phone", device_id);
                        d.addEvent(new Event(action, timeF, guest));
                    }
                }
            }
        }

        public Device findDevice(string device, string device_id)
        {
            foreach (Device d in devices)
            {
                if (device == "access point" && d.getDeviceID() == device_id)
                {
                    return d;
                }
                else if (device == "door sensor" && d.getDeviceID() == device_id)
                {
                    return d;
                }
                else if (device == "motion sensor" && d.getDeviceID() == device_id)
                {
                    return d;
                }
                else if (device == "phone" && d.getDeviceID() == device_id)
                {
                    return d;
                }
            }
            return null;
        }

        public void setUpPeople(){
            people.Add(new Guest("Veronica", 210));
            people.Add(new Guest("Jason", 241));
            people.Add(new Guest("Thomas", 248));
            people.Add(new Guest("Rob", 231));
            people.Add(new Guest("Kristina", 235));
            people.Add(new Staff("Marc-Andre", "Cleaning Staff"));
            people.Add(new Staff("Dave", "Cooking Staff"));
            people.Add(new Staff("Salina", "Reception Staff"));
            people.Add(new Staff("Harrison", "Reception Late-night Staff"));
        }

        public List<Device> getDevices(){
            return devices;
        }

        public List<Person> getPeople(){
            return people;
        }
    }
}