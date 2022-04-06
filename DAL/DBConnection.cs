using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConection
    {
        public DBConection() { System.Diagnostics.Debug.WriteLine(" bd connection create dal*************"); }
        public List<T> GetDbSet<T>() where T : class
        {
            System.Diagnostics.Debug.WriteLine("3**********************");
            using (COURSESEntities COURSESEntity = new
            COURSESEntities())
            {
                System.Diagnostics.Debug.WriteLine("4**********************");
                return COURSESEntity.GetDbSet<T>().ToList();
            }
        }
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T :
        class
        {
            using (COURSESEntities courseEntity = new
            COURSESEntities())
            {
                var model = courseEntity.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        model.Attach(entity);
                        courseEntity.Entry(entity).State =
                        System.Data.Entity.EntityState.Modified;
                        System.Diagnostics.Debug.WriteLine("in the dbCon UPDATE+++++++++++++++++++++");

                        break;
                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        courseEntity.Entry(entity).State =
                        System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                courseEntity.SaveChanges();
            }
        }
    }
}
