using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public const string DurationInDaysLessThanZeroMessage = "Duration in days is less than zero";
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        { 
            int weekendCount = 0;
            if (dayCount < 0)
            {
                throw new System.ArgumentOutOfRangeException("dayCount", dayCount, DurationInDaysLessThanZeroMessage);
            }
            if (weekEnds == null)
            {
                return startDate.AddDays(dayCount - 1);
            }
            for (int i =0; i< dayCount; i++) 
            {
                for (int j = 0; j < weekEnds.Length; j++)
                {
                    if (startDate.AddDays(i) == weekEnds[j].StartDate)
                    {
                        if (weekEnds[j].StartDate == weekEnds[j].EndDate)
                        {
                            weekendCount++;
                        }
                        else
                        {
                            weekendCount = weekEnds[j].EndDate.Day - weekEnds[j].StartDate.Day;
                        }
                    }
                }

            }
            return startDate.AddDays(dayCount+weekendCount);
        }
    }
}
