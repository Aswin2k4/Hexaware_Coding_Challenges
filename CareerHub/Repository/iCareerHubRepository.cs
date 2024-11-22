using CareerHub.Model;
using System;
using System.Collections.Generic;

namespace CareerHub.Repository
{
    internal interface iCareerHubRepository
    {
        // Job Listings
        Jobs GetJobListingById(int jobId);
        List<Jobs> GetAllJobListings();
        void AddJobListing(Jobs jobListing);

        // Companies
        Companies GetCompanyById(int companyId);
        List<Companies> GetAllCompanies();
        void AddCompany(Companies company);

        // Applicants
        Applicants GetApplicantById(int applicantId);
        List<Applicants> GetAllApplicants();
        void AddApplicant(Applicants applicant);

        // Job Applications
        Applications GetJobApplicationById(int applicationId);
        List<Applications> GetApplicationsByJobId(int jobId);
        void AddJobApplication(Applications jobApplication);
    }
}
