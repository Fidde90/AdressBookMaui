namespace AdressBook_Library.Interfaces
{
    public interface IPersonService
    {
        bool AddContactToList(IPerson contact);

        ICollection<IPerson> GetAllContactsFromList();

        void GetContactFromList(string email);

        bool DeleteContact(string email);

        void Deserializer();
    }
}
