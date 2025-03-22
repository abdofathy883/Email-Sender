using ExcelDataReader;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Data;
using System.Net.Http.Headers;
using static System.IO.Stream;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace Email_Sender
{
    public partial class MailSender : Form
    {
        private List<string> EmailList = new List<string>();
        public MailSender()
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(112, 109, 84);
                }
            }
        }

        private List<string> ReadEmailsFromExcel(string FilePath)
        {
            var Emails = new List<string>();
            using (var Stream = File.Open(FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var ExcelReader = ExcelDataReader.ExcelReaderFactory.CreateReader(Stream))
                {
                    var DataSet = ExcelReader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    var DataTable = DataSet.Tables[0];
                    var EmailColumn = DataTable.Columns
                        .Cast<DataColumn>()
                        .FirstOrDefault(col => col.ColumnName.Trim().Equals("Email", StringComparison.OrdinalIgnoreCase));
                    if (EmailColumn != null)
                    {


                        foreach (DataRow row in DataTable.Rows)
                        {
                            if (DataTable.Columns.Contains("Email"))
                            {
                                var email = row["Email"].ToString();
                                if (!string.IsNullOrEmpty(email))
                                {
                                    Emails.Add(email);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email column not found in the Excel file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return Emails;
        }

        private async Task SendEmailAsync(string toEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Abdo Fathy", "abdofathy883@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "Job Application – Full Stack .Net Developer";

            var body = new TextPart("plain")
            {
                Text = "Dear Hiring Manager,\n\nI am very interested in opportunities at your company. Please find my CV attached.\n\nBest regards,\nAbdo Fathy"
            };

            string CVPath = @"D:\Email Sender\Abdo Fathy DotNet.pdf";
            if (!File.Exists(CVPath))
            {
                MessageBox.Show("File path is incorrect");
                return;
            }
            var attachment = new MimePart("application", "pdf")
            {
                Content = new MimeContent(File.OpenRead(CVPath), ContentEncoding.Base64),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(CVPath)
            };

            var multipart = new Multipart("mixed") { body, attachment };
            message.Body = multipart;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                
                await client.AuthenticateAsync("abdofathy883@gmail.com", "your-app-password");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }


        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            MailFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (MailFileDialog.ShowDialog() == DialogResult.OK)
            {
                EmailList = ReadEmailsFromExcel(MailFileDialog.FileName);
                MailsFromExcel.DataSource = EmailList;
            }
        }

        private async void SendBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EmailInput.Text))
            {
                try
                {
                    await SendEmailAsync(EmailInput.Text);
                    MessageBox.Show($"Email Sent to: {EmailInput.Text}");


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to send to {EmailInput.Text}: {ex.Message}");
                }
            }
            else if (EmailList != null && EmailList.Count > 0)
            {
                int SuccessCount = 0;
                int FailCount = 0;
                foreach (var email in EmailList)
                {
                    try
                    {
                        await SendEmailAsync(email);
                        await Task.Delay(5000);
                        SuccessCount++;
                    }
                    catch (Exception ex)
                    {
                        FailCount++;
                    }
                }
                MessageBox.Show($"Email Sent to: {SuccessCount} Successfully, and failed: {FailCount}");
            }
            else
            {
                MessageBox.Show("Enter Email or Upload Excel File", "Fail To Send Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
