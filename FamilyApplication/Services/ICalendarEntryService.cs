using FamilyApplication.Models;

namespace FamilyApplication.Services
{
    public interface ICalendarEntryService
    {
        string PostCalendarEntry(CalendarEntry entry);
        List<CalendarEntry> GetAllCalendarEntries(CalendarEntryFilter filter);
        public CalendarEntry GetCalendarEntryByID(Guid id);
        string EditCalendarEntry(CalendarEntry entry);
        bool Delete(Guid calenderGuid);
    }
}
