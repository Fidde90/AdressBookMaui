using AdressBook_Library.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AdressBook_Library.Services
{
    public class FileService : IFileService
    {
        private readonly string _filePath = @"C:\ContactsCsharp\AdressBookMaui\Test.json";
        //private readonly string _filePath;

        //public FileService(string filePath)
        //{
        //    _filePath = filePath;
        //}

        public string ReadFromFile()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
            return null ?? "";
        }

        public bool WriteToFile(List<IPerson> contactList)
        {
            try
            {
                string JsonizedList = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto
                });

                if (!string.IsNullOrEmpty(JsonizedList))
                {
                    using (StreamWriter writer = new StreamWriter(_filePath))
                    {
                        writer.WriteLine(JsonizedList);
                        return true;
                    }
                }
            }
            catch (Exception e) { Debug.WriteLine(e.Message); }
            return false;
        }
    }
}
