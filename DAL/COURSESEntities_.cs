using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class COURSESEntities : DbContext
    {
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }
    }
}
