using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logic.Inset.Helpers;
using Logic.User.Interfaces;

namespace Logic.Inset.Parsers
{
    class UserParser:Parser
    {
        private string id = "id";
        private IUserService _userService;
        public UserParser(IUserService userService)
        {
            _userService = userService;
        }
        public override string Tag
        {
            get { return "p"; }
        }

        public override string Parse(string inset)
        {
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);
            var idData = int.Parse(arguments[id]);

            var userModel = _userService.GetById(idData);
            if (userModel==null)
            {
                return inset;
            }

            ParserTagBuilder.SetInnerText(userModel.Login);
            ParserTagBuilder.AddCssClass("text-success");

            return ParserTagBuilder.ToString();


        }
    }
}
