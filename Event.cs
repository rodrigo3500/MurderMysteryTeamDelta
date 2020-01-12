using System;

namespace CuHackingMurder
{
    class Event{
        private string eventName;
        private Person guest_id;
        private DateTime eventDate;

        public Event(string eventName, DateTime eventDate, Person guest_id){
            this.eventName = eventName;
            this.eventDate = eventDate;
            this.guest_id = guest_id;
        }

        public string getEventName(){
            return eventName;
        }

        public Person getGuestID(){
            return guest_id;
        }

        public DateTime getEventTime(){
            return eventDate;
        }
    } 
}