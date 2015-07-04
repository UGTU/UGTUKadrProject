using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Net.Mime;
namespace APG.CodeHelper
{
    public partial class SMTPHelper
    {
        public SMTPHelper()
        {
            MailObject = new MailMessage();
            mMailFrom = "";
            mMailTo = "";
            mMailSubject = "";
            mMailBody = "";
            mSMTPServer = "";
            mSMTPPort = 25;
            mSMTPUsername = "";
            mSMTPPassword = "";
            mSMTPSSL = false;
            mSendAsync = false;
            mTryAgianOnFailure = true;
            mTryAgainDelayTime = 10000;   
        }

        
        private string mMailFrom;
        private string mMailTo;
        private string mMailSubject;
        private string mMailBody;
        private string mSMTPServer;
        private int mSMTPPort;
        private string mSMTPUsername;
        private string mSMTPPassword;
        private bool mSMTPSSL;
        private MailMessage MailObject;
        private bool mSendAsync;
        private bool mTryAgianOnFailure;
        private int mTryAgainDelayTime;

        // Properties
        public string MailFrom 
        { 
            set { mMailFrom = value; } 
            get { return mMailFrom; }
        }
        public string MailTo 
        {
            set { mMailTo = value; }
            get { return mMailTo; }
        }
        public string MailSubject 
        { 
            set { mMailSubject = value; }
            get { return mMailSubject; }
        }
        public string MailBody 
        { 
            set { mMailBody = value; }
            get { return mMailBody; }
        }
        public string SMTPServer 
        {
            set { mSMTPServer = value; } 
            get { return mSMTPServer; }
        }
        public int SMTPPort 
        { 
            set { mSMTPPort = value; }
            get { return mSMTPPort; }
        }
        public string SMTPUsername 
        {
            set { mSMTPUsername = value; }
            get { return mSMTPUsername; }
        }
        public string SMTPPassword 
        {
            set { mSMTPPassword = value; }
            get { return mSMTPPassword; } 
        }
        public bool SMTPSSL 
        { 
            set { mSMTPSSL = value; } 
            get { return mSMTPSSL; }
        }
        public bool SendAsync 
        { 
            set { mSendAsync = value; } 
            get { return mSendAsync; } 
        }
        public bool TryAgianOnFailure 
        { 
            set { mTryAgianOnFailure = value; }
            get { return mTryAgianOnFailure; } 
        }
        public int TryAgainDelayTime 
        { 
            set { mTryAgainDelayTime = value; }
            get { return mTryAgainDelayTime; }
        }
        private string dataFile;

        public string DataFile
        {
            get { return dataFile; }
            set { dataFile = value; }
        }
        
        
        public Boolean Send()
        {
            // Создаем сам месседж
            MailMessage Email = new MailMessage();
            
            MailAddress MailFrom = new MailAddress(mMailFrom, mMailFrom);
            Email.From = MailFrom;
            Email.To.Add(mMailTo);
            Email.BodyEncoding = Encoding.UTF8;
            Email.Subject = mMailSubject;
            Email.Body = mMailBody;
            if (File.Exists(dataFile))
            {
                Attachment data = new Attachment(dataFile, MediaTypeNames.Application.Octet);
                Email.Attachments.Add(data);
            }
            
            // СМТП клинет
            SmtpClient SmtpMail = new SmtpClient(mSMTPServer, mSMTPPort);
            SmtpMail.Credentials = new NetworkCredential(mSMTPUsername, mSMTPPassword);
            SmtpMail.EnableSsl = mSMTPSSL;

            Boolean bTemp = true;

            try
            {
                string sTemp = "";
                if (mSendAsync)
                    SmtpMail.SendAsync(Email, sTemp);
                else
                    SmtpMail.Send(Email);
            }
            catch (SmtpFailedRecipientsException e)
            {
                for (int k = 0; k < e.InnerExceptions.Length; k++)
                {
                    bTemp = false;

                    SmtpStatusCode StatusCode = e.InnerExceptions[k].StatusCode;
                    if (StatusCode == SmtpStatusCode.MailboxUnavailable ||
                        StatusCode == SmtpStatusCode.MailboxBusy)
                    {
                        try
                        {
                            if (mTryAgianOnFailure)
                            {
                                Thread.Sleep(mTryAgainDelayTime);
                                //Посылается собщение
                                string sTemp = "";
                                if (mSendAsync)
                                    SmtpMail.SendAsync(Email, sTemp);
                                else
                                    SmtpMail.Send(Email);
                                // Сообщение отослано
                                bTemp = true;

                            }
                        }
                        catch { bTemp = false; }
                    }
                }
            }
            return bTemp;
        }
    }
}
