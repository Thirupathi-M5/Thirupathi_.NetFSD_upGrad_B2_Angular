using System;

namespace Solids
{
    // Interface
    public interface INotification
    {
        void Send(string message);
    }

    // Email Notification
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email: " + message);
        }
    }

    // SMS Notification
    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS: " + message);
        }
    }

    // Push Notification
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification: " + message);
        }
    }

    // Factory Class
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                case "push":
                    return new PushNotification();
                default:
                    throw new Exception("Invalid notification type");
            }
        }
    }

    //  (Main Execution)
    internal class FactoryPattern
    {
        public static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            // Create and use notifications
            INotification notification;

            notification = factory.CreateNotification("email");
            notification.Send("Welcome to our service!");

            notification = factory.CreateNotification("sms");
            notification.Send("Your OTP is 1234");

            notification = factory.CreateNotification("push");
            notification.Send("You have a new alert!");

            Console.ReadLine();
        }
    }
}