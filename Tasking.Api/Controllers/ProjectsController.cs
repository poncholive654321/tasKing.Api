using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Tasking.Api.Models;

namespace Tasking.Api.Controllers
{
    [RoutePrefix("api/Orders")]
    public class ProjectsController : ApiController
    {
        [Authorize]
        public async Task<IHttpActionResult> Get()
        {
            var n = this.User.Identity.Name;
            return Ok(await ProjectModel.DummyProjects());
        }
    }
}
