using AdressBookMaui.ViewModels;

namespace AdressBookMaui.Pages
{
    public partial class AllPersonsPage : ContentPage
    {
        public AllPersonsPage(AllPersonsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
