using System;

namespace CareerHub.Model
{
    internal class Applications
    {
        public Applications() { }
        private int _applicationID;
        private int _jobID;
        private int _applicantID;
        private DateTime _applicationDate;
        private string _coverLetter;

        public int ApplicationID
        {
            get { return _applicationID; }
            set { _applicationID = value; }
        }

        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }

        public int ApplicantID
        {
            get { return _applicantID; }
            set { _applicantID = value; }
        }

        public DateTime ApplicationDate
        {
            get { return _applicationDate; }
            set { _applicationDate = value; }
        }

        public string CoverLetter
        {
            get { return _coverLetter; }
            set { _coverLetter = value; }
        }

        // Constructor to initialize with necessary fields
        public Applications(int applicationID, int jobID, int applicantID, DateTime applicationDate, string coverLetter)
        {
            ApplicationID = applicationID;
            JobID = jobID;
            ApplicantID = applicantID;
            ApplicationDate = applicationDate;
            CoverLetter = coverLetter;
        }

        // Method to validate input data
        public bool Validate()
        {
            if (JobID <= 0)
            {
                Console.WriteLine("Invalid Job ID.");
                return false;
            }
            if (ApplicantID <= 0)
            {
                Console.WriteLine("Invalid Applicant ID.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(CoverLetter))
            {
                Console.WriteLine("Cover letter cannot be empty.");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"Application ID: {ApplicationID}\t" +
                   $"Job ID: {JobID}\t" +
                   $"Applicant ID: {ApplicantID}\t" +
                   $"Application Date: {ApplicationDate}\t" +
                   $"Cover Letter: {CoverLetter}\n";
        }
    }
}
