using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.ConstStrings;
using Common.Interfaces;
using Common.Managers;
using Logic.Common.Models;

namespace AdminPanel.Attributes
{
    public class ServiceCMSAuthorizeAttribute:AuthorizeAttribute
    {

        private readonly ISessionManager _sessionManager;

        public ServiceCMSAuthorizeAttribute(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = _sessionManager.Get<UserModel>(SessionKeys.USER_VIEW_MODEL);
            return user != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}