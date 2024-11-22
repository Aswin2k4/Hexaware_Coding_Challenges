--------------------------------------- Coding Challenges: CareerHub, The Job Board -------------------------------------

-- Proceding with the Task's

-- 4. Ensure the script handles potential errors, such as if the database or tables already exist.
-- 1. Provide a SQL script that initializes the database for the Job Board scenario “CareerHub”.

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CareerHub')
BEGIN
    CREATE DATABASE CareerHub;
END;

-- Switch to the newly created database
USE CareerHub;

-- Drop tables if they already exist to handle potential errors
IF OBJECT_ID('Applications', 'U') IS NOT NULL DROP TABLE Applications;
IF OBJECT_ID('Jobs', 'U') IS NOT NULL DROP TABLE Jobs;
IF OBJECT_ID('Applicants', 'U') IS NOT NULL DROP TABLE Applicants;
IF OBJECT_ID('Companies', 'U') IS NOT NULL DROP TABLE Companies;


-- 2.Create tables for Companies, Jobs, Applicants and Applications. 

-- 2.1 - Creating Companies table
CREATE TABLE Companies (
    CompanyID INT PRIMARY KEY,
    CompanyName VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL
);

-- 2.2 - Creating Jobs table
CREATE TABLE Jobs (
    JobID INT PRIMARY KEY,
    CompanyID INT,
    JobTitle VARCHAR(255) NOT NULL,
    JobDescription TEXT,
    JobLocation VARCHAR(255),
    Salary DECIMAL(18, 2),
    JobType VARCHAR(50),
    PostedDate DATETIME,
    FOREIGN KEY (CompanyID) REFERENCES Companies(CompanyID)
);

-- 2.3 - Creating Applicants table

CREATE TABLE Applicants (
    ApplicantID INT PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255),
    Phone VARCHAR(20),
    Resume TEXT
);

-- 2.4 - Creating Applications table

CREATE TABLE Applications (
    ApplicationID INT PRIMARY KEY,
    JobID INT,
    ApplicantID INT,
    ApplicationDate DATETIME,
    CoverLetter TEXT,
    FOREIGN KEY (JobID) REFERENCES Jobs(JobID),
    FOREIGN KEY (ApplicantID) REFERENCES Applicants(ApplicantID)
);

-- Inserting records into Companies table
INSERT INTO Companies (CompanyID, CompanyName, Location) VALUES
(1, 'Tata Consultancy Services', 'Mumbai'),
(2, 'Infosys', 'Bengaluru'),
(3, 'Wipro', 'Hyderabad'),
(4, 'HCL Technologies', 'Noida'),
(5, 'Tech Mahindra', 'Pune'),
(6, 'Accenture India', 'Mumbai'),
(7, 'Cognizant', 'Chennai'),
(8, 'Capgemini India', 'Pune'),
(9, 'Larsen & Toubro Infotech', 'Mumbai'),
(10, 'Mindtree', 'Bengaluru');

SELECT * FROM Companies;

-- Inserting records into Jobs table
INSERT INTO Jobs (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) VALUES
(1, 1, 'Software Developer', 'Develop and maintain software applications', 'Mumbai', 600000, 'Full-time', '2023-11-01'),
(2, 2, 'Data Analyst', 'Analyze and interpret complex data sets', 'Bengaluru', 700000, 'Full-time', '2023-11-02'),
(3, 3, 'System Engineer', 'Ensure efficient operation of computer systems', 'Hyderabad', 550000, 'Contract', '2023-11-03'),
(4, 4, 'Network Administrator', 'Manage and monitor network infrastructure', 'Noida', 650000, 'Full-time', '2023-11-04'),
(5, 5, 'Project Manager', 'Oversee software development projects', 'Pune', 1200000, 'Full-time', '2023-11-05'),
(6, 6, 'Business Analyst', 'Identify business requirements and solutions', 'Mumbai', 800000, 'Full-time', '2023-11-06'),
(7, 7, 'Quality Analyst', 'Ensure quality standards in software products', 'Chennai', 500000, 'Part-time', '2023-11-07'),
(8, 8, 'DevOps Engineer', 'Automate and streamline operations', 'Pune', 900000, 'Full-time', '2023-11-08'),
(9, 9, 'Technical Support Engineer', 'Provide technical support to clients', 'Mumbai', 400000, 'Contract', '2023-11-09'),
(10, 10, 'Cloud Engineer', 'Design and manage cloud infrastructure', 'Bengaluru', 950000, 'Full-time', '2023-11-10');


