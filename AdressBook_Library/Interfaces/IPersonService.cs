﻿using AdressBook_Library.Models;

namespace AdressBook_Library.Interfaces
{
    public interface IPersonService
    {
        public event EventHandler? PersonListUpdated;

        bool AddPersonToList(IPerson contact);

        IEnumerable<IPerson> GetAllPersonsFromList();

        IPerson GetPersonFromList(string email);

        public void Edit(string email, IPerson person);

        bool DeletePerson(string email);
    }
}
