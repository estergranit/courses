using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class studentBLL
    {
        DBConection dbCon;
        List<student> listOfStudents;
        public studentBLL()
        {
            System.Diagnostics.Debug.WriteLine("student bll create*************");
            dbCon = new DBConection();
            listOfStudents = dbCon.GetDbSet<student>().ToList();
        }
        public List<student> GetAllStudents()
        {
            return listOfStudents;
        }
        //פונקציית הוספה:
        public int InsertStudent(student student)
        {
            if (!IsTzExist(student.studentTz))
                try
                {
                    dbCon.Execute<student>(student, DBConection.ExecuteActions.Insert);
                    return student.studentId;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            else
                return -1;//המשתמש קיים
        }
        // פונקציית עדכון:
        public int UpDateStudent(student student)
        {
            try
            {
                dbCon.Execute<student>(student, DBConection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //פונקציית מחיקה
        public int DeleteStudent(student student)
        {
            try
            {
                dbCon.Execute<student>(student, DBConection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        //
        public bool IsTzExist(string studentTz)//בודק האם קיים תלמיד עם התז
        {
            return listOfStudents.Find(s => s.studentTz.Equals(studentTz)) != null;
        }
        public bool IsTzMatchPassword(string studentTz, string studentPassword)//בודק האם התז מתאימה לסיסמא
        {
            return listOfStudents.Find(s => s.studentTz.Equals(studentTz) && s.studentPassword.Equals(studentPassword)) != null;
        }
        public student GetStudentByTz_Password(string studentTz, string studentPassword)
        {
            return listOfStudents.Find(s => s.studentTz.Equals(studentTz) && s.studentPassword.Equals(studentPassword));
        }
        public int Login(student student)
        {          
            //תז לא קיים 
            if (!IsTzExist(student.studentTz)) return -1;
            //סיסמא שגויה
            if (!IsTzMatchPassword(student.studentTz, student.studentPassword)) return -2;
            //תקין מחזיר את התז
            //מחזיר את איידי מהמסד נתונים ולא מהאובייקט שקיבלנו כי האיידי שלו שווה לב מחדל
            return GetStudentByTz_Password(student.studentTz, student.studentPassword).studentId;
        }
        public int SignUp(student student)
        {
            return InsertStudent(student);
        }
    }
}
