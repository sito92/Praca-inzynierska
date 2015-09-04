using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class AccountController : BaseController
    {
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LandingPageViewModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _userService.GetByLogin(model.LandingPageLogin);
        //        if (user != null)
        //        {
        //            if (_passwordManager.IsPasswordMatch(model.LandingPagePassword, user.Salt, user.PasswordHash))
        //            {
        //                if (user.Email == null)
        //                {
        //                    TempData[SessionKeys.USER_VIEW_MODEL] = new UserViewModel(user);
        //                    return RedirectToAction("Register", "User");
        //                }
        //                else
        //                {
        //                    FormsAuthentication.SetAuthCookie(user.Login, model.LandingPageRememberMe);
        //                    user.LastLoginDate = DateTime.Now;
        //                    user.LoginsCount += 1;
        //                    _userService.Update(user);
        //                    _sessionManager.Set(SessionKeys.USER_VIEW_MODEL, new UserViewModel(user));
        //                    return RedirectToAction("Welcome", "Home");
        //                }
        //            }
        //        }
        //        TempData[SessionKeys.FAILED_MESSAGE] = Presentation.LoginOrPasswordInvalid;
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    _sessionManager.Remove(SessionKeys.USER_VIEW_MODEL);
        //    FormsAuthentication.SignOut();

        //    return RedirectToAction("Index", "Home");
        //}

        

        //#region Helpers
        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}
        //#endregion

    }
}
