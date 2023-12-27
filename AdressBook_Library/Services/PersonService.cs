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

        public IPerson GetPersonFromList(string email)
        {
            var person =_personList.FirstOrDefault(x => x.Email == email);
            if(person != null)
            {
                return person;
            }
            return null!;
        }
    }
}
