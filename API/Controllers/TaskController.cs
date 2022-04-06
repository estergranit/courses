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
    public class TaskController : ApiController
    {
        taskBLL taskbll = new taskBLL();
        [AcceptVerbs("GET", "POST")]

        [Route("inserttask")]
        [HttpPost]
        public int InsertTask(task task)
        {
            return taskbll.InsertTask(task);
        }
        [Route("deletetask")]
        [HttpPost]
        public int DeleteStudent(task task)
        {
            return taskbll.DeleteTask(task);
        }
        [Route("updatetask")]
        [HttpPost]
        public int UpdateTask(task task)
        {
            return taskbll.UpDateTask(task);
        }
        [Route("gettasksbycourseId/{courseId}")]
        [HttpGet]
        public List<int> GetTasksByCourseId(int courseId)
        {
            return taskbll.GetTasksByCourseId(courseId);
        }
        //אתי
        [Route("gettaskbyid/{taskId}")]
        [HttpGet]
        public task GetTaskById(int taskId)
        {
            return taskbll.GetTaskById(taskId);
        }
    }
}
