using CSGAPI.Models;
using CSGAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly UserAccountsService _userAccountsService;

        public UserAccountsController(UserAccountsService userAccountsService)
        {
            _userAccountsService = userAccountsService;
        }

        [HttpGet]
        public ActionResult<List<UserAccounts>> Get() =>
            _userAccountsService.Get();

        [HttpGet("{id:length(64)}", Name = "GetUserAccounts")]
        public ActionResult<UserAccounts> Get(string id) {
            var userAccounts = _userAccountsService.Get(id);
    
            if (userAccounts == null)
            {
                return NotFound();
            }

            return userAccounts;
        }

        [HttpPost]
        public ActionResult<UserAccounts> Create(UserAccounts userAccounts)
        {
            _userAccountsService.Create(userAccounts);

            return CreatedAtRoute("GetUserAccounts", new { id = userAccounts.Id.ToString() }, userAccounts);
        }

        [HttpPut("{id:length(64)}")]
        public IActionResult Update(string id, UserAccounts userAccountsIn)
        {
            var userAccounts = _userAccountsService.Get(id);

            if (userAccounts == null)
            {
                return NotFound();
            }

            _userAccountsService.Update(id, userAccountsIn);

            return NoContent();
        }

        [HttpDelete("{id:length(64)}")]
        public IActionResult Delete(string id)
        {
            var userAccounts = _userAccountsService.Get(id);

            if (userAccounts == null)
            {
                return NotFound();
            }

            _userAccountsService.Remove(userAccounts.Id);

            return NoContent();
        }
    }
}