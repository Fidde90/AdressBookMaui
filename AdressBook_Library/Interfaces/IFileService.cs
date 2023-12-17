namespace AdressBook_Library.Interfaces
{
    public interface IFileService
    {
        bool WriteToFile(List<IPerson> contactList);

        string ReadFromFile();
    }
}
