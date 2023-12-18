using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using AdressBook_Library.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace AdressBookMaui.ViewModels
{
    public partial class AddPersonViewModel : ObservableObject
    {
        private readonly IPersonService _personService;

        public AddPersonViewModel(IPersonService personService)
        {
            _personService = personService;
        }

        [ObservableProperty]
        private Person _registrationForm = new();

        [ObservableProperty]
        private ObservableCollection<IPerson> _observablePersonList = [];



        [RelayCommand]
        void AddPerson()
        {
            if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email))
            {
                var result = _personService.AddPersonToList(RegistrationForm)!;
                if (result)
                {
                    UpdateList();
                    RegistrationForm = new();
                }
            }
        }

        [RelayCommand]
        private void UpdateList()
        {
            ObservablePersonList.Clear();

            foreach (var person in _personService.GetAllPersonsFromList())
            {
                ObservablePersonList.Add(person);
            }

            //ObservablePersonList = new ObservableCollection<IPerson>(_personService.PersonList.Select(person => person).ToList());
        }
    }
}
