using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ExceptionScheduleJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            var schedule = value as ExceptionSchedule;

            JArray ranges = new JArray();
            foreach (var range in schedule.TimeRanges)
            {
                var startTime = range.StartTime.ToString(@"hh\:mm");
                var endTime = range.EndTime.ToString(@"hh\:mm");
                ranges.Add($"{startTime}-{endTime}");
            }
            var date = schedule.Date.ToString("dd-MM-yyyy");
            jo[date] = ranges;
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            var prop = jo.Properties().First().Name.ToString();
            var date = Convert.ToDateTime(prop);
            Type type = typeof(ExceptionSchedule);
            var ranges =  jo[prop] as JArray;
            var timeRanges = new List<TimeRange>();
            foreach(var range in ranges)
            {
                var strTimeeRange = range.ToString().Split("-".ToCharArray());
                var startTime = TimeSpan.Parse(strTimeeRange[0]);
                var endTime = TimeSpan.Parse(strTimeeRange[1]);
                timeRanges.Add(new TimeRange() { StartTime = startTime, EndTime = endTime });
            }

            return new ExceptionSchedule() { Date = date, TimeRanges = timeRanges };
        }
    }
}
