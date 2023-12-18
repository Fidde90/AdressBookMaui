using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AdressBook_Library.Services
{
    public class PersonService : IPersonService
    {
        public PersonService(IFileService fileservice)
        {
            _fileservice = fileservice;
        }
        private readonly IFileService _fileservice;

        private List<IPerson> _personList = new List<IPerson>();

        public event EventHandler? PersonListUpdated;


        public bool AddPersonToList(IPerson person)
        {           
            try
            {
                if (!string.IsNullOrWhiteSpace(person.Email))
                {
                    _personList.Add(person);
                    _fileservice.WriteToFile(_personList);
                    PersonListUpdated?.Invoke(this, EventArgs.Empty); // använd varje gång man gör något med listan
                    return true;

                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
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
            try
            {
                var JsonizedList = _fileservice.ReadFromFile();

                if (!string.IsNullOrEmpty(JsonizedList))
                {
                    _personList = JsonConvert.DeserializeObject<List<IPerson>>(JsonizedList, new JsonSerializerSettings
                    { TypeNameHandling = TypeNameHandling.Auto })!;

                    //PersonListUpdated?.Invoke(this, EventArgs.Empty);
                    return _personList;
                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
            return null!;

        }

        public void GetPersonFromList(string email)
        {

        }
    }
}
