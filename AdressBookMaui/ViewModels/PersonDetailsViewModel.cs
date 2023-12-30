using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AdressBookMaui.ViewModels
{
    public partial class PersonDetailsViewModel : ObservableObject, IQueryAttributable
    {
        private readonly IPersonService _personService;

        public PersonDetailsViewModel(IPersonService personService)
        {
            _personService = personService;
        }

        [ObservableProperty]
        private Person person = new();

        [ObservableProperty]
        bool isStackVisible;


        /// <summary>
        /// Hides the edit options and saves the new values to a person.
        /// </summary>
        [RelayCommand]
        public void SaveBtn()
        {
            IsStackVisible = !IsStackVisible;

            _personService.Edit(Person.Email, Person);
            var editedPerson = _personService.GetPersonFromList(Person.Email);

            Person = (Person)editedPerson;
        }

        [RelayCommand]
        public void EditBtn()
        {
            IsStackVisible = !IsStackVisible;
        }

        [RelayCommand]
        private async Task BackToAllPersons()
        {
            await Shell.Current.GoToAsync("//AllPersonsPage");
        }

        [RelayCommand]
        private async Task BackToAddPerson()
        {
            await Shell.Current.GoToAsync("//AddPersonPage");           
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            IsStackVisible = false;
            Person = (query["Person"] as Person)!;
        }
    }
}
