using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
    [JsonConverter(typeof(DayScheduleJsonConverter))]
    public class DaySchedule
    {
        public DayOfWeek Day { get; set; }

        public  IEnumerable<TimeRange> TimeRanges { get; set; }
    }
}
