using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdminPanel.Models.User;
using Common.ConstStrings;
using Common.Interfaces;
using Logic.User.Interfaces;
using Modules.Cryptography.Interfaces;
using Modules.Resources;

namespace AdminPanel.Controllers
{
    public class AccountController : BaseController
    {
        private IUserService _userService;
        private IPasswordManager _passwordManager;
        private ISessionManager _sessionManager;
        public AccountController(IUserService userService,IPasswordManager passwordManager,ISessionManager sessionManager)
        {
            _userService = userService;
            _passwordManager = passwordManager;
            _sessionManager = sessionManager;
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByLogin(model.LandingPageLogin);
                if (user != null)
                {
                    if (_passwordManager.IsPasswordMatch(model.LandingPagePassword, user.Salt, user.Password))
                    {
                       
                            FormsAuthentication.SetAuthCookie(user.Login, model.LandingPageRememberMe);

                            _sessionManager.Set(SessionKeys.USER_VIEW_MODEL,user);
                            return RedirectToAction("Welcome", "Home");
                        
                    }
                }

            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            _sessionManager.Remove(SessionKeys.USER_VIEW_MODEL);
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }



        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

    }
}
