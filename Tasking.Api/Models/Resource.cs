using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tasking.API.Models
{
    public class Resource
    {
        public string Id { get; set; } //es el mismo ID que el usuario
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        //public string UserId { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public Resource() {
            this.Projects = new List<Project>();
        }
    }
}