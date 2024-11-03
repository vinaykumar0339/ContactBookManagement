using System;

namespace ContactBookManagement.ContactsManager
{
    public class ContactsManager
    {

        enum MenuOptions {
            Exit = 0,
            AddContact = 1,
            ShowAllContacts = 2,
            ShowContactDetails = 3,
            UpdateContact = 4,
            DeleteContact = 5,
        }

        enum ContactMenuOptions
        {
            FirstName = 1,
            LastName = 2,
            Company = 3,
            MobileNumber = 4,
            Email = 5,
            Birthdate = 6,
        }

        ContactBook contactBook = new ContactBook();

        public ContactsManager()
        {
        }

        // ask contact information
        private string AskFirstName()
        {
            Console.WriteLine("Enter FirstName");
            string firstName = Console.ReadLine();

            if (CanStopAskingContactDetails(firstName)) return null;

            if (Validator.IsValidName(firstName))
            {
                return firstName;
            }
            else
            {
                Console.WriteLine("FirstName Should have min 5 characters");
                return AskFirstName();
            }
        }

        private string AskLastName()
        {
            Console.WriteLine("Enter LastName");
            string lastName = Console.ReadLine();

            if (CanStopAskingContactDetails(lastName)) return null;

            if (Validator.IsValidName(lastName))
            {
                return lastName;
            }
            else
            {
                Console.WriteLine("LastName Should have min 5 characters");
                return AskLastName();
            }
        }

        private string AskCompany()
        {
            Console.WriteLine("Enter Company");
            string company = Console.ReadLine();

            if (CanStopAskingContactDetails(company)) return null;

            if (!Validator.IsEmpty(company))
            {
                return company;
            }
            else
            {
                Console.WriteLine("Company Should not be empty");
                return AskCompany();
            }
        }

        private string AskMobileNumber()
        {
            Console.WriteLine("Enter Mobile Number");
            string mobileNumber = Console.ReadLine();

            if (CanStopAskingContactDetails(mobileNumber)) return null;

            if (Validator.IsValidMobileNumber(mobileNumber))
            {
                return mobileNumber;
            }
            else
            {
                Console.WriteLine("Please Enter");
                Console.WriteLine("1. 9-digit positive number as mobile number");
                Console.WriteLine("2. Mobile number should not start with zero.");
                return AskMobileNumber();
            }
        }

        private string AskEmail()
        {
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            if (CanStopAskingContactDetails(email)) return null;

            if (Validator.IsValidEmail(email))
            {
                return email;
            }
            else
            {
                Console.WriteLine("Please Enter Valid Email ID.");
                return AskEmail();
            }
        }

        private string AskBirthDate()
        {
            Console.WriteLine("Enter Birth Date in the format (d MMM yyy) ex: (1 Jan 1990)");
            string birthday = Console.ReadLine();

            if (CanStopAskingContactDetails(birthday)) return null;

            if (Validator.TryAddBirthdate(birthday, out DateTime birthdate))
            {
                return birthdate.ToShortDateString();
            }
            else
            {
                Console.WriteLine("Please Enter Valid Birth Date in the Format (d MMM yyy) ex: (1 Jan 1990)");
                return AskBirthDate();
            }
        }

        // end of contact information gathering

        // menu actions
        private void PrintDivider()
        {
            Console.WriteLine("====================================================================================================");
        }


        private void PrintMainMenuOptions()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Show All Contacts");
            Console.WriteLine("3: Show Contact Details");
            Console.WriteLine("4: Update Contact");
            Console.WriteLine("5: Delete Contact");
            Console.WriteLine("0: Exit");
        }

        private void PrintContactBookProperties()
        {
            Console.WriteLine("1: Change FirstName");
            Console.WriteLine("2: Change LastName");
            Console.WriteLine("3: Change Company");
            Console.WriteLine("4: Change Mobile Number");
            Console.WriteLine("5: Change Email");
            Console.WriteLine("6: Change Birthdate");
            Console.WriteLine("Enter Exit or exit to cancel changes");
            Console.WriteLine("Enter Done or done to accept changes");
        }

