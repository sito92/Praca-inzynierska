using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Statistics.Helpers
{
    public static class BetweenDatesValidationHelper
    {
        public static Expression<Func<StatisticsInformation, bool>> BetweenDatesValidation(DateTime? from,
                                                                               DateTime? to)
        {
            if (from != null && to != null)
                return x => x.Date >= from && x.Date <= to;
            if (from != null && to == null)
                return x => x.Date >= from;
            if (from == null && to != null)
                return x => x.Date <= to;
            if (from == null && to == null)
                return x => x == x;

            return null;
        }
    }
}
