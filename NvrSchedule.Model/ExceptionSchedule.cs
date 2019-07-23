using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Model
{
    [JsonConverter(typeof(ExceptionScheduleJsonConverter))]
    public class ExceptionSchedule
    {
        public DateTime Date { get; set; }

        public  IEnumerable<TimeRange> TimeRanges { get; set; }
    }
}
