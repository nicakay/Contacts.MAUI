namespace Contacts.MAUI.Models
{
    // Static repository class that contains a list of contacts
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new()
        {
            new Contact { ContactId = 1, Name = "John Doe", Email = "johndoe@gmail.com"},
            new Contact { ContactId = 2, Name = "Jane Doe", Email = "janedoe@gmail.com"},
            new Contact { ContactId = 3, Name = "John Smith", Email = "johnsmith@gmail.com"},
            new Contact { ContactId = 4, Name = "Jane Smith", Email = "janesmith@gmail.com"},
            new Contact { ContactId = 5, Name = "John Johnson", Email = "johnjohnson@gmail.com"},
            new Contact { ContactId = 6, Name = "Jane Johnson", Email = "janejohnson@gmail.com"},
            new Contact { ContactId = 7, Name = "John Williams", Email = "johnwilliams@gmail.com"},
            new Contact { ContactId = 8, Name = "Jane Williams", Email = "janewilliams@gmail.com"},
            new Contact { ContactId = 9, Name = "John Brown", Email = "johnbrown@gmail.com"},
            new Contact { ContactId = 10, Name = "Jane Brown", Email = "janebrown@gmail.com"},
            new Contact { ContactId = 11, Name = "John Davis", Email = "johndavis@gmail.com"},
            new Contact { ContactId = 12, Name = "Jane Davis", Email = "janedavis@gmail.com"}
        };

        public static List<Contact> GetContacts()
        {
            return _contacts;
        }

        public static Contact GetContactById(int id)
        {
            // Returns the first contact in the list that has the same ContactId as the id parameter
            var contact = _contacts.FirstOrDefault(c => c.ContactId == id);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }
        }
    }
}
