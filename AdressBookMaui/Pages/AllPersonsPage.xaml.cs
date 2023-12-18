using AdressBook_Library.Interfaces;
using AdressBookMaui.ViewModels;
using System.Collections.ObjectModel;

namespace AdressBookMaui.Pages
{
    public partial class AllPersonsPage : ContentPage
    {
        public AllPersonsPage(AllPersonsViewModel allPersonsViewModel)
        {
            InitializeComponent();
            BindingContext = allPersonsViewModel;
        }
    }
}
