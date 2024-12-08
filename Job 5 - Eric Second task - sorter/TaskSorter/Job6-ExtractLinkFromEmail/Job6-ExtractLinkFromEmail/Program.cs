using System;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Limilabs.Client.IMAP;
using Limilabs.Mail;
using Limilabs.Mail.Headers;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using HtmlAgilityPack;

using Limilabs.Mail.MIME;
using System.Security.Principal;

namespace Job6_ExtractLinkFromEmail
{
    internal class Program
    {
        static string GetLink(string html)
        {
            // Load the HTML content
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Select the anchor tag
            HtmlNode anchorNode = doc.DocumentNode.SelectSingleNode("//a");

            // Extract the link from the anchor tag
            string link = anchorNode.GetAttributeValue("href", null);
            // Print the extracted link
            return link;
        }

        static string ReadSentEmails()
        {
            string IMAP_SERVER_Value = "premium193.web-hosting.com";
            int IMAP_PORT_Value = 993;
            string USERNAME_Value = "catchall@dopeassmail.lat";
            string PASSWORD_Value = "C,gzFEkXz^~3";

            string IMAP_SERVER = IMAP_SERVER_Value;
            int IMAP_PORT = IMAP_PORT_Value;
            string USERNAME = USERNAME_Value;
            string PASSWORD = PASSWORD_Value;
            string emailToSearch = "SN9oQ6z5Tkbl@tomorrowmail.xyz";

            var confirmlink = "No link available.";
            var emailSubject = "CONFIRM YOUR ACCOUNT";
            var counter = 0;

            Console.WriteLine();
            Console.WriteLine("Email Menu:");
            Console.WriteLine("1. View the Link");
            Console.WriteLine("2. Delete the emails");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                CheckEmailAgain:
                    using (Imap imap = new Imap())
                    {
                        // Connect to the IMAP server
                        imap.Connect(IMAP_SERVER, IMAP_PORT, true);

                        // Authenticate with the server
                        imap.Login(USERNAME, PASSWORD);

                        // Select the Sent mailbox
                        imap.SelectInbox();

                        // Note: We will uncomment the below line when we use the licenced version of mail.dll
                        // List<long> uids = imap.Search(Expression.And(Expression.To(emailToSearch),Expression.Subject(emailSubject), Expression.HasFlag(Flag.All)));

                        // Note:  We will comment the below line when we used the licenced version of mail.dll
                        List<long> uids = imap.Search(Expression.And(Expression.Subject("Confirm your account"), Expression.HasFlag(Flag.All)));

                        // Fetch and print the details of each sent email
                        if (uids.Count > 0)
                        {
                            foreach(long uid in uids)
                            {
                                IMail email = new MailBuilder().CreateFromEml(imap.GetMessageByUID(uid));
                                confirmlink = GetLink(email.Html);
                                Console.WriteLine(confirmlink);
                            }
                            
                            imap.Close();
                        }
                        else
                        {
                            if (counter < 5)
                            {
                                counter++;
                                Task.Delay(1000).GetAwaiter().GetResult();
                                imap.Close();
                                goto CheckEmailAgain;
                            }
                            imap.Close();
                        }


                    }
                    return confirmlink;
                case "2":
                    using (Imap imap = new Imap())
                    {
                        // Connect to the IMAP server
                        imap.Connect(IMAP_SERVER, IMAP_PORT, true);

                        // Authenticate with the server
                        imap.Login(USERNAME, PASSWORD);

                        // Select the Sent mailbox
                        imap.SelectInbox();

                        // Note: We will uncomment the below line when we use the licenced version of mail.dll
                        // List<long> uids = imap.Search(Expression.And(Expression.To(emailToSearch),Expression.Subject(emailSubject), Expression.HasFlag(Flag.All)));

                        // Note:  We will comment the below line when we used the licenced version of mail.dll
                        List<long> uids = imap.Search(Expression.And(Expression.Subject("Confirm your account"), Expression.HasFlag(Flag.All)));

                        // Fetch and print the details of each sent email
                        foreach (int emailId in uids)
                        {
                            imap.DeleteMessageByUID(emailId);
                        }
                        imap.Close();
                    }
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            return "";
        }
            
       

        static void Main(string[] args)
        {
          var confirmationLink = ReadSentEmails();
        }
    }
}
