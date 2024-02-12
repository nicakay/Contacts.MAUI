using Contacts.MAUI.Models;
using Contact = Contacts.MAUI.Models.Contact;

namespace Contacts.MAUI.Views;

// Whenever we receive a query from the ContactsPage, we will map "Id" to the ContactId property to get the contact from the repository
 [QueryProperty(nameof(ContactId), "Id")]

public partial class EditContactPage : ContentPage
{
	private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

	// If the Cancel button is clicked, the app will navigate back to the previous page
    private void BtnCancel_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"..");
    }

	public string ContactId
	{
		set
		{
			// Get the contact from the repository and store it in the private variable contact
			contact = ContactRepository.GetContactById(int.Parse(value));

			// If the contact is not null, assign the values of the contact to the entry fields
			if (contact != null)
			{
                entryName.Text = contact.Name;
				entryEmail.Text = contact.Email;
				entryPhone.Text = contact.Phone;
				entryAddress.Text = contact.Address;
            }
		}
	}

    private void BtnUpdate_Clicked(object sender, EventArgs e)
    {
		contact.Name = entryName.Text;
		contact.Email = entryEmail.Text;
		contact.Phone = entryPhone.Text;
		contact.Address = entryAddress.Text;

		// Update the contact in the repository
		ContactRepository.UpdateContact(contact.ContactId, contact);

		// Navigate back to the previous page
        Shell.Current.GoToAsync($"..");
    }
}