using DAL.Models;
using Logic.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service.Helpers
{
    public static class AvailableServiceTypesHelper
    {
        public static Dictionary<ServiceTypeModel, bool> CheckAvailability(DateTime time,IEnumerable<RegistratedService> registratedServices, IEnumerable<ServiceTypeModel> serviceTypes)
        {
            var availableServiceTypes = new Dictionary<ServiceTypeModel, bool>();
            var serviceBlocks = GetRegistratedServicesTimeBlocks(registratedServices);
            if (serviceBlocks.Count > 0)
            {
                foreach (var serviceTimeBlock in serviceBlocks)
                {
                    foreach (var phaseTimeBlock in GetServiceTypesTimeBlocks(time, serviceTypes))
                    {
                        if (serviceTimeBlock.Item2 <= phaseTimeBlock.Value.Item1 ||
                            phaseTimeBlock.Value.Item2 <= serviceTimeBlock.Item1)
                        {
                            if (!availableServiceTypes.Select(x => x.Key.Id).Contains(phaseTimeBlock.Key.Id))
                                availableServiceTypes.Add(phaseTimeBlock.Key, true);
                        }
                        else
                        {
                            if (availableServiceTypes.Select(x => x.Key.Id).Contains(phaseTimeBlock.Key.Id))
                            {
                                var index =
                                    availableServiceTypes.Keys.Where(x => x.Id == phaseTimeBlock.Key.Id)
                                        .SingleOrDefault();
                                availableServiceTypes[index] = false;
                            }
                            else
                                availableServiceTypes.Add(phaseTimeBlock.Key, false);
                        }
                    }
                }
            }
            else
            {
                foreach (var type in serviceTypes)
                {
                    availableServiceTypes.Add(type, true);
                }
            }
            return availableServiceTypes;
        }
        private static List<Tuple<DateTime, DateTime>> GetRegistratedServicesTimeBlocks(IEnumerable<RegistratedService> registratedServices)
        {
            var result = new List<Tuple<DateTime, DateTime>>();
            foreach (var service in registratedServices)
            {
                foreach (var phase in service.ServiceType.Phases.OrderBy(x => x.Order))
                {
                    var previousPhases = service.ServiceType.Phases.Where(x => x.Order < phase.Order);
                    var timeOffset = previousPhases.Sum(x => x.DelayInMinutes) + previousPhases.Sum(x => x.DurationInMinutes);
                    result.Add(new Tuple<DateTime, DateTime>(service.StartDate.AddMinutes(timeOffset), service.StartDate.AddMinutes(phase.DurationInMinutes + timeOffset)));
                }
            }
            return result;
        }

        private static List<KeyValuePair<ServiceTypeModel,Tuple<DateTime, DateTime>>> GetServiceTypesTimeBlocks(DateTime time, IEnumerable<ServiceTypeModel> serviceTypes)
        {
            var result = new List<KeyValuePair<ServiceTypeModel, Tuple<DateTime, DateTime>>>();
            foreach (var type in serviceTypes)
            {
                foreach (var typePhase in type.Phases.OrderBy(x => x.Order))
                {
                    var previousPhase = type.Phases.Where(x => x.Order < typePhase.Order);
                    var timeOffset = previousPhase.Sum(x => x.DelayInMinutes) + previousPhase.Sum(x => x.DurationInMinutes);
                    result.Add(new KeyValuePair<ServiceTypeModel, Tuple<DateTime, DateTime>>(type, new Tuple<DateTime, DateTime>(time.AddMinutes(timeOffset), time.AddMinutes(timeOffset + typePhase.DurationInMinutes))));
                }
            }
            return result;
        }
    }
}
