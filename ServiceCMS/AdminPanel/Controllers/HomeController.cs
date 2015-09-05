using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AdminPanel.Attributes;
using AdminPanel.Models.User;
using Common.ConstStrings;
using Common.Interfaces;
using Logic.Common.Models;
using Logic.User.Interfaces;

namespace AdminPanel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ISessionManager _sessionManager;
        public HomeController(ISessionManager sessionManager, IUserService userService)
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }
        public ActionResult Index()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                var userName = ticket.Name;

                var userViewModel = _userService.GetByLogin(userName);
                _sessionManager.Set(SessionKeys.USER_VIEW_MODEL, userViewModel);

                return RedirectToAction("Welcome");
            }

            return RedirectToAction("Login", "Account");
        }
        
        public ActionResult Welcome()
        {
            var model = new AuthenticatedViewModel()
            {
                User = _sessionManager.Get<UserModel>(SessionKeys.USER_VIEW_MODEL)
            };
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
