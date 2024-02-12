using Contacts.MAUI.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();

		// Set the ItemsSource of the listContacts to the list of contacts from the repository using an ObservableCollection
		var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

		listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		// If the item is not selected, the SelectedItem property will be null
		if (e.SelectedItem != null)
		{
			// Open the EditContactPage and pass the ContactId to the page
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }
}