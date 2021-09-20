using System;

namespace Werter.Learning.Rabbit.Models
{
    public class Letter
    {
        public string Recipient { get; set; }
        public string Sender { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Letter()
        {
        }

        public Letter(string recipient, string sender, string message)
        {
            Date = DateTime.Now;
            Recipient = recipient;
            Sender = sender;
            Message = message;
        }

        public override string ToString() => $"Nova carta: \n" +
                                             $"De: {Sender}. Para: {Recipient}\n" +
                                             $"Data: {Date.ToShortDateString()}\n" +
                                             $"Mensagem: \n{Message}";

    }
}