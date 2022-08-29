using APIFruit.DataAccessLayer;
using APIFruit.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        // GET: api/<FruitController>
        [HttpGet]
        public IEnumerable<Fruit> Get()
        {
            DAL dal = new DAL();
            return dal.FruitFactory.GetAll();
        }

        // GET api/<FruitController>/5
        [HttpGet("{id}")]
        public Fruit Get(int id)
        {
            DAL dal = new DAL();
            return dal.FruitFactory.Get(id);
        }

        [HttpGet]
        [Route("GetNames")]

        public IEnumerable<string> GetNames()
        {
            List<string> names = new List<string>();

            DAL dal = new DAL();
            Fruit[] fruits = dal.FruitFactory.GetAll();
            foreach(Fruit fruit in fruits)
            {
                names.Add(fruit.Nom);
            }

            return names;
        }

        // POST api/<FruitController>
        [HttpPost]
        public ActionResult<Fruit> Post([FromBody] Fruit fruit)
        {
            DAL dal = new DAL();
            dal.FruitFactory.Save(fruit);
            return Created(fruit.Id.ToString(),fruit);
        }

        // PUT api/<FruitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Fruit fruit)
        {
            DAL dal = new DAL();
            fruit.Id = id;
            dal.FruitFactory.Save(fruit);
        }

        // DELETE api/<FruitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DAL dal = new DAL();
            dal.FruitFactory.Delete(id);
        }
    }
}
