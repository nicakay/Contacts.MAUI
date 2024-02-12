namespace Contacts.MAUI.Views.Controls;

public partial class ContactControl : ContentView
{
    // Define the OnError event to handle errors
    public event EventHandler<string> OnError;
    // Handles the on click event for the Save button
    public event EventHandler<EventArgs> OnSave;
    // Handles the on click event for the Cancel button
    public event EventHandler<EventArgs> OnCancel;

    public ContactControl()
	{
		InitializeComponent();
	}

	public string Name
	{
		get
		{
			return entryName.Text;
		}
		set
		{
            entryName.Text = value;
        }
	}

    public string Email
    {
        get
        {
            return entryEmail.Text;
        }
        set
        {
            entryEmail.Text = value;
        }
    }

    public string Phone
    {
        get
        {
            return entryPhone.Text;
        }
        set
        {
            entryPhone.Text = value;
        }
    }

    public string Address
    {
        get
        {
            return entryAddress.Text;
        }
        set
        {
            entryAddress.Text = value;
        }
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        // Validate the entries
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required");
            return;
        }

        if (emailValidator.IsNotValid)
        {
            foreach (var error in emailValidator.Errors)
            {
                OnError?.Invoke(sender, error.ToString());
            }

            return;
        }

        // When the form is valid, invoke the OnSave event
        OnSave?.Invoke(sender, e);
    }

    private void BtnCancel_Clicked(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }
}