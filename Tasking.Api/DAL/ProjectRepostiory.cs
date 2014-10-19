using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Tasking.API.Models;

namespace Tasking.API.DAL
{
    public class ProjectRepostiory : IDisposable
    {
        private TaskingContext _db = null;

        protected IObjectContextAdapter GetObjectContext
        {
            get {
                return ((IObjectContextAdapter)_db).ObjectContext;
            } 
        }

        public ProjectRepostiory() {
            _db = new TaskingContext();
        }

        public IEnumerable<Project> GetByResource(string resourceId) {
            var p = new object[] {new SqlParameter("@ResourceId", resourceId)};
            var ret  = GetObjectContext.
                ObjectContext.ExecuteStoreQuery<Project>("exec Projects_brwByResource @ResourceId", p);
            return ret;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}