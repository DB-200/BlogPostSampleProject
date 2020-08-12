using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@somewhere.com";
        private string _mailFrom = "me@mycompany.com";

        public void Send(string subject, string message)
        {
            // mock email
            Debug.WriteLine("");
            Debug.WriteLine("New Email! (CloudMailService)");
            Debug.WriteLine($"From: {_mailFrom} To: {_mailTo} Date: {DateTime.Now}");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
            Debug.WriteLine("");
        }
    }
}
