using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using Google.GData.Calendar;
using Google.GData.Extensions;
using NwaDnug.Web.Helpers;
using NwaDnug.Web.Models;

namespace NwaDnug.Web.Services
{
    public class EventService : IEventService
    {
        public Event[] GetEvents()
        {
            var url = "http://www.google.com/calendar/feeds/events%40nwadnug.org/public/full";
            var query = new EventQuery(url);
            var service = new CalendarService("NWADNUG Events");
            //service.setUserCredentials();

            //query.ExtraParameters = string.Format("start-min={0}&start-max={1}&singleevents=true&orderby=starttime&sortorder=ascending", startDate, endDate);
            DateTime systemTime = SystemTime.UtcNow;
            query.StartTime = systemTime;
            query.EndTime = systemTime.AddMonths(3);
            query.SingleEvents = true;
            query.SortOrder = CalendarSortOrder.ascending;
            query.ExtraParameters = "orderby=starttime";

            try
            {
                var feed = service.Query(query);
                var eventEntries = feed.Entries.Cast<EventEntry>();
                var events = eventEntries.Take(10).Select(x => new Event
                                                                {
                                                                    Title = x.Title.Text,
                                                                    Url = x.AlternateUri.ToString(),
                                                                    Date = x.Times.Cast<When>().First().StartTime.ToString("dd MMMM yyyy")
                                                                });

                return events.ToArray();
            }
            catch
            {
                return new Event[0];
            }
        }

        public Meeting[] GetMeetings()
        {
            try
            {
                var xmlReader = XmlReader.Create("http://feeds.feedburner.com/nwadnug?format=xml");
                var feed = SyndicationFeed.Load(xmlReader);
                var meetings = feed.Items.Take(10).Select(x => new Meeting
                                                                     {
                                                                         Title = x.Title.Text, Url = x.Links[4].Uri.OriginalString, Date = x.PublishDate.Date.ToShortDateString(), Content = ((TextSyndicationContent) x.Content).Text
                                                                     });

                return meetings.ToArray();
            }
            catch
            {
                return new Meeting[0];
            }
        }
    }
}