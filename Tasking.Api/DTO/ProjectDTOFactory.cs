using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasking.API.Models;

namespace Tasking.API.DTO
{
    public class ProjectDTOFactory
    {
        public static dynamic GetProjectHeaderDto(Project origin) {
            return new { Title = origin.Title, Description = origin.Description, Created = origin.Created, Resources = origin.Resources.Count };
        }
    }
}