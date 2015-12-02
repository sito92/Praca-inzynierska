using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.MenuButton.Interfaces;

namespace Logic.MenuButton.Services
{
    public class MenuButtonService : IMenuButtonService
    {

        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public MenuButtonService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        public MenuButtonModel GetById(int id)
        {
            MenuButtonModel menuButtonModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.MenuButtonRepository.GetByID(id);
                    if (entity != null)
                    {
                        menuButtonModel = new MenuButtonModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return menuButtonModel;
        }

        public IList<MenuButtonModel> GetAll()
        {
            IList<MenuButtonModel> menuButtonModels = new List<MenuButtonModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.MenuButtonRepository.Get();
                    foreach (var entity in entities)
                    {
                        menuButtonModels.Add(new MenuButtonModel(entity));
                    }

                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return menuButtonModels;
        }

        public ResponseBase Insert(MenuButtonModel menuButton)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (menuButton != null)
                    {
                        unitOfWork.MenuButtonRepository.Insert(menuButton.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.MenuButtonInsertSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.MenuButtonInsertFailed };
                }
                return response;
            }
        }

        public ResponseBase Update(MenuButtonModel menuButton)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (menuButton != null)
                    {
                        unitOfWork.MenuButtonRepository.Update(menuButton.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.MenuButtonUpdateSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.MenuButtonUpdateFailed };
                }
                return response;
            }

        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var button = new MenuButtonModel(unitOfWork.MenuButtonRepository.GetByID(id));
                    var children = GetChildButtons(button);
                    if (children != null)
                    {
                        foreach (var child in children)
                        {
                            unitOfWork.MenuButtonRepository.Delete(child.Id);
                        }
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.MenuButtonDeleteSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.MenuButtonDeleteFailed };
                }
            }
            return response;
        }

        private List<MenuButtonModel> GetChildButtons(MenuButtonModel parentButton)
        {
            List<MenuButtonModel> Buttons = new List<MenuButtonModel>();
            Stack<MenuButtonModel> BranchButtons = new Stack<MenuButtonModel>();
            var rootButton = parentButton;
            BranchButtons.Push(rootButton);

            while (BranchButtons.Count > 0)
            {
                using (var unitOfWork = _unitOfWorkFactory.Create())
                {
                    var button = BranchButtons.Pop();
                    Buttons.Add(button);
                    var childrenNodes =
                        unitOfWork.MenuButtonRepository.Get(x => x.ParentId == button.Id);
                    if (childrenNodes.Any())
                    {
                        foreach (var node in childrenNodes)
                        {
                            BranchButtons.Push(new MenuButtonModel(node));
                        }
                    }
                }
            }
            return Buttons;

        }
    }
}
