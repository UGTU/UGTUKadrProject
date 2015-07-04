using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper
{
    public class MAPIHelper
    {
        /// <summary>
        /// Отправляет сообщение через клиент Outlook
        /// </summary>
        /// <param name="fileName">Полный путь к файлу</param>
        /// <param name="displayFileName">Отображаемое имя файла</param>
        /// <param name="messageBody">Текст сообщения</param>
        /// <param name="messageSubj">Тема сообщения</param>
        /// <param name="EMailAddress">Адрес сообщения</param>
        public static bool SendMAPIMessage(string fileName, string displayFileName, string messageBody, string messageSubj, string EMailAddress)
        {
            bool result = false;

            try
            {
                //// Command line argument must the the SMTP host.
                //SmtpClient client = new SmtpClient(args[0]);
                //// Specify the e-mail sender.
                //// Create a mailing address that includes a UTF8 character
                //// in the display name.
                //System.Net.Mail.MailAddress from = 
                //    new System.Net.Mail.MailAddress(Properties.Settings.Default.ClientEMailAddress,
                //    Properties.Settings.Default.EMailUserName, System.Text.Encoding.UTF8);
                
                //// Set destinations for the e-mail message.
                //MailAddress to = new MailAddress(Properties.Settings.Default.DaylyReportEMail);
                
                //// Specify the message content.
                //MailMessage message = new MailMessage(from, to);
                //    message.Subject = "test message 1" + someArrows;
               
                //message.SubjectEncoding = System.Text.Encoding.UTF8;
                //// Set the method that is called back when the send operation ends.
                //client.SendCompleted += new
                //SendCompletedEventHandler(SendCompletedCallback);
                //// The userState can be any object that allows your callback 
                //// method to identify this send operation.
                //// For this example, the userToken is a string constant.
                //string userState = "test message1";
                //client.SendAsync(message, userState);
                //Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
                //string answer = Console.ReadLine();
                //// If the user canceled the send, and mail hasn't been sent yet,
                //// then cancel the pending operation.
                //if (answer.StartsWith("c") && mailSent == false)
                //{
                //    client.SendAsyncCancel();
                //}
                //// Clean up.
                //message.Dispose();
                //Console.WriteLine("Goodbye.");

            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                System.Windows.Forms.MessageBox.Show
                   (
                   "Отправка сообщения окончилась неудачей. Тескт ошибки:\n" + e.Message,
                   "Ошибка отправки сообщения",
                   System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Exclamation
                   );
            }
            return result;

        }

    }
}
