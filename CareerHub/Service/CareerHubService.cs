using CareerHub.Model;
using CareerHub.Repository;
using System;
using System.Collections.Generic;

namespace CareerHub.Service
{
    internal class CareerHubService : iCareerHubService
    {
        private readonly iCareerHubRepository _careerHubRepository;

        public CareerHubService(iCareerHubRepository careerHubRepository)
        {
            _careerHubRepository = careerHubRepository;
        }

        #region Job Listings
        public void GetAllJobListings()
        {
            List<Jobs> jobListings = _careerHubRepository.GetAllJobListings();
            if (jobListings.Count == 0)
            {
                Console.WriteLine("No job listings found.");
            }
            else
            {
                Console.WriteLine("Job Listings:");
                foreach (var job in jobListings)
                {
                    Console.WriteLine($"Job ID: {job.JobID}, Title: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary:C}");
                }
            }
        }

        public void GetJobListingById(int jobId)
        {
            Jobs job = _careerHubRepository.GetJobListingById(jobId);
            if (job == null)
            {
                Console.WriteLine($"Job not found with ID: {jobId}");
            }
            else
            {
                Console.WriteLine($"Job Found: {job.JobTitle}, Location: {job.JobLocation}, Salary: {job.Salary:C}");
            }
        }

        public void AddJobListing(Jobs jobListing)
        {
            _careerHubRepository.AddJobListing(jobListing);
            Console.WriteLine("Job listing added successfully.");
        }
        #endregion

        #region Companies
        public void GetAllCompanies()
        {
            List<Companies> companies = _careerHubRepository.GetAllCompanies();
            if (companies.Count == 0)
            {
                Console.WriteLine("No companies found.");
            }
            else
            {
                Console.WriteLine("Companies:");
                foreach (var company in companies)
                {
                    Console.WriteLine($"Company ID: {company.CompanyID}, Name: {company.CompanyName}, Location: {company.Location}");
                }
            }
        }

        public void GetCompanyById(int companyId)
        {
            Companies company = _careerHubRepository.GetCompanyById(companyId);
            if (company == null)
            {
                Console.WriteLine($"Company not found with ID: {companyId}");
            }
            else
            {
                Console.WriteLine($"Company Found: {company.CompanyName}, Location: {company.Location}");
            }
        }

        public void AddCompany(Companies company)
        {
            _careerHubRepository.AddCompany(company);
            Console.WriteLine("Company added successfully.");
        }
        #endregion

        #region Applicants
        public void GetAllApplicants()
        {
            List<Applicants> applicants = _careerHubRepository.GetAllApplicants();
            if (applicants.Count == 0)
            {
                Console.WriteLine("No applicants found.");
            }
            else
            {
                Console.WriteLine("Applicants:");
                foreach (var applicant in applicants)
                {
                    Console.WriteLine($"Applicant ID: {applicant.ApplicantID}, Name: {applicant.FirstName} {applicant.LastName}, Email: {applicant.Email}");
                }
            }
        }

        public void GetApplicantById(int applicantId)
        {
            Applicants applicant = _careerHubRepository.GetApplicantById(applicantId);
            if (applicant == null)
            {
                Console.WriteLine($"Applicant not found with ID: {applicantId}");
            }
            else
            {
                Console.WriteLine($"Applicant Found: {applicant.FirstName} {applicant.LastName}, Email: {applicant.Email}");
            }
        }

        public void AddApplicant(Applicants applicant)
        {
            _careerHubRepository.AddApplicant(applicant);
            Console.WriteLine("Applicant added successfully.");
        }
        #endregion

        #region Job Applications
        public void GetJobApplicationById(int applicationId)
        {
            Applications jobApplication = _careerHubRepository.GetJobApplicationById(applicationId);
            if (jobApplication == null)
            {
                Console.WriteLine($"Job application not found with ID: {applicationId}");
            }
            else
            {
                Console.WriteLine($"Job Application Found: Job ID {jobApplication.JobID}, Applicant ID {jobApplication.ApplicantID}, Cover Letter: {jobApplication.CoverLetter}");
            }
        }

        public void GetApplicationsByJobId(int jobId)
        {
            List<Applications> applications = _careerHubRepository.GetApplicationsByJobId(jobId);
            if (applications.Count == 0)
            {
                Console.WriteLine("No applications found for this job.");
            }
            else
            {
                Console.WriteLine("Applications for this Job:");
                foreach (var application in applications)
                {
                    Console.WriteLine($"Application ID: {application.ApplicationID}, Applicant ID: {application.ApplicantID}, Date: {application.ApplicationDate}");
                }
            }
        }

        public void AddJobApplication(Applications jobApplication)
        {
            _careerHubRepository.AddJobApplication(jobApplication);
            Console.WriteLine("Job application added successfully.");
        }
        #endregion
    }
}
