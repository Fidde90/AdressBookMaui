using AdressBook_Library.Interfaces;

namespace AdressBook_Library.Services
{
    public class PersonService : IPersonService
    {
        public bool AddContactToList(IPerson contact)
        {
            throw new NotImplementedException();
        }

        public bool DeleteContact(string email)
        {
            throw new NotImplementedException();
        }

        public void Deserializer()
        {
            throw new NotImplementedException();
        }

        public ICollection<IPerson> GetAllContactsFromList()
        {
            throw new NotImplementedException();
        }

        public void GetContactFromList(string email)
        {
            throw new NotImplementedException();
        }
    }
}
