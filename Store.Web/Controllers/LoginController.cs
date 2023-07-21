using DocumentFormat.OpenXml.Vml;
using MailKit.Net.Pop3;
using MimeKit;
using Store.Data;
using Store.Service;
using Store.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Services.Description;
using MailKit.Net.Smtp;
namespace Store.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersService UsersService;
        private readonly StoreSeedData _seedData;




        public LoginController(IUsersService UsersService)
        {
            this.UsersService = UsersService;
            _seedData = new StoreSeedData();
        }



        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Login(UserFormViewModel model)
        {

            if (ModelState.IsValid)
            {

                var allUsers = StoreSeedData.GetUsers();
                var user = allUsers.FirstOrDefault(u => u.UserName == model.UserName);
                //var userid=user.ID
                //var Allroles=StoreSeedData.GetRoles();
                //var role=Allroles.Where(x =>x.ID==user.ID);
                //var Allmenu=StoreSeedData.GetMenus();
                //var menu=Allmenu.Where(x =>x.ID==user.ID);

                if (user != null && model.Password == user.PassWord)
                {
                    Session["IsLoggedIn"] = true;
                    //ViewBag.UserMenus=menu;
                    Session["UserID"] = user.ID;
                    return RedirectToAction("Index", "Home");

                }

            }


            return View();

        }
        //private void SendConfirmationEmail(string email, string confirmationLink)
        //{
        //    string subject = "Account Confirmation";
        //    string body = $"Click the link below to confirm your account: {confirmationLink}";
        //    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


        //        using (var smtpClient = new SmtpClient("smtp.gmail.com", 25)) // Replace with your SMTP server details
        //        {
        //            smtpClient.Credentials = new NetworkCredential("satesto021@gmail.com", "gltsractnuxoeult"); // Replace with your SMTP credentials
        //            smtpClient.EnableSsl = true;
        //            smtpClient.UseDefaultCredentials = false;
        //            smtpClient.Send(new MailMessage(from: "satesto021@gmail.com",
        //                to:"facacialado@gmail.com",
        //                subject:"test","test"));
        //        }

        //}

        //private void SendConfirmationEmail(string email, string confirmationLink)
        //{
        //    string subject = "Account Confirmation";
        //    string body = $"Click the link below to confirm your account: {confirmationLink}";

        //    using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
        //    {
        //        smtpClient.Credentials = new NetworkCredential("satesto021@gmail.com", "gltsractnuxoeult");
        //        smtpClient.EnableSsl = true; // Enable SSL/TLS encryption
        //        smtpClient.UseDefaultCredentials = false;

        //        // Send the email
        //        smtpClient.Send(new MailMessage(from: "satesto021@gmail.com",
        //                                        to: email,
        //                                        subject: subject,
        //                                        body: body));
        //    }
        //}
        private void SendConfirmationEmail(string email, string confirmationLink)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "satesto021@gmail.com"));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "nika.kobaidze921@gmail.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
            };
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com",465, true);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("satesto021@gmail.com", "gltsractnuxoeult");

                client.Send(message);
                client.Disconnect(true);
            }
        }
            


        [HttpPost]
        public ActionResult LogOut(UserFormViewModel model)
        {
            //FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            // Redirect to a page or action after logout
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //private void SendConfirmationEmail(string email, string confirmationLink)
        //{
        //    #region comment
        //    MailMessage msg = new MailMessage("smtp.gmail.com", "nika.kobaidze921@gmail.com");

        //    msg.From = new MailAddress("satesto021@gmail.com");
        //    msg.To.Add("nika.kobaidze921@gmail.com");
        //    msg.Subject = "test";
        //    msg.Body = "Test Content";
        //    //msg.Priority = MailPriority.High;


        //    using (SmtpClient client = new SmtpClient())
        //    {
        //        client.EnableSsl = true;
        //        client.Credentials = new NetworkCredential("satesto021@gmail.com", "testmail12");
        //        client.UseDefaultCredentials = false;
        //        client.Host = "smtp.gmail.com";
        //        client.Port = 465;
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //        client.Send(msg);
        //    }
        //    #endregion

        //    // var mail = "satesto021@gmail.com";
        //    // var password = "testmail12";
        //    // var client = new SmtpClient("smtp.gmail.com", 465)
        //    // {
        //    //     EnableSsl = true,
        //    //     Credentials = new NetworkCredential(mail, password)
        //    // };
        //    //await client.SendMailAsync(new MailMessage(from: mail,
        //    //                                      to: "facacialado@gmail.com",
        //    //                                      "test", "test"));

        //}




        [HttpPost]
        public ActionResult Register(UserFormViewModel model)
        {
            var user = new Store.Model.Models.Users()
            {
                UserName = model.Email,
                PassWord = model.Password,
                IsActive = false,
            };

            UsersService.CreateUser(user);
            UsersService.SaveUser();


            string confirmationLink = Url.Action("ConfirmEmail", "Login", new { userId = user.ID }, Request.Url.Scheme);
            SendConfirmationEmail(model.Email, confirmationLink);


            //var confirmationToken = Guid.NewGuid().ToString();
            //UsersService.SaveConfirmationToken((int)user.ID, confirmationToken);

            //var confirmationLink = Url.Action("ConfirmAccount", "Login", new { userId = user.ID, token = confirmationToken }, Request.Url.Scheme);

            //SendConfirmationEmail(user.UserName, confirmationLink);

            //return RedirectToAction("ConfirmationSent");



            //if (ModelState.IsValid)
            //{
            //    // Create a new user object
            //    var user = new Users()
            //    {
            //        UserName = model.UserName,
            //        PassWord = model.Password,
            //        // Set other properties as needed
            //    };

            //    // Save the user to the database or your data store
            //    UsersService.CreateUser(user);
            //    UsersService.SaveUser();
            //    // Generate a unique confirmation token
            //    var confirmationToken = Guid.NewGuid().ToString();

            //    // Save the confirmation token and user email to the database or your data store
            //    UsersService.SaveConfirmationToken(savedUser.ID, confirmationToken);

            //    // Construct the confirmation link URL
            //    var confirmationLink = Url.Action("ConfirmAccount", "Login", new { userId = savedUser.ID, token = confirmationToken }, Request.Url.Scheme);

            //    // Send the confirmation email
            //    SendConfirmationEmail(savedUser.Email, confirmationLink);

            //    // Redirect the user to a confirmation page or display a success message
            //    return RedirectToAction("ConfirmationSent");
            //}
            return View();
        }

        [HttpGet]
        public ActionResult ConfirmEmail(int userId)
        {
            var user = UsersService.GetUser(userId);
            if (user != null)
            {
                user.IsActive = true;
                UsersService.UpdateUser(user);
                UsersService.SaveUser();

                return RedirectToAction("Login");
            }

            // Handle invalid user or other error scenario
            return View("Error");
        }

        [HttpGet]
        public ActionResult ConfirmAccount(int userId, string token)
        {
            // Retrieve the user from the database using the userId
            var user = UsersService.GetUser(userId);

            // Check if the user exists and the token is valid
            if (user != null && UsersService.VerifyConfirmationToken(userId, token))
            {
                // Activate the user account
                user.IsActive = true;
                UsersService.UpdateUser(user);
                UsersService.SaveUser();

                // Redirect to a confirmation success page or display a success message
                return RedirectToAction("ConfirmationSuccess");
            }

            // Redirect to a confirmation error page or display an error message
            return RedirectToAction("ConfirmationError");
        }



    }
}