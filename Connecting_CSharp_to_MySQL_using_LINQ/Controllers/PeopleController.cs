using Connecting_CSharp_to_MySQL_using_LINQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Connecting_CSharp_to_MySQL_using_LINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDbContext _dbcontext;
        public PeopleController(PeopleDbContext _context) 
        {
            _dbcontext = _context;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetPeople() 
        {
            try
            {
                List<Person> people = _dbcontext.People.ToList();
                if(people != null)
                {
                    return Ok(people);
                }
                else
                {
                    return Ok("The list of people is empty!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<PeopleController>/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                var person = _dbcontext.People.Where(x => x.Id == id).FirstOrDefault();
                if (person != null)
                {
                    return Ok(person);
                }
                else
                {
                    return Ok("No surch person found on database record!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
