using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace NvrScheduleModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(NvrSchedule))]
        public ActionResult<IEnumerable<string>> Get()
        {
            var schedule = new NvrSchedule();
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                schedule.AddDaySchedule(
                    new DaySchedule()
                    {
                        Day = (DayOfWeek)day,
                        TimeRanges = new List<TimeRange>()
                        {
                                        new TimeRange()
                                        {
                                            StartTime = TimeSpan.Parse("00:00"),
                                            EndTime = TimeSpan.Parse("06:00")
                                        },
                                        new TimeRange()
                                        {
                                            StartTime = TimeSpan.Parse("18:00"),
                                            EndTime = TimeSpan.Parse("23:59")
                                        },
                        }
                    });
            }

            schedule.AddException(
                new ExceptionSchedule()
                {
                    Date = Convert.ToDateTime("13/08/2019"),
                    TimeRanges = new List<TimeRange>()
                    {
                                    new TimeRange()
                                    {
                                        StartTime = TimeSpan.Parse("02:00"),
                                        EndTime = TimeSpan.Parse("07:00")
                                    },
                                    new TimeRange()
                                    {
                                        StartTime = TimeSpan.Parse("11:00"),
                                        EndTime = TimeSpan.Parse("13:00")
                                    },
                    }
                });
            schedule.AddException(
                new ExceptionSchedule()
                {
                    Date = Convert.ToDateTime("14/08/2019"),
                    TimeRanges = new List<TimeRange>()
                    {
                                    new TimeRange()
                                    {
                                        StartTime = TimeSpan.Parse("07:00"),
                                        EndTime = TimeSpan.Parse("12:00")
                                    }
                    }
                });
            schedule.AddException(
                new ExceptionSchedule()
                {
                    Date = Convert.ToDateTime("15/08/2019"),
                    TimeRanges = new List<TimeRange>()
                    {
                                    new TimeRange()
                                    {
                                        StartTime = TimeSpan.Parse("07:00"),
                                        EndTime = TimeSpan.Parse("15:00")
                                    }
                    }
                });

            return Ok(schedule); 
        }
    }
}