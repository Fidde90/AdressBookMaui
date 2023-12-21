using AdressBookMaui.Pages;

namespace AdressBookMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPersonPage),typeof(AddPersonPage));
            Routing.RegisterRoute(nameof(AllPersonsPage), typeof(AllPersonsPage));
            Routing.RegisterRoute(nameof(PersonDetailsPage), typeof(PersonDetailsPage));
            Routing.RegisterRoute(nameof(EditPersonPage), typeof(EditPersonPage));
        }
    }
}
