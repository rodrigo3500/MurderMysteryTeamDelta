using System.Collections.Generic;

namespace CuHackingMurder
{
    class AccessPoint : Device
    {  
        public AccessPoint(string device_id) : base(device_id){
        }

        public override string ToString(){
            string info = "";
            var events = GetEvents();
            foreach(Event e in events){
                info = info + "Person: " + e.getGuestID().getName() + "\n Event: " + e.getEventName()
                + "\n Time: " + e.getEventTime() + "\n";  
            }
            return info;
        }
    }
}