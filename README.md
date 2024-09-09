Contract Monthly Claim System (CMCS)
Introduction
The Contract Monthly Claim System (CMCS) is an application developed to simplify the process of submitting, reviewing, and approving monthly claims for independent contractors. It supports claim submissions, reviews, and tracking functionalities.

Features
Lecturers: Can submit their claims and upload necessary documents.
Programme Coordinators: Responsible for reviewing and approving the submitted claims.
Academic Managers: Handle the final review of claims and reassess any that were previously denied.
Installation Instructions
Clone the repository with:

bash
Copy code
git clone https://github.com/ST10304249/ContractMonthlyClaimSystems-PROG6212-PART1-ST10304249.git 
Install the required dependencies:


cd contract-monthly-claim
dotnet restore
Launch the application:

dotnet run

Configuration
Ensure .NET 6.0 or later is installed on your machine.
Update the database connection string in the appsettings.json file.
How to Use
Go to /Lecturer/SubmitClaim to submit a new claim.
Visit /AcademicManager/Dashboard to view and manage pending claims.
Contributing
Fork the repository to your own GitHub account.
Create a new feature branch with git checkout -b feature-branch.
Commit your changes using git commit -am 'Add new feature'.
Push your branch to GitHub with git push origin feature-branch.
Open a new Pull Request to propose your changes.
License
This project is licensed under the MIT License. Please refer to the LICENSE file for more information.

Contact
For any inquiries or issues, please reach out to lotriciankuna@gmail.com.