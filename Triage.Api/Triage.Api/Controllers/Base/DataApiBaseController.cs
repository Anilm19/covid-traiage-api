using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Entity.Base;
using Services;

namespace Triage.Api.Controllers.Base
{
    public class DataApiBaseController<T, TService> : BaseController<TService>
       where T : BaseEntity
       where TService : IEntityService<T>
    {

        public DataApiBaseController(TService service, ILogger logger) : base(service, logger)
        {
        }

        [HttpGet()]
        public virtual IActionResult GetAll()
        {
            return Ok(Service.GetAll());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(string id)
        {

            return Ok(Service.GetById(id));
        }


        [HttpPost()]
        public virtual IActionResult Post([FromBody] T item)
        {
           
            return Ok(Service.Add(item));
        }

        [HttpPut()]
        public virtual IActionResult Put([FromBody] T item)
        {
            return Ok(Service.Update(item));
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(string id)
        {
            Service.Delete(id);
            return Ok();
        }
    }
}
