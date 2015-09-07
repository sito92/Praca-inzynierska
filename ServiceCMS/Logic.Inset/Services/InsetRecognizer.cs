using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Common.ConstStrings;
using Logic.Common.Models;
using Logic.Inset.Helpers;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Services
{
    public class InsetRecognizer : IInsetRecognizer
    {
        private char equalChar = '=';
        private IInsetService _insetService;
        private IArgumentValidator _argumentValidator;
        public InsetRecognizer(IInsetService insetService, IArgumentValidator argumentValidator)
        {
            _insetService = insetService;
            _argumentValidator = argumentValidator;
        }
        public bool IsValid(string inset)
        {

            var insetModel = GetInsetModel(inset);

            if (insetModel == null) //check if exists
            {
                return false;
            }
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);

            if (!ContainsAllRequired(arguments, insetModel))
            {
                return false;
            }

            if (!CheckAllArgumentValues(arguments, insetModel))
            {
                return false;
            }


            return true;
        }


        private bool ContainsAllRequired(Dictionary<string,string> arguments, InsetModel model)
        {

            foreach (var argument in model.Arguments)
            {
                if (argument.IsRequierd)
                {
                    var temp = arguments.Where(x => x.Key ==argument.Name);
                    if (!temp.Any())
                    {
                        return false;
                    }
                }

            }
            return true;
            //return model.Arguments.Where(argument => argument.IsRequierd).All(argument => arguments.Contains(argument.Name));
        }

        private bool CheckAllArgumentValues(Dictionary<string,string> arguments, InsetModel model)
        {
            foreach (var argument in arguments)
            {

                var argModel = model.Arguments.FirstOrDefault(x => x.Name == argument.Key);

                if (argModel != null)
                {
                    if (!_argumentValidator.IsValid(argModel.Type, argument.Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public InsetModel GetInsetModel(string inset)
        {
            var insetName = InsetHelper.GetName(inset);

            var insetModel = _insetService.GetByName(insetName);
            return insetModel;
        }
    }
}
