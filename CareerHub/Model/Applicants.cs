using System;

namespace CareerHub.Model
{
    internal class Applicants
    {
        public Applicants() { }
        private int _applicantID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _resume;
        private int _yearsOfExperience;

        public Applicants(int v1, string v2, string v3, string v4, string v5, string v6, int v7)
        {
        }

        public int ApplicantID
        {
            get { return _applicantID; }
            set { _applicantID = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Resume
        {
            get { return _resume; }
            set { _resume = value; }
        }

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }

        // Method to validate input data
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                Console.WriteLine("Invalid email format.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Phone) || Phone.Length < 10)
            {
                Console.WriteLine("Invalid phone number.");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Applicant ID: {ApplicantID}\t" +
                   $"Name: {FirstName} {LastName}\t" +
                   $"Email: {Email}\t" +
                   $"Phone: {Phone}\t" +
                   $"YearsOfExperience: {YearsOfExperience}\n";
        }
    }
}
