using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Nvr schdule class
    /// </summary>
    public class NvrSchedule
    {
        private readonly List<DaySchedule> _days;
        private readonly List<ExceptionSchedule> _exceptions;

        public IEnumerable<DaySchedule> Days
        {
            get
            {
                return _days;
            }
        }

        public IEnumerable<ExceptionSchedule> Exceptions
        {
            get
            {
                return _exceptions;
            }
        }

        public NvrSchedule()
        {
            _days = new List<DaySchedule>();
            _exceptions = new List<ExceptionSchedule>();
        }

        public void AddDaySchedule(DaySchedule schedule)
        {
            var daySchedule = _days.FirstOrDefault(c => c.Day == schedule.Day);
            if(daySchedule == null)
            {
                _days.Add(schedule);
            }
        }

        public void AddException(ExceptionSchedule schedule)
        {
            var exception = _exceptions.FirstOrDefault(c => c.Date == schedule.Date);
            if (exception == null)
            {
                _exceptions.Add(schedule);
            }
        }
    }
}
