using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Models.Data;
using TicketsAPI.Models.Repository;

namespace TicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository) => _ticketRepository = ticketRepository;

        [HttpGet]
        [ActionName(nameof(GetTicketsAsync))]
        public IEnumerable<Ticket> GetTicketsAsync()
        {
            return _ticketRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetTicketsById))]
        public ActionResult<Ticket> GetTicketsById(int id)
        {
            var ticketById = _ticketRepository.GetByIdAsync(id);
            if(ticketById == null)
                return NotFound();

            return ticketById;
        }

        [HttpPost]
        [ActionName(nameof(CreateTicketAsync))]
        public async Task<ActionResult<Ticket>> CreateTicketAsync(Ticket ticket)
        {
            await _ticketRepository.CreateAsync(ticket);
            return CreatedAtAction(nameof(GetTicketsById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateTicket))]
        public async Task<ActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();
            
            await _ticketRepository.UpdateAsync(ticket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteTicket))]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = _ticketRepository.GetByIdAsync(id);
            if (ticket == null)
                return NotFound();

            await _ticketRepository.DeleteAsync(ticket);
            return NoContent();
        }
    }
}
