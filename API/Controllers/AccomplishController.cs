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
    public class AccomplishController : ApiController
    {
        accomplishBLL accomlishbll = new accomplishBLL();
        [AcceptVerbs("GET", "POST")]
        [Route("insertaccomplish")]
        [HttpPost]
        public int InsertAccomplish(accomplish accomplish)
        {
            return accomlishbll.InsertAccomplish(accomplish);
        }
        [Route("deleteaccomplish")]
        [HttpPost]
        public int DeleteAccomplish(accomplish accomplish)
        {
            return accomlishbll.UpDateAccomplish(accomplish);
        }
        [Route("updateaccomlish")]
        [HttpPost]
        public int UpdateAccomlish(accomplish accomplish)
        {
            System.Diagnostics.Debug.WriteLine("update controller****************************");
            return accomlishbll.UpDateAccomplish(accomplish);
        }
        //אתי
        [Route("getstudentaccomplishbybourseid/{studentId}/{courseId}")]
        [HttpGet]
        public List<accomplish> GetStudentAccomplishByCourseId(int studentId,int courseId)
        {
            return accomlishbll.GetStudentAccomplishByCourseId(studentId, courseId);
        }

    }
}
