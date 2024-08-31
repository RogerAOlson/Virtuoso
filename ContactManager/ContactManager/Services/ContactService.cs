namespace ContactManager.Services
{
    public class ContactService
    {
        public bool IdIsRequired(int id)
        {
            return id > 0;
        }

        public bool IdIsValid(int id)
        {
            return id > 0;
        }

        public bool FirstNameIsRequired(string firstName)
        {
            return !string.IsNullOrEmpty(firstName);
        }

        public bool FirstNameIsValid(string firstName)
        {
            return !string.IsNullOrEmpty(firstName) && firstName.Length > 3;
        }

        public bool LastNameIsRequired(string lastName)
        {
            return !string.IsNullOrEmpty(lastName);
        }

        public bool LastNameIsValid(string lastName)
        {
            return !string.IsNullOrEmpty(lastName) && lastName.Length > 3;
        }

        public bool EmailIsRequired(string email)
        {
            return !string.IsNullOrEmpty(email);
        }

        public bool EmailIsValid(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Length > 3;
        }

        public bool PhoneNumberIsRequired(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber);
        }

        public bool PhoneNumberIsValid(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length > 3;
        }
    }
}
