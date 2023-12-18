using AdressBook_Library.Models;

namespace AdressBook_Library.Interfaces
{
    public interface IPersonService
    {
        public event EventHandler? PersonListUpdated;

        bool AddPersonToList(IPerson contact);

        IEnumerable<IPerson> GetAllPersonsFromList();

        void GetPersonFromList(string email);

        bool DeletePerson(string email);

        void Deserializer();
    }
}
