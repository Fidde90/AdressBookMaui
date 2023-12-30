using AdressBook_Library.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AdressBookMaui.ViewModels
{
    public partial class AllPersonsViewModel : ObservableObject
    {
        private readonly IPersonService _personService;


        public AllPersonsViewModel(IPersonService personService)
        {
            _personService = personService;
         

            if (_personService.GetAllPersonsFromList() != null)
                ObservablePersonList = new ObservableCollection<IPerson>(_personService.GetAllPersonsFromList())!;

            _personService.PersonListUpdated += (sender, e) =>
            {
                ObservablePersonList = new ObservableCollection<IPerson>(_personService.GetAllPersonsFromList());
            };
        }

        [ObservableProperty]
        public ObservableCollection<IPerson> _observablePersonList = [];

        [RelayCommand]
        private async Task NvigateToDetails(IPerson person)
        {
            var parameter = new ShellNavigationQueryParameters
            {
                {"Person", person }
            };

            await Shell.Current.GoToAsync("//PersonsDetailsPage", parameter);
        }

        [RelayCommand]
        private void Remove(IPerson person)
        {
            _personService.DeletePerson(person.Email);
        }
    }
}
