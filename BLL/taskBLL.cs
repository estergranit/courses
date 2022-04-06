using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class taskBLL
    {
        DBConection dbCon;
        List<task> listOftaskes;
        public taskBLL()
        {
            dbCon = new DBConection();
            listOftaskes = dbCon.GetDbSet<task>().ToList();
        }
        public List<task> GetAllTaskes()
        {
            return listOftaskes;
        }
        //פונקציית הוספה:
        public int InsertTask(task task)
        {
            try
            {
                dbCon.Execute<task>(task, DBConection.ExecuteActions.Insert);
                return task.taskId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // פונקציית עדכון:
        public int UpDateTask(task task)
        {
            try
            {
                dbCon.Execute<task>(task, DBConection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteTask(task task)
        {
            try
            {
                dbCon.Execute<task>(task, DBConection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
       public List<int> GetTasksByCourseId(int courseId)
        {
            return  listOftaskes.Where(t => t.taskCourse == courseId).Select(t => t.taskId).ToList();
        
        }
        public task GetTaskById(int taskId)
        {
            return listOftaskes.Where(t => t.taskId == taskId).ToList()[0];
        }
    }
}
