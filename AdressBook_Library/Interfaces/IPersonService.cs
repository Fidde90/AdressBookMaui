namespace AdressBook_Library.Interfaces
{
    public interface IPersonService
    {
        public event EventHandler? PersonListUpdated;

        bool AddPersonToList(IPerson contact);

        IEnumerable<IPerson> GetAllPersonsFromList();

        //public void GetPersonFromList(string email);

        public IPerson GetPersonFromList(string email);

        public void Edit(string email, IPerson person);

        bool DeletePerson(string email);
    }
}
