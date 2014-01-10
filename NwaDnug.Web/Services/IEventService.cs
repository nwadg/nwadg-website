using NwaDnug.Web.Models;

namespace NwaDnug.Web.Services
{
    public interface IEventService
    {
        Meeting[] GetMeetings();
        Event[] GetEvents();
    }
}