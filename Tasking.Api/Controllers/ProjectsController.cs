using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
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
            var user_id = this.User.Identity.Name; //overrided: gets ASP.NET Auth user id (GUID)

            ClaimsPrincipal principal = User as ClaimsPrincipal;
            //gets projects by username
            return Ok(await ProjectModel.DummyProjects());
        }
    }
}
