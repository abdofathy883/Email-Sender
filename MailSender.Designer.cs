namespace Email_Sender
{
    partial class MailSender
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EmailInput = new TextBox();
            MailFileDialog = new OpenFileDialog();
            label1 = new Label();
            SendBtn = new Button();
            BrowseBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            MailsFromExcel = new ListBox();
            SuspendLayout();
            // 
            // EmailInput
            // 
            EmailInput.Location = new Point(38, 95);
            EmailInput.Name = "EmailInput";
            EmailInput.Size = new Size(357, 23);
            EmailInput.TabIndex = 0;
            // 
            // MailFileDialog
            // 
            MailFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(38, 68);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 1;
            label1.Text = "Sen Individual Email";
            // 
            // SendBtn
            // 
            SendBtn.Location = new Point(38, 220);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(353, 29);
            SendBtn.TabIndex = 2;
            SendBtn.Text = "Send";
            SendBtn.UseVisualStyleBackColor = true;
            SendBtn.Click += SendBtn_Click;
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new Point(38, 159);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(113, 27);
            BrowseBtn.TabIndex = 3;
            BrowseBtn.Text = "Browse";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(38, 138);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 4;
            label2.Text = "Send Bulk Emails in Excel File";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(38, 189);
            label3.Name = "label3";
            label3.Size = new Size(268, 13);
            label3.TabIndex = 5;
            label3.Text = "Make sure the file have column with header 'Email'";
            // 
            // MailsFromExcel
            // 
            MailsFromExcel.FormattingEnabled = true;
            MailsFromExcel.Location = new Point(426, 95);
            MailsFromExcel.Name = "MailsFromExcel";
            MailsFromExcel.Size = new Size(179, 154);
            MailsFromExcel.TabIndex = 6;
            // 
            // MailSender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(160, 137, 99);
            ClientSize = new Size(651, 323);
            Controls.Add(MailsFromExcel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(BrowseBtn);
            Controls.Add(SendBtn);
            Controls.Add(label1);
            Controls.Add(EmailInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MailSender";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Email Sender";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EmailInput;
        private OpenFileDialog MailFileDialog;
        private Label label1;
        private Button SendBtn;
        private Button BrowseBtn;
        private Label label2;
        private Label label3;
        private ListBox MailsFromExcel;
    }
}
