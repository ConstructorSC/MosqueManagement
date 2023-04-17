using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MosqueManagement.Data;
using MosqueManagement.ViewModels;
using MosqueManagement.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace MosqueManagement.Controllers
{
    public class UserController : Controller
    {

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
            string validemail = "constructor@gmail.com";
            string validpassword = "constructor123";
            var user = "";
            bool passwordCheck = false;
            if (loginViewModel?.EmailAddress == validemail)
            {
                user = validemail;
            }
            
            if (user != "")
            {
                //User is found, check password
                if(loginViewModel.Password == validpassword)
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
        
        /*
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        */
    }
}
