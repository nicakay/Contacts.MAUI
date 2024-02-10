namespace Contacts.MAUI.Views;

public partial class EditContactPage : ContentPage
{
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"..");
    }
}