namespace AdressBook_Library.Interfaces
{
    public interface IContact
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string PhoneNumber { get; set; }

        string Email { get; set; }

        string Street { get; set; }

        string ZipCode { get; set; }

        string City { get; set; }

        string Country { get; set; }
    }
}