        private void ShowAllContactsAction()
        {
            Console.WriteLine();
            Console.Write("All Contacts: ");
            if (!contactBook.IsContactsEmpty())
            {
                Console.WriteLine(contactBook.GetTotalBooksCount());
                Console.WriteLine(contactBook);
            } else
            {
                Console.WriteLine("No Contacts");
            }

            PrintDivider();
        }

        private bool CanStopAskingContactDetails(string input)
        {
            return input == "Exit" || input == "exit";
        }

        private void AddContactAction()
        {
            Console.WriteLine("Please fill the below details to add a Contact (Enter Exit/exit to stop the current action): ");
            Contact contact = new();
            if (AskContactQuestions(contact))
            {
                contactBook.AddContact(contact);
            }

            PrintDivider();

        }

        private void ShowContactDetailsAction() {
            // ask id which one to show details
            Console.Write("Enter Contact Id To See the Contact Details (Enter Exit/exit to stop the current action): ");
            string input = Console.ReadLine();
            if (CanStopAskingContactDetails(input))
            {
                PrintDivider();
                return;
            }

            if (contactBook.IsContactExists(input))
            {
                Console.WriteLine();
                Console.WriteLine(contactBook.GetContact(input));
                PrintDivider();
            }
            else
            {
                Console.WriteLine($"Contact Doesn't Exists in the records with the id: {input}");
                Console.WriteLine();
                // Ask id again to delete the contact
                ShowContactDetailsAction();
            }
        }

        private bool AskContactQuestions(Contact contact)
        {

            string firstName = AskFirstName();
            if (firstName == null) return false;

            string lastName = AskLastName();
            if (lastName == null) return false;

            string company = AskCompany();
            if (company == null) return false;

            string mobileNumber = AskMobileNumber();
            if (mobileNumber == null) return false;

            string email = AskEmail();
            if (email == null) return false;

            string birthdate = AskBirthDate();
            if (birthdate == null) return false;

            contact.SetFirstName(firstName);
            contact.SetLastName(lastName);
            contact.SetCompany(company);
            contact.SetMobileNumber(mobileNumber);
            contact.SetEmail(email);
            contact.SetBirthdate(birthdate);

            return true;
        }

        private bool DoneUpdatingContact(string input)
        {
            return input == "Done" || input == "done";
        }

        private bool AskUpdateQuestions(Contact contact)
        {
            PrintContactBookProperties();

            Console.Write("Enter Valid Number To Change Contact Details: ");
            string input = Console.ReadLine();

            if (CanStopAskingContactDetails(input)) return false;

            if (DoneUpdatingContact(input)) return true;

            // Try to parse the input to an integer
            if (int.TryParse(input, out int contactMenuOption) && Enum.IsDefined(typeof(ContactMenuOptions), contactMenuOption))
            {
                switch ((ContactMenuOptions) contactMenuOption)
                {
                    case ContactMenuOptions.FirstName:
                        string firstName = AskFirstName();
                        if (firstName != null)
                        {
                            contact.SetFirstName(firstName);
                        }
                        break;
                    case ContactMenuOptions.LastName:
                        string lastName = AskLastName();
                        if (lastName != null)
                        {
                            contact.SetLastName(lastName);
                        }
                        break;
                    case ContactMenuOptions.Company:
                        string company = AskCompany();
                        if (company != null)
                        {
                            contact.SetCompany(company);
                        }
                        break;
                    case ContactMenuOptions.MobileNumber:
                        string mobileNumber = AskMobileNumber();
                        if (mobileNumber != null)
                        {
                            contact.SetMobileNumber(mobileNumber);
                        }
                        break;
                    case ContactMenuOptions.Email:
                        string email = AskEmail();
                        if (email != null)
                        {
                            contact.SetEmail(email);
                        }
                        break;
                    case ContactMenuOptions.Birthdate:
                        string birthday = AskBirthDate();
                        if (birthday != null)
                        {
                            contact.SetBirthdate(birthday);
                        }
                        break;
                }
                return AskUpdateQuestions(contact);

            }
            else
            {
                // If invalid, prompt again
                Console.WriteLine("Invalid input. Please Choose Valid Update Contact Option");
                return AskUpdateQuestions(contact);
            }
        }

