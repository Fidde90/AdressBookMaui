using AdressBookMaui.ViewModels;

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