SELECT * FROM Jobs;

-- Inserting records into Applicants table
INSERT INTO Applicants (ApplicantID, FirstName, LastName, Email, Phone, Resume) VALUES
(1, 'Amit', 'Patel', 'amit.patel@gmail.com', '9876543210', 'Experienced in Java and SQL development'),
(2, 'Raj', 'Sharma', 'raj.sharma@yahoo.com', '9876543211', 'Data analysis expert with Python and R'),
(3, 'Anil', 'Kumar', 'anil.kumar@outlook.com', '9876543212', 'Specializes in system administration and support'),
(4, 'Neha', 'Singh', 'neha.singh@gmail.com', '9876543213', 'Experienced network administrator and cybersecurity specialist'),
(5, 'Ravi', 'Joshi', 'ravi.joshi@gmail.com', '9876543214', 'Project manager with PMP certification'),
(6, 'Sara', 'Iyer', 'sara.iyer@yahoo.com', '9876543215', 'Business analyst with strong communication skills'),
(7, 'Raju', 'Das', 'raju.das@gmail.com', '9876543216', 'Quality assurance engineer with automation expertise'),
(8, 'Rita', 'Rana', 'rita.rana@outlook.com', '9876543217', 'DevOps engineer with cloud certification'),
(9, 'Sunil', 'Mishra', 'sunil.mishra@gmail.com', '9876543218', 'Experienced in customer support and technical troubleshooting'),
(10, 'Priya', 'Das', 'priya.das@gmail.com', '9876543219', 'Cloud architect with AWS certification'),
(11, 'Leo', 'Das', 'leo@yahoo.com', '9876543220', 'Business analyst with strong communication skills'),
(12, 'Varshini', 'Sharma', 'varshini@gmail.com', '9876543221', 'Quality assurance engineer with automation expertise'),
(13, 'Sathish', 'Kumar', 'sathish.kumar@outlook.com', '9876543222', 'Data analysis expert with Python and R'),
(14, 'Raju', 'Bhai', 'raju.bhai@gmail.com', '9876543223', 'Business analyst with strong communication skills');

SELECT * FROM Applicants;

-- Inserting records into Applications table
INSERT INTO Applications (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter) VALUES
(1, 1, 1, '2023-11-11', 'Passionate about software development and eager to learn new technologies.'),
(2, 2, 2, '2023-11-12', 'Excited to apply my data analysis skills to drive business insights.'),
(3, 3, 3, '2023-11-13', 'Experienced in managing complex systems and ensuring uptime.'),
(4, 4, 4, '2023-11-14', 'Looking forward to working in network management and security.'),
(5, 5, 5, '2023-11-15', 'Seasoned project manager ready to lead cross-functional teams.'),
(6, 6, 6, '2023-11-16', 'Skilled business analyst with a focus on data-driven decisions.'),
(7, 7, 7, '2023-11-17', 'Expert in quality assurance, committed to ensuring software quality.'),
(8, 8, 8, '2023-11-18', 'Certified DevOps engineer passionate about automation and cloud.'),
(9, 9, 9, '2023-11-19', 'Dedicated to providing excellent technical support and troubleshooting.'),
(10, 10, 10, '2023-11-20', 'Experienced in cloud solutions, with a focus on scalability and security.'),
(11, 2, 13, '2023-11-25', 'Excited to apply my data analysis skills to drive business insights.'),
(12, 6, 14, '2023-11-28', 'Skilled business analyst with a focus on data-driven decisions.');

SELECT * FROM Applications;


