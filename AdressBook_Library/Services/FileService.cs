using AdressBook_Library.Interfaces;

namespace AdressBook_Library.Services
{
    public class FileService : IFileService
    {
        public string ReadFromFile()
        {
            return "s";
        }

        public bool WriteToFile(List<IPerson> contactList)
        {
            return true;
        }
    }
}
