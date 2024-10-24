using System;
using System.Collections.Generic;

namespace ContactBookManagement.ContactsManager
{
    public class Contact
    {
        private string id;
        private string firstName;
        private string lastName;
        private string company;
        private string mobileNumber;
        private string email;
        private string birthdate;

        public static List<Contact> GetDBContacts()
        {
            return [
                new Contact("f499c93c-c7df-48c0-87b6-ffdadb1942a5", "Sophia", "McGrath", "Dublin Business School", "0871111111", "sophia.mcgr@dbs.ie", "1 Jan 1990"),
                new Contact("593cdac0-33ee-41e1-ae14-23cc3c122b23", "Liam", "O'Sullivan", "Dublin Business School", "0871111112", "liam.osullivan@dbs.ie", "2 Feb 1991"),
                new Contact("5e49a887-6bc3-4cd6-bafc-8d8f4689379c", "Emma", "Walsh", "Dublin Business School", "0871111113", "emma.walsh@dbs.ie", "3 Mar 1992"),
                new Contact("40bd3980-bed7-41ed-9ddb-2d43111718a3", "Noah", "Kelly", "Dublin Business School", "0871111114", "noah.kelly@dbs.ie", "4 Apr 1993"),
                new Contact("ec36112b-aa2b-42c4-a96d-a5f54da39914", "Olivia", "Murphy", "Dublin Business School", "0871111115", "olivia.murphy@dbs.ie", "5 May 1994"),
                new Contact("3ae3eea6-267b-4de1-8615-7a7e88a25b29", "James", "Smith", "Dublin Business School", "0871111116", "james.smith@dbs.ie", "6 Jun 1995"),
                new Contact("0e2824d7-1c7f-47fc-a6c9-ae444bde9abf", "Ava", "Johnson", "Dublin Business School", "0871111117", "ava.johnson@dbs.ie", "7 Jul 1996"),
                new Contact("f1c89406-79e7-4f07-9ed1-531c4a3d392d", "Logan", "Brown", "Dublin Business School", "0871111118", "logan.brown@dbs.ie", "8 Aug 1997"),
                new Contact("2473db34-58dd-4aa4-b46b-91b7a9faf907", "Mia", "Jones", "Dublin Business School", "0871111119", "mia.jones@dbs.ie", "9 Sep 1998"),
                new Contact("9e94308e-edc7-40cc-8e31-42b14bb13eff", "Lucas", "Davis", "Dublin Business School", "0871111120", "lucas.davis@dbs.ie", "10 Oct 1999"),
                new Contact("28309647-25ca-4b19-98a7-4ebd7b024686", "Isabella", "Garcia", "Dublin Business School", "0871111121", "isabella.garcia@dbs.ie", "11 Nov 2000"),
                new Contact("8e57d7b0-de61-4f1a-9762-a171c468d653", "Ethan", "Martinez", "Dublin Business School", "0871111122", "ethan.martinez@dbs.ie", "12 Dec 2001"),
                new Contact("e8f32043-ba94-4420-9593-2260b5620f4b", "Sophia", "Lopez", "Dublin Business School", "0871111123", "sophia.lopez@dbs.ie", "13 Jan 2002"),
                new Contact("bc022149-27c2-43e2-b135-88b3e9039d73", "Aiden", "Wilson", "Dublin Business School", "0871111124", "aiden.wilson@dbs.ie", "14 Feb 2003"),
                new Contact("dd5964ca-d3f8-46e9-9180-dcdefa80de2f", "Charlotte", "Anderson", "Dublin Business School", "0871111125", "charlotte.anderson@dbs.ie", "15 Mar 2004"),
                new Contact("6e95b071-9df9-4b2d-9b6a-02cf5fe287ca", "Jackson", "Thomas", "Dublin Business School", "0871111126", "jackson.thomas@dbs.ie", "16 Apr 2005"),
                new Contact("7ce64540-4d03-4bc5-8d5a-37c2b119cf77", "Amelia", "Taylor", "Dublin Business School", "0871111127", "amelia.taylor@dbs.ie", "17 May 2006"),
                new Contact("086e27a9-4c64-4cb7-a737-cd9ba01fd95a", "Mason", "Moore", "Dublin Business School", "0871111128", "mason.moore@dbs.ie", "18 Jun 2007"),
                new Contact("11e3ef73-1190-4b55-b42f-40bebc7ad927", "Harper", "Jackson", "Dublin Business School", "0871111129", "harper.jackson@dbs.ie", "19 Jul 2008"),
                new Contact("8c80aff5-fdc9-4268-8ca5-d29dec40d581", "Elijah", "White", "Dublin Business School", "0871111130", "elijah.white@dbs.ie", "20 Aug 2009"),
            ];
        }

        public Contact() {
            this.id = Guid.NewGuid().ToString();
        }

        public Contact(string firstName, string lastName, string company, string mobileNumber, string email, string birthdate)
        {
            this.id = Guid.NewGuid().ToString();
            this.firstName = firstName;
            this.lastName = lastName;
            this.company = company;
            this.mobileNumber = mobileNumber;
            this.email = email;
            this.birthdate = birthdate;
        }

        public Contact(string id, string firstName, string lastName, string company, string mobileNumber, string email, string birthdate)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.company = company;
            this.mobileNumber = mobileNumber;
            this.email = email;
            this.birthdate = birthdate;
        }

        public string GetID() {
            return id;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetCompany(string company)
        {
            this.company = company;
        }

        public string GetCompany()
        {
            return company;
        }

        public void SetMobileNumber(string mobileNumber)
        {
            this.mobileNumber = mobileNumber;
        }

        public string GetMobileNumber()
        {
            return mobileNumber;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetBirthdate(string birthdate)
        {
            this.birthdate = birthdate;
        }

        public string GetBirthdate()
        {
            return birthdate;
        }

        public void ResetContactWith(Contact contact) {
            this.firstName = contact.firstName;
            this.lastName = contact.lastName;
            this.company = contact.company;
            this.mobileNumber = contact.mobileNumber;
            this.email = contact.email;
            this.birthdate = contact.birthdate;
        }

        public string GetOverviewContact()
        {
            return $"Contact [ID: {id}, FirstName: {firstName}, LastName: {lastName}]";
        }

        public override string ToString()
        {
            return $"Contact [ID: {id}, FirstName: {firstName}, LastName: {lastName}, Company: {company}, MobileNumber: {mobileNumber}, Email: {email}, BirthDate: {birthdate}]";
        }
    }
}
