namespace Contacts.MAUI.Models
{
    // Static repository class that contains a list of contacts
    public static class ContactRepository
    {
        private static readonly List<Contact> contacts = new()
        {
            new Contact { ContactId = 1, Name = "John Doe", Email = "johndoe@gmail.com"},
            new Contact { ContactId = 2, Name = "Jane Doe", Email = "janedoe@gmail.com"},
            new Contact { ContactId = 3, Name = "Mary Smith", Email = "marysmith@gmail.com"},
            new Contact { ContactId = 4, Name = "Terry Smith", Email = "terrysmith@gmail.com"},
            new Contact { ContactId = 5, Name = "Betty Johnson", Email = "bettyjohnson@gmail.com"},
            new Contact { ContactId = 6, Name = "Vince Johnson", Email = "vincejohnson@gmail.com"},
            new Contact { ContactId = 7, Name = "David Williams", Email = "davidwilliams@gmail.com"},
            new Contact { ContactId = 8, Name = "Alice Williams", Email = "alicewilliams@gmail.com"},
            new Contact { ContactId = 9, Name = "Peggy Brown", Email = "peggybrown@gmail.com"},
            new Contact { ContactId = 10, Name = "Michael Brown", Email = "michaelbrown@gmail.com"},
            new Contact { ContactId = 11, Name = "Steven Davis", Email = "stevendavis@gmail.com"},
            new Contact { ContactId = 12, Name = "Elen Davis", Email = "elendavis@gmail.com"},
            new Contact { ContactId = 13, Name = "Linda Miller", Email = "lindamiller@gmail.com"},
            new Contact { ContactId = 14, Name = "Tom Miller", Email = "tommiller@gmail.com"}
        };
        public static List<Contact> _contacts = contacts;

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

        public static void AddContact(Contact contact)
        {
            // Get the maximum ContactId from the list and add 1 to it to get the new ContactId
            var maxId = _contacts.Max(c => c.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contactToDelete = _contacts.FirstOrDefault(c => c.ContactId == contactId);
            if (contactToDelete != null)
            {
                _contacts.Remove(contactToDelete);
            }
        }

        public static List<Contact> SearchContacts(string searchText)
        {
            var contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Name) && c.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Email) && c.Email.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Phone) && c.Phone.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(c => !string.IsNullOrWhiteSpace(c.Address) && c.Address.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return contacts;

            return contacts;
        }
    }
}
