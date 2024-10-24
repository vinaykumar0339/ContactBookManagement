using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookManagement.ContactsManager
{
    public class ContactBook
    {
        private List<Contact> contacts;

        public ContactBook()
        {
            contacts = Contact.GetDBContacts();
        }

        public bool IsContactsEmpty() {
            return contacts.Count == 0;
        }

        public int GetTotalBooksCount()
        {
            return contacts.Count;
        }

        public void AddContact(Contact contact) {
            contacts.Add(contact);
        }

        public Contact GetContact(string id)
        {
            return contacts.Find(con => con.GetID() == id);
        }

        public void DeleteContactById(string id)
        {
            contacts.RemoveAll(con => con.GetID() == id);
        }

        public bool IsContactExists(string id)
        {
            return contacts.Exists(con => con.GetID() == id);
        }

        public void UpdateContactById(Contact contact, string id) {
            Contact updateContact = contacts.Find(con => con.GetID() == id);
            if (updateContact != null)
            {
                updateContact.ResetContactWith(contact);
            }
            else {
                Console.WriteLine("Contact not found to Update the Contact");
            }
        }

        public string GetOverviewContact()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Contact contact in contacts)
            {
                sb.Append(contact.GetOverviewContact());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Contact contact in contacts) {
                sb.Append(contact.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
