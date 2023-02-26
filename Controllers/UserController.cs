using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Models.Data;
using TicketsAPI.Models.Repository;

namespace TicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        [HttpGet]
        [ActionName(nameof(GetTicketsAsync))]
        public IEnumerable<User> GetTicketsAsync()
        {
            return _userRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetUsersById))]
        public ActionResult<User> GetUsersById(int id)
        {
            var userById = _userRepository.GetByIdAsync(id);
            if (userById == null)
                return NotFound();

            return userById;
        }

        [HttpPost]
        [ActionName(nameof(CreateUserAsync))]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            await _userRepository.CreateAsync(user);
            return CreatedAtAction(nameof(GetUsersById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteUser))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(user);
            return NoContent();
        }
    }
}
