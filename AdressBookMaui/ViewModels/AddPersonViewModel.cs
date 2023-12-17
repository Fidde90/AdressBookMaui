using AdressBook_Library.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace AdressBookMaui.ViewModels
{
    public partial class AddPersonViewModel : ObservableObject
    {

        [ObservableProperty]
        private Person _registrationForm = new();

        [ObservableProperty]
        private ObservableCollection<Person> _customerList = [];
    }
}
