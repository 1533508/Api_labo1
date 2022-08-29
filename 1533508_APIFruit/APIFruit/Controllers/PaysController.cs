using APIFruit.DataAccessLayer;
using APIFruit.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaysController : ControllerBase
    {
        /// <summary>
        /// Retourne les pays
        /// </summary>
        /// <returns></returns>
        // GET: api/<PaysController>
        [HttpGet]
        public IEnumerable<Pays> Get()
        {
            DAL dal = new DAL();
            return dal.PaysFactory.GetAll();
        }
        /// <summary>
        /// Retourne le pays ayant le Id donné
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<PaysController>/5
        [HttpGet("{id}")]
        public Pays Get(int id)
        {
            DAL dal = new DAL();
            return dal.PaysFactory.Get(id);
        }
        /// <summary>
        /// Ajoute le pays à la liste
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        // POST api/<PaysController>
        [HttpPost]
        public ActionResult<Pays> Post([FromBody] Pays pays)
        {
            DAL dal = new DAL();
            dal.PaysFactory.Save(pays);
            return Created(pays.Id.ToString(), pays);
        }
        /// <summary>
        /// Modifie le pays ayant le Id donné
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pays"></param>
        // PUT api/<PaysController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pays pays)
        {
            DAL dal = new DAL();
            pays.Id = id;
            dal.PaysFactory.Save(pays);
        }
        /// <summary>
        /// Supprime le pays ayant le Id donné
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<PaysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DAL dal = new DAL();
            dal.PaysFactory.Delete(id);
        }
    }
}
