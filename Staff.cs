namespace CuHackingMurder
{
    class Staff : Person
    {
        private string description;
        public Staff(string name, string description) : base(name){
            this.description = description;
        }
    }
}