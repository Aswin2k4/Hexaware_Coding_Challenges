using CareerHub.Model;
using CareerHub.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CareerHub.Repository
{
    internal class CareerHubRepository : iCareerHubRepository
    {
        private readonly string connectionString;
        private SqlCommand _cmd;

        public CareerHubRepository()
        {
            connectionString = DBConnUtil.GetConnectionString();
            _cmd = new SqlCommand();
        }

        #region Job Listings
        public Jobs GetJobListingById(int jobId)
        {
            Jobs jobListing = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Jobs WHERE JobID = @JobID";
                    _cmd.Parameters.AddWithValue("@JobID", jobId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        jobListing = new Jobs(
                            (int)reader["JobID"],
                            (int)reader["CompanyID"],
                            (string)reader["JobTitle"],
                            (string)reader["JobDescription"],
                            (string)reader["JobLocation"],
                            (decimal)reader["Salary"],
                            (string)reader["JobType"],
                            (DateTime)reader["PostedDate"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return jobListing;
        }

        public List<Jobs> GetAllJobListings()
        {
            List<Jobs> jobListings = new List<Jobs>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Jobs";
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        jobListings.Add(new Jobs(
                            (int)reader["JobID"],
                            (int)reader["CompanyID"],
                            (string)reader["JobTitle"],
                            (string)reader["JobDescription"],
                            (string)reader["JobLocation"],
                            (decimal)reader["Salary"],
                            (string)reader["JobType"],
                            (DateTime)reader["PostedDate"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return jobListings;
        }

        public void AddJobListing(Jobs jobListing)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Jobs (CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate)
                                         VALUES (@CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CompanyID", jobListing.CompanyID);
                    _cmd.Parameters.AddWithValue("@JobTitle", jobListing.JobTitle);
                    _cmd.Parameters.AddWithValue("@JobDescription", jobListing.JobDescription);
                    _cmd.Parameters.AddWithValue("@JobLocation", jobListing.JobLocation);
                    _cmd.Parameters.AddWithValue("@Salary", jobListing.Salary);
                    _cmd.Parameters.AddWithValue("@JobType", jobListing.JobType);
                    _cmd.Parameters.AddWithValue("@PostedDate", jobListing.PostedDate);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding job listing: " + ex.Message);
                }
            }
        }
        #endregion

        #region Companies
        public Companies GetCompanyById(int companyId)
        {
            Companies company = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Companies WHERE CompanyID = @CompanyID";
                    _cmd.Parameters.AddWithValue("@CompanyID", companyId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        company = new Companies(
                            (int)reader["CompanyID"],
                            (string)reader["CompanyName"],
                            (string)reader["Location"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return company;
        }

        public List<Companies> GetAllCompanies()
        {
            List<Companies> companies = new List<Companies>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Companies";
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        companies.Add(new Companies(
                            (int)reader["CompanyID"],
                            (string)reader["CompanyName"],
                            (string)reader["Location"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return companies;
        }

        public void AddCompany(Companies company)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Companies (CompanyName, Location) 
                                         VALUES (@CompanyName, @Location)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                    _cmd.Parameters.AddWithValue("@Location", company.Location);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding company: " + ex.Message);
                }
            }
        }
        #endregion

        #region Applicants
        public Applicants GetApplicantById(int applicantId)
        {
            Applicants applicant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Applicants WHERE ApplicantID = @ApplicantID";
                    _cmd.Parameters.AddWithValue("@ApplicantID", applicantId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        applicant = new Applicants(
                            (int)reader["ApplicantID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["Email"],
                            (string)reader["Phone"],
                            (string)reader["Resume"],
                            (int)reader["YearsOfExperience"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return applicant;
        }

        public List<Applicants> GetAllApplicants()
        {
            List<Applicants> applicants = new List<Applicants>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Applicants";
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        applicants.Add(new Applicants(
                            (int)reader["ApplicantID"],
                            (string)reader["FirstName"],
                            (string)reader["LastName"],
                            (string)reader["Email"],
                            (string)reader["Phone"],
                            (string)reader["Resume"],
                            (int)reader["YearsOfExperience"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return applicants;
        }

        public void AddApplicant(Applicants applicant)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Applicants (FirstName, LastName, Email, Phone, Resume, YearsOfExperience) 
                                         VALUES (@FirstName, @LastName, @Email, @Phone, @Resume, @YearsOfExperience)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                    _cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                    _cmd.Parameters.AddWithValue("@Email", applicant.Email);
                    _cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                    _cmd.Parameters.AddWithValue("@Resume", applicant.Resume);
                    _cmd.Parameters.AddWithValue("@YearsOfExperience", applicant.YearsOfExperience);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding applicant: " + ex.Message);
                }
            }
        }
        #endregion

        #region Job Applications
        public Applications GetJobApplicationById(int applicationId)
        {
            Applications jobApplication = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
                    _cmd.Parameters.AddWithValue("@ApplicationID", applicationId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        jobApplication = new Applications(
                            (int)reader["ApplicationID"],
                            (int)reader["JobID"],
                            (int)reader["ApplicantID"],
                            (DateTime)reader["ApplicationDate"],
                            (string)reader["CoverLetter"]
                        );
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return jobApplication;
        }

        public List<Applications> GetApplicationsByJobId(int jobId)
        {
            List<Applications> applications = new List<Applications>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = "SELECT * FROM Applications WHERE JobID = @JobID";
                    _cmd.Parameters.AddWithValue("@JobID", jobId);
                    _cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Ensure you're passing the correct parameters to the constructor
                        applications.Add(new Applications(
                            (int)reader["ApplicationID"],
                            (int)reader["JobID"],
                            (int)reader["ApplicantID"],
                            (DateTime)reader["ApplicationDate"],
                            (string)reader["CoverLetter"]
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return applications;
        }

        public void AddJobApplication(Applications jobApplication)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    _cmd.CommandText = @"INSERT INTO Applications (JobID, ApplicantID, ApplicationDate, CoverLetter)
                                         VALUES (@JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";
                    _cmd.Connection = conn;

                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@JobID", jobApplication.JobID);
                    _cmd.Parameters.AddWithValue("@ApplicantID", jobApplication.ApplicantID);
                    _cmd.Parameters.AddWithValue("@ApplicationDate", jobApplication.ApplicationDate);
                    _cmd.Parameters.AddWithValue("@CoverLetter", jobApplication.CoverLetter);

                    conn.Open();
                    _cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding job application: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
