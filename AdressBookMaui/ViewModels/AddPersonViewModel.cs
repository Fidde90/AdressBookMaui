﻿using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

        [RelayCommand]
        void AddPerson()
        {
            if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email))
            {
                var result = _personService.AddPersonToList(RegistrationForm)!;
                if (result)
                {
                    RegistrationForm = new();
                }
            }
        }
    }
}
