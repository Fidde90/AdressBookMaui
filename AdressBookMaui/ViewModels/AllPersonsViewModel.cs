using AdressBook_Library.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace AdressBookMaui.ViewModels
{
    public partial class AllPersonsViewModel : ObservableObject
    {
        private readonly IPersonService _personService;

        public AllPersonsViewModel(IPersonService personService)
        {
            _personService = personService;

            if(_personService.GetAllPersonsFromList() != null)
                    ObservablePersonList = new ObservableCollection<IPerson>(_personService.GetAllPersonsFromList())!;//This fix

            _personService.PersonListUpdated += (sender, e) =>
            {
                ObservablePersonList = new ObservableCollection<IPerson>(_personService.GetAllPersonsFromList());
            };
        }

        [ObservableProperty]
        private ObservableCollection<IPerson> _observablePersonList = [];

    }
}
