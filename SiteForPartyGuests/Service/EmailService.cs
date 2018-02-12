using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using SiteForPartyGuests.Models;

namespace SiteForPartyGuests.Service
{
    public class EmailService
    {
        private SmtpClient _smtpClient;
        private const string _login = "gym550182@gmail.com";
        private const string _pass = "!QAZ2wsx#EDC";

        public EmailService()
        {
            Initialize();
        }

        private void Initialize()
        {
            _smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_login, _pass)
            };
        }

        public MailMessage CreateMailMessage(Form mailModel, bool isDefault = false)
        {
            var message=  new MailMessage()
            {
                Sender = new MailAddress(_login),
                From = new MailAddress(_login),
                To = { mailModel.Email },
                Subject = "Thaks for Confirmation",
                Body = "Dzieki",
                IsBodyHtml = true
            };

            if (isDefault) return message;
            message.To.Add((_login));
            message.Subject = "Ktos potwierdził";
            message.Body = $"{mailModel.Surname} potwierdził przybycie";
            return message;

        }



        public void SendEmail(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
            
        }
    }
}