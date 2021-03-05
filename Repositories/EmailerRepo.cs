using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using PeaceHotelAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Repositories
{
    public class EmailerRepo : IEmailer
    {
        public string SendEmailToAdmin(Room bookRoom)
        {
            string adminEmail = "admin@peacehotel.com";
            string subject = "Room Booking Notification at Peace Hotel";
            string senderEmail = "emailserver@peacehotel.com";
            string password = "*****";
            string messageBody = $"Client has successfully booked room " + bookRoom.RoomNo;

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")//173.194.76.108
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, password),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = messageBody
                };
                mailMessage.To.Add(adminEmail);

                smtpClient.Send(mailMessage);
                return "sent";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string SendEmailToClient(ClientCreateDto client)
        {
            string subject = "Room Booking Notification at Peace Hotel";
            string senderEmail = "emailserver@peacehotel.com";
            string password = "*****";
            string messageBody = "This is to notify you have successfully registered at Peace Hotel";

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")//173.194.76.108
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, password),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = messageBody
                };
                mailMessage.To.Add(client.Email);

                smtpClient.Send(mailMessage);
                return "sent";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

    }
}
