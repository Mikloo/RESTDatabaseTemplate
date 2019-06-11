using Newtonsoft.Json;

namespace RESTDatabaseTemplate
{
    public class DBTemp
    {
        // Propertis og Data field
        // Mine Propertis har to auto accessors get og set som man også kan kalde read-write property
        // Get = skal returnerne
        // Set = Mener om en metod som returtype er void
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Parameterized Constructor 
        //Har ingen returtype
        //Dem der er i () hedder Arguments
        //public DBTemp(int dbTempId, string firstName, string lastName)
        //{
        //    DBTempID = dbTempId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //}

        //Tøm Constructor
        //public DBTemp() { }

        // Eksempel
        //JsonConstructor Attribute to tell that when creating objects from POST calls they need to use this.
        //[JsonConstructor]
        //public DBTemp()
        //{
        //}
    }
}
