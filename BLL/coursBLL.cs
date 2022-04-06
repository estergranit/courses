using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class coursBLL
    {
        DBConection dbCon;
        List<cours> listOfCourses;
        public coursBLL()
        {
            dbCon = new DBConection();
            listOfCourses = dbCon.GetDbSet<cours>().ToList();
        }
        public List<cours> GetAllCourses()
        {
            System.Diagnostics.Debug.WriteLine("2**********************");
            return listOfCourses;
        }
        //פונקציית הוספה:
        public int InsertCours(cours cours)
        {
            try
            {
                dbCon.Execute<cours>(cours, DBConection.ExecuteActions.Insert);
                return cours.courseId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        // פונקציית עדכון:
        public int UpDateCours(cours cours)
        {
            try
            {
                dbCon.Execute<cours>(cours, DBConection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteCours(cours cours)
        {
            try
            {
                dbCon.Execute<cours>(cours, DBConection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public cours GetCoursById(int id)
        {

            System.Diagnostics.Debug.WriteLine("c# bll getCourseById******");
            return listOfCourses.First<cours>(c => c.courseId == id);

        }
      /*  public List<cours> GetAllCoursesByStudentId (int id)
        {
            studentCourseBLL sc = new studentCourseBLL();
            List<int> listCoursesId = sc.GetAllCoursesIdByStudentId(id);
            List<cours> courses = new List<cours>();
            foreach (int courseId in listCoursesId)
            {
                courses.AddRange(listOfCourses.Where(c => c.courseId == courseId).ToList());
            }
            return courses;
        }     */

    }
}