-- 3. Define appropriate primary keys, foreign keys, and constraints.
-- The primary keys and foreign keys are already defined within the table creation itself

/* 5. Write an SQL query to count the number of applications received for each job listing in the "Jobs" table. Display 
the job title and the corresponding application count. Ensure that it lists all jobs, even if they have no applications. */

SELECT j.JobTitle, COUNT(a.ApplicationID) AS ApplicationCount
FROM Jobs j
LEFT JOIN Applications a
ON j.JobID = a.JobID
GROUP BY j.JobTitle;

SELECT * FROM Jobs;
SELECT * FROM Applications;


/* 6. Develop an SQL query that retrieves job listings from the "Jobs" table within a specified salary range.
 Allow parameters for the minimum and maximum salary values. Display the job title, company name,
 location, and salary for each matching job. */

DECLARE @MinSalary DECIMAL(18, 2) = 600000.00;
DECLARE @MaxSalary DECIMAL(18, 2) = 800000.00;

SELECT j.JobTitle, c.CompanyName, j.JobLocation, j.Salary
FROM Jobs j
JOIN Companies c 
ON j.CompanyID = c.CompanyID
WHERE j.Salary BETWEEN @MinSalary AND @MaxSalary;


/*7. Write an SQL query that retrieves the job application history for a specific applicant. Allow aparameter for
 the ApplicantID, and return a result set with the job titles, company names, and application dates for all the 
 jobs the applicant has applied to. */

DECLARE @ApplicantID INT = 1;

SELECT j.JobTitle, c.CompanyName, a.ApplicationDate
FROM Applications a
JOIN Jobs j 
ON a.JobID = j.JobID
JOIN Companies c 
ON j.CompanyID = c.CompanyID
WHERE a.ApplicantID = @ApplicantID;

SELECT * FROM Jobs;
SELECT * FROM Companies;
SELECT * FROM Applications;


/* 8. Create an SQL query that calculates and displays the average salary offered by all companies for job listings in 
 the "Jobs" table. Ensure that the query filters out jobs with a salary of zero. */

SELECT c.CompanyName, AVG(j.Salary) AS Average_Salary
FROM Jobs j
JOIN Companies c ON j.CompanyID = c.CompanyID
WHERE j.Salary > 0
GROUP BY c.CompanyName;


/* 9. Write an SQL query to identify the company that has posted the most job listings. Display the company name along 
 with the count of job listings they have posted. Handle ties if multiple companies have the same maximum count. */

SELECT c.CompanyName, COUNT(j.JobID) AS Job_Count
FROM Jobs j
JOIN Companies c 
ON j.CompanyID = c.CompanyID
GROUP BY c.CompanyName
ORDER BY Job_Count DESC;


/* 10. Find the applicants who have applied for positions in companies located in 'CityX' and have at least 3 years of experience. */

/* Usually we will extract the experience from the resume and add it to the experience column in realtime (Method 1), but here im using to 
 Using 2nd method */

-- Method 2 - adding a column 'YearsOfExperience' to the Applicants table

SELECT * FROM Applicants;

ALTER TABLE Applicants
ADD YearsOfExperience INT;

UPDATE Applicants
SET YearsOfExperience = 
    CASE 
        WHEN ApplicantID = 1 THEN 2
        WHEN ApplicantID = 2 THEN 3
        WHEN ApplicantID = 3 THEN 5
		WHEN ApplicantID = 4 THEN 4
        WHEN ApplicantID = 5 THEN 3
        WHEN ApplicantID = 6 THEN 6
		WHEN ApplicantID = 7 THEN 3
        WHEN ApplicantID = 8 THEN 5
        WHEN ApplicantID = 9 THEN 4
		WHEN ApplicantID = 10 THEN 6
		WHEN ApplicantID = 11 THEN 1
		WHEN ApplicantID = 12 THEN 1
		WHEN ApplicantID = 13 THEN 4
		WHEN ApplicantID = 14 THEN 2
    END;

DECLARE @CityX VARCHAR(255) = 'Chennai';

