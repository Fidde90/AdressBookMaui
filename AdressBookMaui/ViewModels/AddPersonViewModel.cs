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

        [ObservableProperty]
        public bool added;

        [ObservableProperty]
        public string? eventText;

        [ObservableProperty]
        public string? alertColor;

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

                    _ = TrueOrFalse(true);
                }
                else
                    _ = TrueOrFalse(false);
            }
        }

        async Task TrueOrFalse(bool trueOrFalse)
        {
            if (trueOrFalse)
            {
                EventText = "Contact added successfully";
                AlertColor = "DarkSlateGrey";
                Added = !Added;
                await Task.Delay(2000);
                Added = !Added;
            }
            else
            {
                AlertColor = "IndianRed";
                EventText = "Either the contact already exists or something else went wrong";
                Added = !Added;
                await Task.Delay(3000);
                Added = !Added;
            }
        }
    }
}
