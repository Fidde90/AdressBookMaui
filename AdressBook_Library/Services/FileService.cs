using AdressBook_Library.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook_Library.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath = @"C:\ContactsCsharp\AdressBookMaui\Test.json";

        public string ReadFromFile()
        {
            return "s";
        }

        public bool WriteToFile(List<IPerson> contactList)
        {
            string list = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            });

            try
            {
                if (!string.IsNullOrEmpty(list))
                {
                    using (StreamWriter writer = new StreamWriter(_filePath))
                    {
                        writer.WriteLine(list);
                        return true;
                    }
                }
            }
            catch (Exception e) { Debug.WriteLine(e); }
            return false;
        }
    }
}
