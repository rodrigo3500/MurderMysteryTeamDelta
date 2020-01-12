namespace CuHackingMurder
{
    /// <summary>
    /// Class for a Person
    /// </summary>
    class Person
    {
        private string name;
        /// <summary>
        /// Constructor for Person
        /// @param string name
        /// </summary>
        /// <param name="name"></param>
        public Person(string name){
            this.name = name;
        }
        //return the name of the person
        public string getName(){
            return name;
        }
    }
}