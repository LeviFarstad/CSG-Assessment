using CSGAPI.Models;
using CSGAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSGAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMBalanceController : ControllerBase
    {
        private readonly ATMBalanceService _ATMBalanceService;

        public ATMBalanceController(ATMBalanceService ATMBalanceService)
        {
            _ATMBalanceService = ATMBalanceService;
        }

        [HttpGet]
        public ActionResult<List<ATMBalance>> Get() =>
            _ATMBalanceService.Get();

        [HttpGet("{id:length(64)}", Name = "GetATMBalance")]
        public ActionResult<ATMBalance> Get(string id) {
            var ATMBalance = _ATMBalanceService.Get(id);
    
            if (ATMBalance == null)
            {
                return NotFound();
            }

            return ATMBalance;
        }

        [HttpPost]
        public ActionResult<ATMBalance> Create(ATMBalance ATMBalance)
        {
            _ATMBalanceService.Create(ATMBalance);

            return CreatedAtRoute("GetATMBalance", new { id = ATMBalance.Id.ToString() }, ATMBalance);
        }

        [HttpPut("{id:length(64)}")]
        public IActionResult Update(string id, ATMBalance ATMBalanceIn)
        {
            var ATMBalance = _ATMBalanceService.Get(id);

            if (ATMBalance == null)
            {
                return NotFound();
            }

            _ATMBalanceService.Update(id, ATMBalanceIn);

            return NoContent();
        }

        [HttpDelete("{id:length(64)}")]
        public IActionResult Delete(string id)
        {
            var ATMBalance = _ATMBalanceService.Get(id);

            if (ATMBalance == null)
            {
                return NotFound();
            }

            _ATMBalanceService.Remove(ATMBalance.Id);

            return NoContent();
        }
    }
}