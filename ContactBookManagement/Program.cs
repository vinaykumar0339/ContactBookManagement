using System;
using ContactBookManagement.ContactsManager;

namespace Santhosh_Assignment
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ContactsManager contactsManager = new ContactsManager();
            contactsManager.run();
        }
    }
}
