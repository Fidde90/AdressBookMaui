using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;

namespace AdressBook_Library.Services
{
    public class PersonService : IPersonService
    {
        public PersonService(IFileService fileservice)
        {
            _fileservice = fileservice;
        }
        private readonly IFileService _fileservice;

        private readonly List<IPerson> _personList = new List<IPerson>();

        public event EventHandler? PersonListUpdated;


        public bool AddPersonToList(IPerson person)
        {
            if (!string.IsNullOrWhiteSpace(person.Email))
            {
                _personList.Add(person);
                _fileservice.WriteToFile(_personList);
                PersonListUpdated?.Invoke(this, EventArgs.Empty); // använd varje gång man gör något med listan
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
