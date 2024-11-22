using System;

namespace CareerHub.Model
{
    internal class Companies
    {

        private int _companyID;
        private string _companyName;
        private string _location;

        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Company Name cannot be empty.");
                }
                _companyName = value;
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location cannot be empty.");
                }
                _location = value;
            }
        }

        // Constructor for initialization
        public Companies(int companyID, string companyName, string location)
        {
            CompanyID = companyID;
            CompanyName = companyName;
            Location = location;
        }

        public Companies()
        {
        }

        // Method to validate input data
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(CompanyName))
            {
                Console.WriteLine("Company Name cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Location))
            {
                Console.WriteLine("Location cannot be empty.");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Company ID: {CompanyID}\t" +
                   $"Company Name: {CompanyName}\t" +
                   $"Location: {Location}\n";
        }
    }
}
