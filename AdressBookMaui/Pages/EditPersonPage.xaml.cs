namespace AdressBookMaui.Pages;

public partial class EditPersonPage : ContentPage
{
	public EditPersonPage(EditPersonPage vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}