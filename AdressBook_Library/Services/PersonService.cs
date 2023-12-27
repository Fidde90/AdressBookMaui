using AdressBook_Library.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook_Library.Services
{
    public class PersonService : IPersonService
    {
        public PersonService(IFileService fileservice)
        {
            _fileService = fileservice;
        }
        private readonly IFileService _fileService;

        private List<IPerson> _personList = new List<IPerson>();

        public event EventHandler? PersonListUpdated;


        public void Edit(string email, IPerson person)
        {
            for (int i = 0; i < _personList.Count; i++)
            {
                if (_personList[i].Email == email)
                {
                    _personList[i] = person;
                    _fileService.WriteToFile(_personList);
                    PersonListUpdated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Adds a contact to the list.
        /// </summary>
        /// <param name="contact">IContact</param>
        /// <returns>true if the contact's email does not match anyone else's in the list, otherwise false</returns>
        public bool AddPersonToList(IPerson person)
        {           
            try
            {
                if(person != null)
                {
                    if (!_personList.Any(p => p.Email == person.Email))
                    {
                        _personList.Add(person);
                        _fileService.WriteToFile(_personList);
                        PersonListUpdated?.Invoke(this, EventArgs.Empty); // använd varje gång man gör något med listan
                        return true;
                    }
                }          
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
            return false;
        }

        /// <summary>
        /// Checks if the contact excists via its email and delete him/her from the list.
        /// Then the file on the computer gets updated with the modified list.
        /// </summary>
        /// <param name="email">the eamil value(string) of the contact</param>
        /// <returns>true om the contact was deleted, false if the contact dosent excist</returns>
        public bool DeletePerson(string email)
        {
            for (int i = 0; i < _personList.Count; i++)
            {
                if (_personList[i].Email == email)
                {
                    _personList.RemoveAt(i);        
                    _fileService.WriteToFile(_personList);
                    PersonListUpdated?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the list contains any values.
        /// </summary>
        /// <returns>returns the list of contacts if true, else null</returns>
        public IEnumerable<IPerson> GetAllPersonsFromList()
        {
            try
            {
                var JsonizedList = _fileService.ReadFromFile();

                if (!string.IsNullOrEmpty(JsonizedList))
                {
                    _personList = JsonConvert.DeserializeObject<List<IPerson>>(JsonizedList, new JsonSerializerSettings
                    { TypeNameHandling = TypeNameHandling.Auto })!;
                    return _personList;
                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
            return null!;
        }

        /// <summary>
        /// Shows all information of the chosen contact.
        /// </summary>
        /// <param name="email">the email value of the contact(string)</param>
        //public void GetPersonFromList(string email)
        //{
        //    Console.Clear();
        //    for (int i = 0; i < _personList.Count; i++)
        //    {
        //        if (_personList[i].Email == email)
        //        {
        //            Console.ForegroundColor = ConsoleColor.White;
        //            Console.WriteLine("\n------------------------------------------------------------------------------------");
        //            Console.WriteLine($"\t{_personList[i].FirstName} {_personList[i].LastName}");
        //            Console.WriteLine($"\t{_personList[i].Email}, {_personList[i].PhoneNumber}");
        //            Console.WriteLine($"\t{_personList[i].Street}, {_personList[i].ZipCode}");
        //            Console.WriteLine($"\t{_personList[i].City}, {_personList[i].Country}");
        //            Console.WriteLine("------------------------------------------------------------------------------------");
        //        }
        //    }
        //}

        public IPerson GetPersonFromList(string email)
        {
            var person = _personList.FirstOrDefault(x => x.Email == email);
            if (person != null)
            {
                return person;
            }
            return null!;
        }
    }
}
