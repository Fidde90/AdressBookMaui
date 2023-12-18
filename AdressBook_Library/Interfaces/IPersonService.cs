﻿using AdressBook_Library.Models;

namespace AdressBook_Library.Interfaces
{
    public interface IPersonService
    {
        //List<IPerson> PersonList { get; set; }

        bool AddPersonToList(IPerson contact);

        IEnumerable<IPerson> GetAllPersonsFromList();

        void GetPersonFromList(string email);

        bool DeletePerson(string email);

        void Deserializer();
    }
}
