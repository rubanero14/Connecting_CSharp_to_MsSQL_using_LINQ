using Connecting_CSharp_to_MsSQL_using_LINQ.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Connecting_CSharp_to_MsSQL_using_LINQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleDbContext db;
        public PeopleController(PeopleDbContext _context) 
        {
            db = _context;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get() 
        {
            try
            {
                List<Person> people = db.People.ToList();
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
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var person = db.People.Where(x => x.Id == id).FirstOrDefault();
                if (person != null)
                {
                    return Ok(person);
                }
                else
                {
                    return Ok("No such person found on database record!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/<PeopleController>/Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(string firstName, string lastName)
        {
            try
            {
                var person = new Person(firstName, lastName);
                db.People.Add(person);
                db.SaveChanges();
                return Ok($"Create successful for { person.FirstName } { person.LastName }!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/<PeopleController>/Update/1
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, string firstName, string lastName)
        {
            try
            {
                var person = db.People.Where(x => x.Id == id).FirstOrDefault();
                person.FirstName = firstName;
                person.LastName = lastName;
                db.People.Update(person);
                db.SaveChanges();
                return Ok($"Update successful for { person.FirstName } { person.LastName }!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/<PeopleController>/Delete/1
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var person = db.People.Where(x => x.Id == id).FirstOrDefault();
                db.People.Remove(person);
                db.SaveChanges();
                return Ok($"Delete successful for {person.FirstName} {person.LastName}!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
