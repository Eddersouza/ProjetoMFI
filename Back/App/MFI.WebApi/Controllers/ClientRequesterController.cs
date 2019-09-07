using MFI.WebApi.Utils.ActionResults;
using System.Web.Http;

namespace MFI.WebApi.Controllers
{
    [RoutePrefix("requester")]
    public class ClientRequesterController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return new BadRequestResult("teste", Request);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}