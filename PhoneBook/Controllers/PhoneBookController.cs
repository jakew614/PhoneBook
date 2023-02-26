using System.Net;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {

        static List<PhoneBookEntry> pBook = new List<PhoneBookEntry>()
        {
            new PhoneBookEntry{Number = "1234567", Name="Pat Smith", Address="TUD"},
            new PhoneBookEntry{Number = "2345678", Name="Harry Smith", Address="Athlone"},
            new PhoneBookEntry{Number = "3456789", Name="Gemma Smith", Address="Kerry"},
            new PhoneBookEntry { Number = "5566656", Name = "Tina Smith", Address = "Sligo" }

        };

        // GET: api/<PhoneBookController>
        [HttpGet]
        public IEnumerable<PhoneBookEntry> Get()
        {
            return pBook;
        }

        // GET api/<PhoneBookController>/5
        [HttpGet("{name}")]
        public IEnumerable<PhoneBookEntry> Get(string name)
        {
            return pBook.Where(p => p.Name.ToLower().Equals(name.ToLower()));
       
        }

        // GET api/<PhoneBookController>/5
        [HttpGet("GetByNumber/{number}")]
        public IEnumerable<PhoneBookEntry> GetByNumber(string number)
        {
            return pBook.Where(p => p.Number.ToLower().Equals(number.ToLower()));

        }

        // POST api/<PhoneBookController>
        [HttpPost]
        public HttpStatusCode Post([FromBody] PhoneBookEntry value)
        {
            PhoneBookEntry found = pBook.FirstOrDefault(p => p.Number.Equals(value.Number));
            if (found == null)
            {
                pBook.Add(value);
                return HttpStatusCode.OK;

            }
            return HttpStatusCode.BadRequest;
        }



        // PUT api/<PhoneBookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhoneBookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
