using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.ViewModels;
using MosqueManagement.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Microsoft.AspNet.Identity;
using System.Net.Mail;

namespace MosqueManagement.Controllers
{
    public class UserController : Controller
    {
        private static bool emailValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        // register function
        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            // Assert that the response object is not null
            Contract.Assert(response != null, "response object must not be null");

            // Invariant that the response object is valid
            Contract.Invariant(response != null, "response object must not be null");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            // Precondition: registerViewModel must not be null
            Contract.Requires(registerViewModel != null, "LoginViewModel is null");

            // Invariant that the email address is valid
            Contract.Invariant(emailValid(registerViewModel.EmailAddress), "Email entered is not valid");
            bool dupemail = false;
            if(HttpContext.Session.GetString("email") == registerViewModel.EmailAddress)
            {
                dupemail = true;
            }
            // Assert that the email not exist
            Contract.Assert(dupemail != true, "This email address is already in use");
            if (dupemail)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }

            if (!ModelState.IsValid)
            {
                // Invariant: ModelState.IsValid should be true when registerViewModel is valid
                Contract.Invariant(false, "ModelState.IsValid is false when registerViewModel is valid");
                return View(registerViewModel);
            }
            HttpContext.Session.SetString("email", registerViewModel.EmailAddress);
            HttpContext.Session.SetString("password", registerViewModel.Password);

            // Postcondition: the action should redirect to the Index page of the Race controller
            Contract.Ensures(this.ControllerContext.RouteData.Values["controller"].ToString() == "User", "Action does not redirect to User/Index");
            Contract.Ensures(this.ControllerContext.RouteData.Values["action"].ToString() == "Index", "Action does not redirect to User/Index");

            return RedirectToAction("Login", "User");
        }

        // login function
        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            // Assert that the response object is not null
            Contract.Assert(response != null, "response object must not be null");
          
            // Invariant that the response object is valid
            Contract.Invariant(response != null, "response object must not be null");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // Precondition: LoginViewModel must not be null
            Contract.Requires(loginViewModel != null, "LoginViewModel is null");

            if (!ModelState.IsValid)
            {
                // Invariant: ModelState.IsValid should be true when LoginViewModel is valid
                Contract.Invariant(false, "ModelState.IsValid is false when LoginViewModel is valid");
                return View(loginViewModel);
            }

            bool emailCheck = false;
            bool passwordCheck = false;
            string validemail = HttpContext.Session.GetString("email");
            string validpassword = HttpContext.Session.GetString("password");
            if (loginViewModel?.EmailAddress == validemail)
            {
                emailCheck = true;
            }
            
            if (emailCheck)
            {
                //User is found, check password
                if(loginViewModel.Password == validemail)
                {
                    passwordCheck = true;
                }
                if (passwordCheck)
                {
                    //Password correct, sign in
                        // Postcondition: the action should redirect to the Index page of the User controller
                        Contract.Ensures(this.ControllerContext.RouteData.Values["controller"].ToString() == "User", "Action does not redirect to User/Index");
                        Contract.Ensures(this.ControllerContext.RouteData.Values["action"].ToString() == "Index", "Action does not redirect to User/Index");
                        return RedirectToAction("Index", "Home");
                }

                //Password is incorrect
                TempData["Error"] = "Wrong credentials. Please try again";

                // Invariant: TempData["Error"] should not be null or empty
                Contract.Invariant(!string.IsNullOrEmpty(TempData["Error"] as string), "TempData[\"Error\"] is null or empty");
                return View(loginViewModel);
            }

            //User not found
            TempData["Error"] = "User not found";

            // Invariant: TempData["Error"] should not be null or empty
            Contract.Invariant(!string.IsNullOrEmpty(TempData["Error"] as string), "TempData[\"Error\"] is null or empty");
            return View(loginViewModel);
            
        }
        
        // logout function
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }
        
    }
}
