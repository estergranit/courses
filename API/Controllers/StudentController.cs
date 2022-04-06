using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/courses")]
    public class StudentController : ApiController
    {
        studentBLL studentbll = new studentBLL();
        [AcceptVerbs("GET", "POST")]

        [Route("insertstudent")]
        [HttpPost]
        public int InsertStudent(student student)
        {
            return studentbll.InsertStudent(student);
        }
        [Route("deletestudent")]
        [HttpPost]
        public int DeleteStudent(student student)
        {
            return studentbll.DeleteStudent(student);
        }
        [Route("updatestudent")]
        [HttpPost]
        public int UpdateStudent(student student)
        {
            return studentbll.UpDateStudent(student);
        }
        //////////////////
        [Route("istzexist/{studentTz}")]
        [HttpGet]      
        public bool IsTzExist(string studentTz)
        {
            return studentbll.IsTzExist(studentTz); 
        }
        [Route("istzmatchpassword/{studentTz}/{studentPassword}")]
        [HttpGet]
        public bool IsTzMatchPassword(string studentTz, string studentPassword)
        {
            return studentbll.IsTzMatchPassword(studentTz, studentPassword);
        }
        [Route("getstudentbytz_password")]///{studentTz}/{studentPassword}
        [HttpGet]
        public int GetStudentByTz_Password()//string studentTz, string studentPassword
        {
            return 0; //studentCoursebll.GetStudentByTz_Password(studentTz,studentPassword);
        }
        //////////////////////
        [Route("login")]
        [HttpPost]
        public int Login(student student)
        {
            System.Diagnostics.Debug.WriteLine("c# api Login*************");
            return studentbll.Login(student); 
        }
        [Route("signup")]
        [HttpPost]
        public int SignUp(student student)
        {
            return studentbll.SignUp(student);
        }

        [Route("getallstudents")]
        [HttpGet]
        public List<student> GetAllStudents()
        {
            return studentbll.GetAllStudents();
        }
    }
}
