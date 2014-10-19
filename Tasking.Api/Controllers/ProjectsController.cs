using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Tasking.API.DAL;
using Tasking.API.Models;

namespace Tasking.API.Controllers
{
    [RoutePrefix("api/Orders")]
    public class ProjectsController : ApiController
    {

        private TaskingContext db = new TaskingContext();
        private ProjectRepostiory projects = new ProjectRepostiory();

        [Authorize]
        public async Task<IHttpActionResult> Get()
        {
            var user_id = this.User.Identity.Name; //overrided: gets ASP.NET Auth user id (GUID)
            var ret = projects.GetByResource(user_id);
            return Ok(ret);
        }

        [Authorize]
        public async Task<IHttpActionResult> Post(Project projectModel)
        {
            var user_id = this.User.Identity.Name; //overrided: gets ASP.NET Auth user id (GUID)
            var newProject = db.Projects.Create();
            var resource = await db.Resources.FindAsync(user_id);
            
            //
            newProject.Title = projectModel.Title;
            newProject.Description = projectModel.Description;
            newProject.Created = DateTime.Now;
            newProject.Resources.Add(resource);
            //

            db.Projects.Add(newProject);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
