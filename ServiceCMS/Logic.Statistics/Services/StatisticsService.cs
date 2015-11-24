using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Logic.Common.Models;
using Logging.Interfaces;
using Logic.Statistics.Helpers;
using Logic.Statistics.Interfaces;

namespace Logic.Statistics.Services
{
    public class StatisticsService : IStatisticsService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public StatisticsService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }

        public void AddEntry(StatisticsInformationModel userEntry)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.StatisticInformationRepository.Insert(userEntry.ToEntity());
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
        }

        #region EntriesGetsMethods
        public IList<StatisticsInformationModel> GetUniqueUsers()
        {
            IList<StatisticsInformationModel> statisticsInformationUniqueModels = new List<StatisticsInformationModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get().DistinctBy(x => x.IP);
                    foreach (var entity in entities)
                    {
                        statisticsInformationUniqueModels.Add(new StatisticsInformationModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationUniqueModels;
        }

        public int GetUsersTotalAmount()
        {
            int result = 0;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    result = unitOfWork.StatisticInformationRepository.Get().Count();
                }
                catch (Exception e)
                {
                   _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return result;
        }

        public IList<StatisticsInformationModel> GetAllUsers()
        {
            IList<StatisticsInformationModel> statisticsInformationUniqueModels = new List<StatisticsInformationModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get();
                    foreach (var entity in entities)
                    {
                        statisticsInformationUniqueModels.Add(new StatisticsInformationModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationUniqueModels;
        }
        #endregion
      
        #region BasedOnCountry
        public Dictionary<string, int> GetUsersPerCountry()
        {
            var result = new Dictionary<string, int>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get();
                    result = EntryStatisticsHelper.GetUsersPerCountry(entities);
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return result;
        }
        #endregion

        #region BasedOnTime
        public Dictionary<DateTime, int> GetUsersBetweenDates(DateTime? from, DateTime? to)
        {
            var statisticsInformationBetweenDates = new Dictionary<DateTime, int>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get(BetweenDatesValidationHelper.BetweenDatesValidation(from,to));
                    statisticsInformationBetweenDates = EntryStatisticsHelper.GetUsersForStatistics(entities);
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationBetweenDates;
        }

        public Dictionary<DateTime, int> GetUsersForSelectedMonth(int month, int year)
        {
            var statisticsInformationForSelectedMonth = new Dictionary<DateTime, int>();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get(x => x.Date.Month == month &&
                                                                                      x.Date.Year == year);
                    statisticsInformationForSelectedMonth = EntryStatisticsHelper.GetUsersForStatistics(entities);
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationForSelectedMonth;
        }


        public Dictionary<DateTime, int> GetUsersForEveryMonth(int year)
        {
            var statisticsInformationForEveryMonth = new Dictionary<DateTime, int>();

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get(x => x.Date.Year == year);
                    statisticsInformationForEveryMonth = EntryStatisticsHelper.GetUsersForStatistics(entities);
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationForEveryMonth;
        }

        #endregion

        #region BasedOnActions
        public Dictionary<string, int> GetActionsBetweenDates(DateTime? from, DateTime? to)
        {
            var statisticsInformationBetweenDates = new Dictionary<string, int>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.StatisticInformationRepository.Get(BetweenDatesValidationHelper.BetweenDatesValidation(from, to));
                    statisticsInformationBetweenDates = EntryStatisticsHelper.GetUsersActionsForStatistics(entities);
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return statisticsInformationBetweenDates;
        }
        #endregion
    }
}
