using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Manage;
using Models;

namespace RestService.Controllers
{
    public class FacilityController : ApiController
    {
        // GET: api/Facility
        public IEnumerable<Facility> Get()
        {
            return new ManageFacility().GetAll();
        }

        // GET: api/Facility/5
        public Facility Get(int id)
        {
            return new ManageFacility().GetFromId(id);
        }

        // POST: api/Facility
        public void Post([FromBody]Facility value)
        {
            new ManageFacility().Create(value);
        }

        // PUT: api/Facility/5
        public void Put(int id, [FromBody]Facility value)
        {
            new ManageFacility().Update(value, id);
        }

        // DELETE: api/Facility/5
        public void Delete(int id)
        {
            new ManageFacility().Delete(id);
        }
    }
}