SELECT a.FirstName, a.LastName
FROM Applications app
JOIN Jobs j ON app.JobID = j.JobID
JOIN Applicants a ON app.ApplicantID = a.ApplicantID
WHERE j.JobLocation = @CityX AND a.YearsOfExperience >= 3;

SELECT * FROM Applicants;
SELECT * FROM Applications;
SELECT * FROM Jobs;

/* 11. Retrieve a list of distinct job titles with salaries between $60,0000 and $80,0000. */

SELECT DISTINCT JobTitle
FROM Jobs
WHERE Salary BETWEEN 600000 AND 800000;

/* 12. Find the jobs that have not received any applications. */

SELECT j.JobTitle
FROM Jobs j
LEFT JOIN Applications a 
ON j.JobID = a.JobID
WHERE a.ApplicationID IS NULL;

/* 13. Retrieve a list of job applicants along with the companies they have applied to and the positions they have applied for. */

SELECT a.FirstName, a.LastName, c.CompanyName, j.JobTitle
FROM Applications app
JOIN Applicants a 
ON app.ApplicantID = a.ApplicantID
JOIN Jobs j 
ON app.JobID = j.JobID
JOIN Companies c 
ON j.CompanyID = c.CompanyID;

/* 14. Retrieve a list of companies along with the count of jobs they have posted, even if they have not received any applications. */

SELECT c.CompanyName, COUNT(j.JobID) AS JobCount
FROM Companies c
LEFT JOIN Jobs j 
ON c.CompanyID = j.CompanyID
GROUP BY c.CompanyName;

/* 15. List all applicants along with the companies and positions they have applied for, including those who have not applied. */


SELECT a.FirstName, a.LastName, c.CompanyName, j.JobTitle
FROM Applicants a
LEFT JOIN Applications app 
ON a.ApplicantID = app.ApplicantID
LEFT JOIN Jobs j 
ON app.JobID = j.JobID
LEFT JOIN Companies c 
ON j.CompanyID = c.CompanyID;

SELECT * FROM Applicants;
SELECT * FROM Applications;

/* 16. Find companies that have posted jobs with a salary higher than the average salary of all jobs. */

SELECT DISTINCT c.CompanyName
FROM Companies c
JOIN Jobs j 
ON c.CompanyID = j.CompanyID
WHERE j.Salary > (SELECT AVG(Salary) FROM Jobs WHERE Salary > 0);

/* 17. Display a list of applicants with their names and a concatenated string of their city and state. */
/* Question has been change by trainer instead (city and state) using (JobTitle and JobLocation) */

SELECT a.FirstName, a.LastName, CONCAT(j.JobTitle, ', ', j.JobLocation) AS JobTitleLocation
FROM Applications app
JOIN Jobs j ON app.JobID = j.JobID
JOIN Applicants a ON app.ApplicantID = a.ApplicantID;

SELECT * FROM Applicants;
SELECT * FROM Jobs;
SELECT * FROM Applications;

/* 18. Retrieve a list of jobs with titles containing either 'Developer' or 'Engineer'. */

SELECT JobTitle
FROM Jobs
WHERE JobTitle LIKE '%Developer%' OR JobTitle LIKE '%Engineer%';

/* 19. Retrieve a list of applicants and the jobs they have applied for, including those who have not applied and 
jobs without applicants. */

SELECT a.FirstName, a.LastName, j.JobTitle
FROM Applicants a
FULL JOIN Applications app 
ON a.ApplicantID = app.ApplicantID
FULL JOIN Jobs j 
ON app.JobID = j.JobID;

/* 20. List all combinations of applicants and companies where the company is in a specific city and the applicant has 
more than 2 years of experience. For example: city=Chennai */

DECLARE @City VARCHAR(255) = 'Chennai';

SELECT a.FirstName, a.LastName, c.CompanyName
FROM Applicants a
CROSS JOIN Companies c
WHERE c.Location = @City AND a.YearsOfExperience > 2;


-- ==================================================================================================== 

SELECT * FROM Jobs;
SELECT * FROM Companies;
SELECT * FROM Applications;
SELECT * FROM Applicants;
