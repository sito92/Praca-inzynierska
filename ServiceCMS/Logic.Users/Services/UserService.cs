using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.User.Interfaces;

namespace Logic.User.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public UserService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public UserModel GetById(int id)
        {
            UserModel userModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.UserRepository.GetByID(id);
                    if (entity != null)
                    {
                        userModel = new UserModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return userModel;
        }
        public UserModel GetByLogin(string login)
        {
            UserModel userModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.UserRepository.Get(x=>x.Login==login).FirstOrDefault();
                    if (entity != null)
                    {
                        userModel = new UserModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return userModel;
        }

        public IList<UserModel> GetAll()
        {
            IList<UserModel> userModels = new List<UserModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.UserRepository.Get();
                    foreach (var entity in entities)
                    {
                        userModels.Add(new UserModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return userModels;
        }


        public ResponseBase Insert(UserModel user)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (user != null)
                    {
                        unitOfWork.UserRepository.Insert(user.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.SaveUserSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.SaveUserFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(UserModel user)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (user != null)
                    {
                        unitOfWork.UserRepository.Update(user.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ModifyUserSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ModifyUserFailed };
                }
            }
            return response;
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.UserRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase()
                    {
                        IsSucceed = true,
                        Message = Modules.Resources.Logic.RemoveUserSuccess
                    };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase()
                    {
                        IsSucceed = false,
                        Message = Modules.Resources.Logic.RemoveUserFailed
                    };
                }
            }
            return response;
        }
    }
}
