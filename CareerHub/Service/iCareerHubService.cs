using CareerHub.Model;
using System;
using System.Collections.Generic;

namespace CareerHub.Service
{
    internal interface iCareerHubService
    {
        // Job Listings
        void GetAllJobListings();
        void GetJobListingById(int jobId);
        void AddJobListing(Jobs jobListing);

        // Companies
        void GetAllCompanies();
        void GetCompanyById(int companyId);
        void AddCompany(Companies company);

        // Applicants
        void GetAllApplicants();
        void GetApplicantById(int applicantId);
        void AddApplicant(Applicants applicant);

        // Job Applications
        void GetJobApplicationById(int applicationId);
        void GetApplicationsByJobId(int jobId);
        void AddJobApplication(Applications jobApplication);
    }
}
