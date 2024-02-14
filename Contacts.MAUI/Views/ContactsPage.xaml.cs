using Contacts.MAUI.Models;
using Microsoft.Maui.ApplicationModel.Communication;
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

        // Clear the search bar
        Search.Text = string.Empty;

        LoadContacts();
    }

    private async void ListContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		// If the item is not selected, the SelectedItem property will be null
		if (e.SelectedItem != null)
		{
			// Open the EditContactPage and pass the ContactId to the page
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
		}
    }

    private void ListContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }

    private void BtnAdd_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"{nameof(AddContactPage)}");
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
		// Get the MenuItem that was clicked
		var menuItem = sender as MenuItem;
		// Get the Contact that was clicked
		var contact = menuItem.CommandParameter as Contact;

        // Remove the contact from the list
        ContactRepository.DeleteContact(contact.ContactId);

        LoadContacts();
    }

	private void LoadContacts()
	{
        // Set the ItemsSource of the listContacts to the list of contacts from the repository using an ObservableCollection
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts.OrderBy(c => c.Name);
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contactsToFilter = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contactsToFilter.OrderBy(c => c.Name);
    }

}