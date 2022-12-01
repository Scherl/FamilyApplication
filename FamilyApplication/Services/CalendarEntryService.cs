using FamilyApplication.Models;

namespace FamilyApplication.Services
{
    public class CalendarEntryService : ICalendarEntryService
    {
        public readonly ApplicationDBContext _context;
        public CalendarEntryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public string PostCalendarEntry(CalendarEntry entry)
        {
            var checkCategory = _context.Categories.SingleOrDefault(c => c.CategoryName == entry.Category.CategoryName);
            if (checkCategory == null) throw new CategoryNotExistException();

            entry.CategoryId = checkCategory.CategoryId;
            entry.Category = checkCategory;
            _context.CalendarEntries.Add(entry);
            _context.SaveChanges();
            var savedEntry = _context.CalendarEntries.SingleOrDefault(x => x.EntryTitle == entry.EntryTitle);
            return savedEntry == null ? throw new NotSavedException() : savedEntry.EntryTitle;
        }

        public List<CalendarEntry> GetAllCalendarEntries(CalendarEntryFilter filter)
        {
            if (!string.IsNullOrEmpty(filter.Category))
            {
                var filteredList = _context.CalendarEntries.Where(c => c.Category.CategoryName == filter.Category).ToList();
                return filteredList;
            }

            var entryList = _context.CalendarEntries.ToList();
            return entryList;
        }

        public CalendarEntry GetCalendarEntryByID(Guid id)
        {

            var entry = _context.CalendarEntries.SingleOrDefault(c => c.CalendarId == id);

            return entry ?? throw new NotFoundException();
        }

        public string EditCalendarEntry(CalendarEntry entry)
        {
    
            var checkCategory = _context.Categories.SingleOrDefault(c => c.CategoryName == entry.Category.CategoryName);
            if (checkCategory == null) throw new CategoryNotExistException();

            _context.CalendarEntries.Update(entry);
            _context.SaveChanges();
            return entry.EntryTitle;

        }

        public bool Delete(Guid calenderGuid)
        {
            var entry = _context.CalendarEntries.SingleOrDefault(i => i.CalendarId == calenderGuid);
            if (entry == null) return false;
            _context.CalendarEntries.Remove(entry);
            _context.SaveChanges();
            return true;
        }
    }
}
