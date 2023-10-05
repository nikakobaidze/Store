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
using System.Security.Cryptography;

namespace Store.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersService UsersService;
        //private readonly StoreSeedData _seedData;
        private readonly StoreEntities _dbContext;

        public LoginController(IUsersService UsersService)
        {
            this.UsersService = UsersService;
            //_seedData = new StoreSeedData();
            _dbContext = new StoreEntities();
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
                //var allUsers = StoreSeedData.GetUsers();
                //var user = allUsers.FirstOrDefault(u => u.UserName == model.UserName);

                var user = _dbContext.Users.FirstOrDefault(u => u.UserName == model.UserName);


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

        private void SendConfirmationEmail(string email, string confirmationLink)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("confirm", "satesto021@gmail.com"));
            message.To.Add(new MailboxAddress("Is that you???", email));
            message.Subject = "Account Confirmation";

            message.Body = new TextPart("plain")
            {
                Text = $"Click the link below to confirm your account: {confirmationLink}"
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

        [HttpPost]
        public ActionResult Register(UserFormViewModel model)
        {
            var isUserFree=true;
            var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserName == model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email address already exists.");
                return View(model);
            }

            var user = new Store.Model.Models.Users()
            {
                UserName = model.Email,
                PassWord = model.Password,
                IsActive = false,
                ConfirmationToken = GenerateToken(),
            };
            foreach (var User in _dbContext.Users)
            {
                if (User.UserName == model.Email)
                {
                    isUserFree = false;
                }
            }
            if (isUserFree)
            {
                UsersService.CreateUser(user);
                UsersService.SaveUser();
            }
            UsersService.CreateUser(user);
            UsersService.SaveUser();

            string confirmationLink = Url.Action("ConfirmEmail", "Login", new { userId = user.ID ,confirmationlink =  user.ConfirmationToken }, Request.Url.Scheme);
            SendConfirmationEmail(model.Email, confirmationLink);

            return View();
        }
        
            public static string GenerateToken(int length = 32)
            {
                const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                byte[] randomBytes = new byte[length];

                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomBytes);
                }

                char[] chars = new char[length];
                int allowedCharCount = allowedChars.Length;

                for (int i = 0; i < length; i++)
                {
                    chars[i] = allowedChars[randomBytes[i] % allowedCharCount];
                }

                return new string(chars);
            }
        

        [HttpGet]
        public ActionResult ConfirmEmail(int userId,string token)
        {
            var user = UsersService.GetUser(userId);

            if (user != null && UsersService.VerifyConfirmationToken(userId,token))
            {
                user.IsActive = true;
                UsersService.UpdateUser(user);
                UsersService.SaveUser();

                return RedirectToAction("Login");
            }

            // Handle invalid user or other error scenario
            return View("Home/Index");
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
                return RedirectToAction("Index", "Home");

            }

            // Redirect to a confirmation error page or display an error message
            return RedirectToAction("ConfirmationError");
        }  
    }
}