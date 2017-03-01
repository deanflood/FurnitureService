using FurnitureService.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace FurnitureService.Controllers
{
    public class FurnitureController : ApiController
    {
        public static List<Furniture> list = new List<Furniture>()
        {
            new Furniture ("Ikea", Type.BED, 100, true),
            new Furniture ("Harvey Norman", Type.CHAIR, 150, true),
            new Furniture ("Pound Shop", Type.TABLE, 10, false)
        };

        // GET: api/Furniture
        [HttpGet]
        [Route("api/furniture")]
        public IEnumerable<Furniture> Get()
        {
            return list;
        }

        [HttpGet]
        [Route("api/furniture/type/{type}")]
        public IEnumerable<Furniture> GetType(Type type)
        {
            return list.FindAll(f => f.Type == type);
        }

        [HttpGet]
        [Route("api/furniture/available/{avail}")]
        public IEnumerable<Furniture> GetAvail(bool avail)
        {
            return list.FindAll(f => f.IsAvailable == avail);
        }

        [HttpGet]
        [Route("api/furniture/order")]
        public IEnumerable<Furniture> GetOrder()
        {
           return list.OrderBy(f => f.Price);
        }

        [HttpPost]
        [Route("api/furniture/add")]
        public void add(Furniture f)
        {
            list.Add(f);
        }

        [HttpPut]
        [Route("api/furniture/update")]
        public void Update(Furniture update)
        {
            Furniture toUpdate = list.FirstOrDefault(f => f.Id == update.Id);
            list[list.IndexOf(toUpdate)].IsAvailable = update.IsAvailable;
        }

        [HttpDelete]
        [Route("api/furniture/delete/{id}")]
        public void Delete(int id)
        {
            Furniture toDelete = list.FirstOrDefault(f => f.Id == id);
            list.Remove(toDelete);
        }
    }
}
