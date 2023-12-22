using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls.Primitives;
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
        public bool fail;

        [RelayCommand]
       void  AddPerson()
        {
            if (!string.IsNullOrWhiteSpace(RegistrationForm.Email))
            {
                var succeed = _personService.AddPersonToList(RegistrationForm)!;
                if (succeed)
                {
                    _personService.PersonListUpdated += async (sender, e) =>
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
                Added = !Added;
                await Task.Delay(2000);
                Added = !Added;
                RegistrationForm = new();
            }
            else
            {
                Fail = !Fail;
                await Task.Delay(2000);
                Fail = !Fail;
            }
        }
    }
}
