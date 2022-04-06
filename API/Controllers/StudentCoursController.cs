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
    public class StudentCoursController : ApiController
    {
        studentCourseBLL studentCoursebll = new studentCourseBLL();
        [AcceptVerbs("GET", "POST")]

        [Route("insertstudentcourse")]
        [HttpPost]
        public int InsertStudentCourse(studentCourse studentCourse)
        {
            return studentCoursebll.InsertStudentCourse(studentCourse);
        }
        [Route("deletestudentcourse")]
        [HttpPost]
        public int DeleteStudentCourse(studentCourse studentCourse)
        {
            return studentCoursebll.DeleteStudentCourse(studentCourse);
        }
        [Route("updatestudentcourse")]
        [HttpPost]
        public int UpDateStudentCourse(studentCourse studentCourse)
        {
            return studentCoursebll.UpDateStudentCourse(studentCourse);
        }
        //
        [Route("getallcoursesbystudentid/{id}")]
        [HttpGet]
        public List<cours> GetAllCoursesByStudentId(int id)
        {
            return studentCoursebll.GetAllCoursesByStudentId(id);
        }
        [Route("getanountofstudentincourse/{id}")]
        [HttpGet]
        public int GetAnountOfStudentInCourse(int courseId)
        {
            return studentCoursebll.GetAnountOfStudentInCourse(courseId);
        }

    }
}
