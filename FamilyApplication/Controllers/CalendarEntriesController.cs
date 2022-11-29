using FamilyApplication.Models;
using FamilyApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEntriesController : ControllerBase
    {
        public readonly CalendarContext Context;
        public readonly ICalendarEntryService CalendarEntryService;

        public CalendarEntriesController(CalendarContext context, ICalendarEntryService service)
        {
            Context = context;
            CalendarEntryService = service;
        }

        /// <summary>
        /// Get all entries from Calendar or filtered by category
        /// </summary>
        /// <param name="filter"></param>

        // GET: api/<CalendarEntriesController>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(List<CalendarEntry>))]
        public ActionResult<List<CalendarEntry>> GetAllCalendarEntries([FromQuery] CalendarEntryFilter filter)
        {

            return CalendarEntryService.GetAllCalendarEntries(filter);
        }

        /// <summary>
        /// Get CalendarEntry by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<CalendarEntriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CalendarEntry> GetCalendarEntryById(Guid id)
        {
            try
            {

                return CalendarEntryService.GetCalendarEntryByID(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Post a new calendar entry
        /// </summary>
        /// <param name="entry"></param>
        // POST api/<CalendarEntriesController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(string))]
        public ActionResult<string> PostCalendarEntry([FromBody] CalendarEntry entry)
        {
            try
            {
                entry.CreatedBy = "test";

                var entryTitle = CalendarEntryService.PostCalendarEntry(entry);
                return Ok($"{entryTitle} successfully added");

            }
            catch (CategoryNotExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotSavedException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit an existing calendar entry
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entry"></param>
        // PUT api/<CalendarEntriesController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        public ActionResult PutCalenderEntry(Guid id, [FromBody] CalendarEntry entry)
        {
            try
            {
                var existingEntry = CalendarEntryService.GetCalendarEntryByID(id);
                if (existingEntry == null) throw new NotFoundException();
                CalendarEntryService.EditCalendarEntry(entry);
                return Ok($"{entry.EntryTitle} updated");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Delete a calendar entry by its ID
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<CalendarEntriesController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404, Type = typeof(string))]
        public ActionResult<string> Delete(Guid id)
        {
            var isDeleted = CalendarEntryService.Delete(id);
            if (isDeleted)
            {
                return Ok("Entry successfully deleted");
            }

            return NotFound("Entry not found");
        }
    }
}
