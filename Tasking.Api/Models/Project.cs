using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Tasking.API.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public Project() {
            this.Resources = new List<Resource>();
        }

        public static Task<List<Project>> DummyProjects() {
            return Task.Run<List<Project>>(() => {
                var ret = new List<Project>{
                    new Project { Id = 1, Title = "My first project", Description = "This is my very first project with tasKing", Created = DateTime.Now },
                    new Project { Id = 2, Title = "Another project", Description = "And here is another project", Created = DateTime.Now }
                };
                return ret;
            });
        }
    }
}