        private void UpdateContactAction() {
            // ask id which one to show details
            Console.Write("Enter Contact Id To Update the Contact Details (Enter Exit/exit to stop the current action): ");
            string input = Console.ReadLine();
            if (CanStopAskingContactDetails(input))
            {
                PrintDivider();
                return;
            }

            if (contactBook.IsContactExists(input))
            {
                Console.WriteLine();
                Contact contact = new Contact();
                contact.ResetContactWith(contactBook.GetContact(input));
                if (AskUpdateQuestions(contact))
                {
                    contactBook.UpdateContactById(contact, input);
                }
                PrintDivider();
            }
            else
            {
                Console.WriteLine($"Contact Doesn't Exists in the records with the id: {input}");
                Console.WriteLine();
                // Ask id again to delete the contact
                UpdateContactAction();
            }
        }

        private void DeleteContactAction()
        {
            // ask id which one to remove
            Console.Write("Enter Contact Id To Delete (Enter Exit/exit to stop the current action): ");
            string input = Console.ReadLine();
            if (CanStopAskingContactDetails(input))
            {
                PrintDivider();
                return;
            }

            if (contactBook.IsContactExists(input))
            {
                contactBook.DeleteContactById(input);
                Console.WriteLine();
                Console.WriteLine($"Contact With Id {input} is deleted successfully");
                PrintDivider();
            } else
            {
                Console.WriteLine($"Contact Doesn't Exists in the records with the id: {input}");
                Console.WriteLine();
                // Ask id again to delete the contact
                DeleteContactAction();
            }
        }

        private void Exit()
        {
            Console.WriteLine("Closing The Application....");
            Environment.Exit(0);
        }

        // end of menu actions

        private void ExecuteMenuOptions(MenuOptions menuOption) {
            switch(menuOption)
            {
                case MenuOptions.Exit:
                    Exit();
                    break;
                case MenuOptions.AddContact:
                    AddContactAction();
                    break;
                case MenuOptions.ShowAllContacts:
                    ShowAllContactsAction();
                    break;
                case MenuOptions.ShowContactDetails:
                    ShowContactDetailsAction();
                    break;
                case MenuOptions.UpdateContact:
                    UpdateContactAction();
                    break;
                case MenuOptions.DeleteContact:
                    DeleteContactAction();
                    break;
            }

            if (menuOption != MenuOptions.Exit)
            {
                // Run MainMenu Options Again
                AskMainMenuOption();
            }
        }

        private void AskMainMenuOption() {

            PrintMainMenuOptions();

            // Read the Number
            bool isValidMenuOption = false;
            while (!isValidMenuOption)
            {
                Console.Write("Please Choose a Menu Options: ");
                string input = Console.ReadLine();

                // Try to parse the input to an integer
                if (int.TryParse(input, out int menuOption) && Enum.IsDefined(typeof(MenuOptions), menuOption))
                {
                    // If valid, break out of the loop
                    isValidMenuOption = true;
                    PrintDivider();
                    ExecuteMenuOptions((MenuOptions) menuOption);
                }
                else
                {
                    // If invalid, prompt again
                    isValidMenuOption = false;
                    Console.WriteLine("Invalid input. Please Choose Valid Menu Option");
                }
            }
        }

        public void run() {
            AskMainMenuOption();
        }
    }
}
