using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class studentCourseBLL
    {
        DBConection dbCon;
        List<studentCourse> listOfStudentCourse;
        public studentCourseBLL()
        {
            dbCon = new DBConection();
            listOfStudentCourse = dbCon.GetDbSet<studentCourse>().ToList();
        }
        public List<studentCourse> GetAllStudentsCourses()
        {
            return listOfStudentCourse;
        }
        //פונקציית הוספה:
        //הוספת קורס לתלמיד
        public int InsertStudentCourse(studentCourse studentCourse)
        {
            if (!isStudentCourseExist(studentCourse))
            {
                try
                {
                    dbCon.Execute<studentCourse>(studentCourse, DBConection.ExecuteActions.Insert);
                    if (!insertTaskCourseOfStudent(studentCourse))//הוספת מטלות הקורס לתלמיד
                    {
                        System.Diagnostics.Debug.WriteLine("problem where insert accomplish to database");
                        throw new Exception();
                    }
                    return studentCourse.studentCourseId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            else
            {
                return -1;//התלמיד כבר נרשם לקורס
            }
            
        }
        // פונקציית עדכון:
        public int UpDateStudentCourse(studentCourse studentCourse)
        {
            try
            {
                dbCon.Execute<studentCourse>(studentCourse, DBConection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה:
        public int DeleteStudentCourse(studentCourse studentCourse)
        {
            try
            {
                dbCon.Execute<studentCourse>(studentCourse, DBConection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //
        private bool isStudentCourseExist(studentCourse studentCourse)
        {
            return listOfStudentCourse.FindLast(sc => sc.courseId == studentCourse.courseId && sc.studentId == studentCourse.studentId)!=null;
        }
        public List<int> GetAllCoursesIdByStudentId(int id)
        {
            var myCoursesId = from course in listOfStudentCourse
                    where course.studentId == id
                    select course.courseId;
            return myCoursesId.ToList();
        }
        private bool insertTaskCourseOfStudent(studentCourse studentCourses)//הוספת מטלות הקורס לתלמיד
        {
            //לקבל רשימה של כל המזהים של משימות שקשורות לקורס הזה
            //כל משימה להכניס לטבלת ACCOMPLISH 
            int studentId = studentCourses.studentId;
            int courseId = studentCourses.courseId;
            taskBLL task = new taskBLL();
            accomplishBLL accomplishBLL = new accomplishBLL();
            List<int> listTasksId = task.GetTasksByCourseId(courseId);
            foreach (int taskId in listTasksId)
            {
                accomplish accomplish = new accomplish();
                accomplish.accomplishStudent = studentId;
                accomplish.accomplishTask = taskId;
                if (accomplishBLL.InsertAccomplish(accomplish) == 0) return false;
                //צריך להוסיף איזשהי טרנזקציה כך שאם הכנסה תכשל כל ההכנסות שהיו יתבטלו
            }
            return true;
        }
        public int GetAnountOfStudentInCourse(int courseId)
        {
            return listOfStudentCourse.Count(sc => sc.courseId == courseId);
        }
        public List<cours> GetAllCoursesByStudentId(int studentId)
        {
            //studentCourseBLL sc = new studentCourseBLL();
            List<int> listCoursesId = GetAllCoursesIdByStudentId(studentId);
            List<cours> courses = new List<cours>();
            coursBLL coursBLL = new coursBLL();
            List<cours> listOfCourses = coursBLL.GetAllCourses();
            foreach (int courseId in listCoursesId)
            {
                courses.AddRange(listOfCourses.Where(c => c.courseId == courseId).ToList());
            }
            return courses;
        }
    }
}
