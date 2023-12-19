using AdressBookMaui.ViewModels;

namespace AdressBookMaui.Pages
{
    public partial class PersonDetailsPage : ContentPage
    {
        public PersonDetailsPage(PersonDetailsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

