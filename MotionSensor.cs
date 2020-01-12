
namespace CuHackingMurder
{
    class MotionSensor : Device
    {  
        public MotionSensor(string device_id) : base(device_id){
        }
        
        public override string ToString(){
            string info = "";
            var events = GetEvents();
            foreach(Event e in events){
                info = info + "Event: " + e.getEventName()
                + "\n Time: " + e.getEventTime() + "\n\n";  
            }
            return info;
        }


    }
}