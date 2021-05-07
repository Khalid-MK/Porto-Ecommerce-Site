using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ITI.CEI.Core.Porto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ITI.CEI.Core.Porto.Data;
using System.ComponentModel.DataAnnotations.Schema;
using ITI.CEI.Core.Porto.Core;
//using Microsoft.AspNet.Identity.EntityFramework;

namespace ITI.CEI.Core.Porto.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "E-mail Address")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [NotMapped]
            public string RoleTitle { get; set; }

        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    // to roles and defualt values
                    #region Roles

                    var roleResult2 = await _roleManager.RoleExistsAsync("Shop_Owner");
                    if (!roleResult2)
                    {
                        // Second we create Shop_Owner role    
                        var role2 = new IdentityRole("Shop_Owner");
                        await _roleManager.CreateAsync(role2);


                        var roleResult = await _roleManager.RoleExistsAsync("Admin");
                        if (!roleResult)
                        {
                            // first we create Admin role    
                            var role = new IdentityRole("Admin");
                            await _roleManager.CreateAsync(role);
                            var result1 = await _userManager.AddToRoleAsync(user, "Admin");

                            ////////////////////////////////////////////////////////////////////////////////

                            ////Here we create a Admin super user who will maintain the website  
                            //var AppAdmin = new ApplicationUser();
                            //AppAdmin.UserName = "Admin";
                            //AppAdmin.Email = "admin@porto.com";
                            //string userPWD = "P@ssw00rd";

                            //IdentityResult chkUser = await _userManager.CreateAsync(AppAdmin, userPWD);

                            ////Add default User to Role Admin    
                            //if (chkUser.Succeeded)
                            //{
                            //    var result1 = await _userManager.AddToRoleAsync(AppAdmin, "Admin");
                            //}

                            ////////////////////////////////////////////////////////////////////////////////


                            // add default payment types 
                            List<string> paymentTypesTitles = new List<string>()
                            {
                                "Cheque Payment",
                                "Paypal",
                                "Visa",
                                "Mastercard",
                                "On Dilivery",
                                "Direct Bank Transfare"
                            };

                            foreach (var title in paymentTypesTitles)
                            {
                                PaymentType paymentType = new PaymentType() { Title = title };
                                _unitOfWork.PaymentTypeManager.Add(paymentType);
                            }


                            // add default categories
                            List<string> categoriesTitles = new List<string>()
                            {
                                "Arts & Crafts",
                                "Automotive",
                                "Baby",
                                "Books",
                                "Eletronics",
                                "Women's Fashion",
                                "Men's Fashion",
                                "Health & Household",
                                "Home & Kitchen",
                                "Military Accessories",
                                "Movies & Television",
                                "Sports & Outdoors",
                                "Tools & Home Improvement",
                                "Toys & Games",
                                "Others"
                            };

                            foreach (var title in categoriesTitles)
                            {
                                Category category = new Category() { Name = title };
                                _unitOfWork.CategoryManager.Add(category);
                            }
                        }

                    }
                    else
                    {
                        if (Input.RoleTitle == "Shop_Owner")
                        {
                            var res = await _userManager.AddToRoleAsync(user, "Shop_Owner");
                        }
                    }



                    //if (Input.RoleTitle == "Shop_Owner")
                    //{
                    //    var res = await _userManager.AddToRoleAsync(user, "Shop_Owner");
                    //}

                    /// commented lines for creating super admin by defualt
                    /// but now first user will be super admin

                    #endregion





                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
