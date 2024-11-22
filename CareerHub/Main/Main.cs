using CareerHub.Model;
using CareerHub.Repository;
using CareerHub.Service;
using System;
using System.Collections.Generic;

iCareerHubService careerHubService = new CareerHubService(new CareerHubRepository());
bool continueRunning = true;

while (continueRunning)
{
    Console.WriteLine("\n---- CareerHub Job Board ----");
    Console.WriteLine("1. Add New Job Listing");
    Console.WriteLine("2. View Job Listing By ID");
    Console.WriteLine("3. Add New Company");
    Console.WriteLine("4. View Company By ID");
    Console.WriteLine("5. Add New Applicant");
    Console.WriteLine("6. View Applicant By ID");
    Console.WriteLine("7. Apply for Job");
    Console.WriteLine("8. View Job Applications");
    Console.WriteLine("9. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        // Job Listings
        case "1":
            Console.WriteLine("Enter Job Listing Details:");
            Jobs newJobListing = new Jobs();

            Console.Write("Job Title: ");
            newJobListing.JobTitle = Console.ReadLine();

            Console.Write("Job Description: ");
            newJobListing.JobDescription = Console.ReadLine();

            Console.Write("Job Location: ");
            newJobListing.JobLocation = Console.ReadLine();

            Console.Write("Salary: ");
            newJobListing.Salary = decimal.Parse(Console.ReadLine());

            Console.Write("Job Type (Full-time/Part-time/Contract): ");
            newJobListing.JobType = Console.ReadLine();

            Console.Write("Posted Date (YYYY-MM-DD): ");
            newJobListing.PostedDate = DateTime.Parse(Console.ReadLine());

            careerHubService.AddJobListing(newJobListing);
            Console.WriteLine("Job listing added successfully.");
            break;

        case "2":
            Console.Write("Enter Job Listing ID to view: ");
            int jobId = int.Parse(Console.ReadLine());

            careerHubService.GetJobListingById(jobId);
            break;

        // Companies
        case "3":
            Console.WriteLine("Enter Company Details:");
            Companies newCompany = new Companies();

            Console.Write("Company Name: ");
            newCompany.CompanyName = Console.ReadLine();

            Console.Write("Location: ");
            newCompany.Location = Console.ReadLine();

            careerHubService.AddCompany(newCompany);
            Console.WriteLine("Company added successfully.");
            break;

        case "4":
            Console.Write("Enter Company ID to view: ");
            int companyId = int.Parse(Console.ReadLine());

            careerHubService.GetCompanyById(companyId);
            break;

        // Applicants
        case "5":
            Console.WriteLine("Enter Applicant Details:");
            Applicants newApplicant = new Applicants();

            Console.Write("First Name: ");
            newApplicant.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            newApplicant.LastName = Console.ReadLine();

            Console.Write("Email: ");
            newApplicant.Email = Console.ReadLine();

            Console.Write("Phone: ");
            newApplicant.Phone = Console.ReadLine();

            Console.Write("Resume: ");
            newApplicant.Resume = Console.ReadLine();

            careerHubService.AddApplicant(newApplicant);
            Console.WriteLine("Applicant added successfully.");
            break;

        case "6":
            Console.Write("Enter Applicant ID to view: ");
            int applicantId = int.Parse(Console.ReadLine());

            careerHubService.GetApplicantById(applicantId);
            break;

        // Job Applications
        case "7":
            Console.Write("Enter Job ID to apply for: ");
            int jobIdToApply = int.Parse(Console.ReadLine());

            Console.Write("Enter Applicant ID: ");
            int applicantIdToApply = int.Parse(Console.ReadLine());

            Console.Write("Enter Cover Letter: ");
            string coverLetter = Console.ReadLine();

            Applications newJobApplication = new Applications
            {
                JobID = jobIdToApply,
                ApplicantID = applicantIdToApply,
                ApplicationDate = DateTime.Now,
                CoverLetter = coverLetter
            };

            careerHubService.AddJobApplication(newJobApplication);
            Console.WriteLine("Job application submitted successfully.");
            break;

        case "8":
            Console.Write("Enter Job ID to view applications: ");
            int jobIDForApplications = int.Parse(Console.ReadLine());

            careerHubService.GetApplicationsByJobId(jobIDForApplications);
            break;

        case "9":
            continueRunning = false;
            Console.WriteLine("Exiting the system.");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}
