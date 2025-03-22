# Email Sender
## Overview
Email Sender is a Windows Forms application built with .NET 9.0 that allows users to send individual or bulk emails. The application supports reading email addresses from an Excel file and sending emails with attachments using the MailKit library.
### Features
•	Send Individual Emails: Users can manually input an email address and send an email with an attachment.  
•	Send Bulk Emails: Users can upload an Excel file containing email addresses and send emails to all addresses listed in the file.  
•	Excel File Support: The application reads email addresses from Excel files (.xls, .xlsx, .xlsm) using the ExcelDataReader library.  
•	Email Attachments: The application supports sending emails with attachments, such as a PDF file.  
•	SMTP Authentication: The application uses SMTP authentication to send emails securely.  
### Usage
1.	Run the application.  
2.	To send an individual email:  
•	Enter the email address in the "Send Individual Email" field.  
•	Click the "Send" button.  
3.	To send bulk emails:  
•	Click the "Browse" button and select an Excel file containing email addresses.  
•	Ensure the Excel file has a column with the header "Email".  
•	Click the "Send" button.  
### Dependencies  
•	.NET 9.0  
•	ExcelDataReader (v3.7.0)  
•	ExcelDataReader.DataSet (v3.7.0)  
•	MailKit (v4.11.0)  
### License  
This project is licensed under the MIT License. See the LICENSE file for details.  
### Contributing  
Contributions are welcome! Please open an issue or submit a pull request for improvements or bug fixes.  
### Contact  
For any questions or inquiries, don't hesitate to get in touch with Abdo Fathy at abdofathy883@gmail.com.

