﻿using System.Threading.Tasks;

namespace BookManager.Services.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string message);
    }
}