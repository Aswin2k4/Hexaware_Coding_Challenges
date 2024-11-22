using System;

namespace CareerHub.Model
{
    internal class Jobs
    {
        public Jobs() { }
        private int _jobID;
        private int _companyID;
        private string _jobTitle;
        private string _jobDescription;
        private string _jobLocation;
        private decimal _salary;
        private string _jobType;
        private DateTime _postedDate;

        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }

        public int CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }

        public string JobDescription
        {
            get { return _jobDescription; }
            set { _jobDescription = value; }
        }

        public string JobLocation
        {
            get { return _jobLocation; }
            set { _jobLocation = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Salary must be greater than zero.");
                }
                _salary = value;
            }
        }

        public string JobType
        {
            get { return _jobType; }
            set { _jobType = value; }
        }

        public DateTime PostedDate
        {
            get { return _postedDate; }
            set { _postedDate = value; }
        }

        // Constructor to initialize with necessary fields
        public Jobs(int jobID, int companyID, string jobTitle, string jobDescription, string jobLocation, decimal salary, string jobType, DateTime postedDate)
        {
            JobID = jobID;
            CompanyID = companyID;
            JobTitle = jobTitle;
            JobDescription = jobDescription;
            JobLocation = jobLocation;
            Salary = salary;
            JobType = jobType;
            PostedDate = postedDate;
        }

        // Method to validate input data
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(JobTitle))
            {
                Console.WriteLine("Job Title cannot be empty.");
                return false;
            }
            if (Salary <= 0)
            {
                Console.WriteLine("Salary must be a positive value.");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Job ID: {JobID}\t" +
                   $"Company ID: {CompanyID}\t" +
                   $"Job Title: {JobTitle}\t" +
                   $"Location: {JobLocation}\t" +
                   $"Salary: {Salary:C}\t" +
                   $"Posted Date: {PostedDate}\n";
        }
    }
}
