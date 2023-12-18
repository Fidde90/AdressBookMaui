using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;

namespace AdressBook_Library.Services
{
    public class PersonService : IPersonService
    {
        private readonly List<IPerson> _personList = new List<IPerson>();

        public bool AddPersonToList(IPerson person)
        {
            if (!string.IsNullOrWhiteSpace(person.Email))
            {
                _personList.Add(person);
                return true;
            }
            return false;
        }

        public bool DeletePerson(string email)
        {
            return true;
        }

        public void Deserializer()
        {

        }

        public IEnumerable<IPerson> GetAllPersonsFromList()
        {
            return _personList;
        }

        public void GetPersonFromList(string email)
        {

        }      
    }
}
