using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic.Common.Models;
using Modules.Resources;

namespace AdminPanel.Models.Calendar
{
    public class JsonEventsListViewModel
    {
        public List<JsonEventViewModel> Events { get; set; }

        public JsonEventsListViewModel(List<RegistratedServiceModel> services)
        {
            Events = new List<JsonEventViewModel>();
            foreach (var service in services)
            {
                foreach (var phase in service.ServiceType.Phases.OrderBy(x=>x.Order))
                {
                    var previousPhases = service.ServiceType.Phases.Where(x => x.Order < phase.Order);
                    var timeOffset = previousPhases.Sum(x => x.DelayInMinutes)+previousPhases.Sum(x=>x.DurationInMinutes);
                    Events.Add(new JsonEventViewModel()
                    {
                        Title = Presentation.Reserved,
                        Start = service.StartDate.AddMinutes(timeOffset).ToString("o"),
                        End = service.StartDate.AddMinutes(phase.DurationInMinutes+timeOffset).ToString("o")
                    });
                }
            }            
        }
    }
}