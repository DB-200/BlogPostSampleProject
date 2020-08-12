using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private string _mailTo = "";
        private string _mailFrom = "";

        public LocalMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(LocalMailService));
            _mailFrom = _configuration["mailSettings:mailFromAddress"];
            _mailTo = _configuration["mailSettings:mailToAddress"];
        }

        public void Send(string subject, string message)
        {
            // mock email
            Debug.WriteLine("");
            Debug.WriteLine("New Email! (LocalMailService)");
            Debug.WriteLine($"From: {_mailFrom} To: {_mailTo} Date: {DateTime.Now}");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
            Debug.WriteLine("");
        }
    }
}


