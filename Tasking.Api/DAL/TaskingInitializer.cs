using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tasking.API.DAL
{
    public class TaskingInitializer : DropCreateDatabaseIfModelChanges<TaskingContext>
    {
        protected override void Seed(TaskingContext context)
        {
            
        }
    }
}