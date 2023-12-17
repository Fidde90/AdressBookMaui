using AdressBookMaui.Pages;

namespace AdressBookMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPersonPage),typeof(AddPersonPage));
        }
    }
}
