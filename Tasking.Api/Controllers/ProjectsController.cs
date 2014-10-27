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
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {

        private TaskingContext db;
        private ProjectRepostiory projects;

        public ProjectsController() {
            db = new TaskingContext();
            projects = new ProjectRepostiory(db);
        }

        [Authorize]
        public async Task<IHttpActionResult> Get()
        {
            var user_id = this.User.Identity.Name; //overrided: gets ASP.NET Auth user id (GUID)
            var ret = projects.GetByResource(user_id);
            return Ok(ret);
        }

        [Authorize]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(DTO.ProjectDTOFactory.GetProjectHeaderDto(await projects.GetById(id)));
        }

        [Authorize]
        public async Task<IHttpActionResult> Post(Project projectModel)
        {
            switch (projectModel.Action.ToUpper())
            {
                case "POST":
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
                    break;
                case "PUT":
                    break;
                case "DELETE":
                    var project = await db.Projects.FindAsync(projectModel.Id);
                    db.Projects.Remove(project);
                    break;
                default:
                    break;
            }
            
            await db.SaveChangesAsync();

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int projectId)
        {
            try
            {
                var project = await db.Projects.FindAsync(projectId);
                db.Projects.Remove(project);
                //await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {

                return InternalServerError();
            }
            
        }
    }
}
