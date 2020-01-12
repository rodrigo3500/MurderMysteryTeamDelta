using System.Collections.Generic;

namespace CuHackingMurder
{
    class Device 
    {
        private string device_id;
        private List<Event> events;

        public Device(string device_id){
            this.device_id = device_id;
            events = new List<Event>();
        }
        
        public void addEvent(Event ev){
            events.Add(ev);
        }

        public string getDeviceID()
        {
            return device_id;
        }

        public List<Event> GetEvents(){
            return events;
        }
    }
}