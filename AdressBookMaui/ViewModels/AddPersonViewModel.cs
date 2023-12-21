using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AdressBookMaui.ViewModels
{
    public partial class AddPersonViewModel : ObservableObject
    {
        private readonly IPersonService _personService;
        private readonly AllPersonsViewModel _allPersonsViewModel;

        public AddPersonViewModel(IPersonService personService, AllPersonsViewModel allPersonsViewModel)
        {
            _allPersonsViewModel = allPersonsViewModel;
            _personService = personService;
        }

        [ObservableProperty]
        private Person _registrationForm = new();

        [RelayCommand]
        void AddPerson()
        {
            if (!string.IsNullOrWhiteSpace(RegistrationForm.Email))
            {
                var succeed = _personService.AddPersonToList(RegistrationForm)!;
                if (succeed)
                {
                    _personService.PersonListUpdated += (sender, e) =>
                    {
                       _allPersonsViewModel.ObservablePersonList = new ObservableCollection<IPerson>(_personService.GetAllPersonsFromList());
                    };
                    RegistrationForm = new();
                }
            }
        }
    }
}
