namespace CuHackingMurder
{
    class Guest : Person
    {  
        private int room;
        public Guest(string name, int room) : base(name){
            this.room = room;
        }
    }
}