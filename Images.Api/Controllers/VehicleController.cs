using Vehicle.Search.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vehicle.Search.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleStoreRepository _repo;

        public VehicleController(IVehicleStoreRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        [ResponseCache( Duration = 300, VaryByHeader ="User-Agent" )]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [Authorize(Policy = "FetchByVRN")]
        // GET api/<VehicleController>/5
        [HttpGet("{vrn}")]
        public IActionResult Get(string vrn)
        {
            var vehicle = _repo.FetchVehicleBy(vrn);
            if(vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
