using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class accomplishBLL
    {
        List<accomplish> listOfAccomplishes;
        DBConection dbCon;
        public accomplishBLL()
        {
            dbCon = new DBConection();
            listOfAccomplishes = dbCon.GetDbSet<accomplish>().ToList();
        }
        public List<accomplish> GetAllAccomplishes()
        {
            return listOfAccomplishes;
        }
        //פונקציית הוספה:
        public int InsertAccomplish(accomplish accomplish)
        {
            try
            {
                dbCon.Execute<accomplish>(accomplish, DBConection.ExecuteActions.Insert);
                return accomplish.accomplishId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // פונקציית עדכון:
        public int UpDateAccomplish(accomplish accomplish)
        {
            System.Diagnostics.Debug.WriteLine("update bll****************************");
            try
            {
                dbCon.Execute<accomplish>(accomplish, DBConection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteAccomplish(accomplish accomplish)
        {
            try
            {
                dbCon.Execute<accomplish>(accomplish, DBConection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //אתי
        public List<accomplish> GetStudentAccomplishByCourseId(int studentId, int courseId)
        {
            taskBLL taskBLL = new taskBLL();
            List<int> tasksId = taskBLL.GetTasksByCourseId(courseId);
            List<accomplish> studentAcomplish = listOfAccomplishes.Where(a => a.accomplishStudent == studentId).ToList();
            List<accomplish> studentAcomplishByCourseId = new List<accomplish>();
            foreach (int task in tasksId)
            {
                studentAcomplishByCourseId.AddRange(studentAcomplish.Where(a => a.accomplishTask == task).ToList());
            }
            return studentAcomplishByCourseId;
        }
    }
}

