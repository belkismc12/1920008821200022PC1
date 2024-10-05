using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC1DAW.Data;
using PC1DAW.Interfaces;

namespace PC1DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {

        private readonly IAttendeesRepository _attendeesRepository;

        public AttendeesController(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAttendees()
        {
            var categories = await _attendeesRepository.GetAttendees();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Attendees attendees)
        {
            int attendeesId = await _attendeesRepository.Insert(attendees);
            return Ok(attendeesId);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _attendeesRepository.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }



    }
}
