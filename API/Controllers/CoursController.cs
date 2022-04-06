using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : ApiController
    {
        coursBLL coursbll = new coursBLL();
        [AcceptVerbs("GET", "POST")]

        [Route("insertcours")]
        [HttpPost]
        public int InsertCours(cours course)
        {
            return coursbll.InsertCours(course);
        }
        [Route("deletecours")]
        [HttpPost]
        public int DeleteCours(cours course)
        {
            return coursbll.DeleteCours(course);
        }
        [Route("updatecours")]
        [HttpPost]
        public int UpdateCours(cours course)
        {
            return coursbll.UpDateCours(course);
        }
        //
        [Route("getallcourses")]
        [HttpGet]
        public List<cours> GetAllCourses()
        {
            System.Diagnostics.Debug.WriteLine("1**********************");

            return coursbll.GetAllCourses();
        }
        [Route("getcoursbyid/{courseId}")]
        [HttpGet]
        public cours GetCoursById(int courseId)
        {

            System.Diagnostics.Debug.WriteLine("c# api getCourseById******");
            return coursbll.GetCoursById(courseId);
        }
        /*[Route("getallcoursesbystudentid/{id}")]
        [HttpGet]
        public List<cours> GetAllCoursesByStudentId(int id)
        {
            return coursbll.GetAllCoursesByStudentId(id);
        }
        */
    }
}
