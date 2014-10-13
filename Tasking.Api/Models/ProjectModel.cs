using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Tasking.Api.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public static Task<List<ProjectModel>> DummyProjects() {
            return Task.Run<List<ProjectModel>>(() => {
                var ret = new List<ProjectModel>{
                    new ProjectModel { Id = 1, Title = "My first project", Description = "This is my very first project with tasKing", Created = DateTime.Now },
                    new ProjectModel { Id = 2, Title = "Another project", Description = "And here is another project", Created = DateTime.Now }
                };
                return ret;
            });
        }
    }
}