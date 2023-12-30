using AdressBookMaui.ViewModels;

namespace AdressBookMaui.Pages
{
    public partial class AddPersonPage : ContentPage
    {
        public AddPersonPage(AddPersonViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

