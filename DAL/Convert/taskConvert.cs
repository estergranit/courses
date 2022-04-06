using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Convert
{
    class taskConvert
    {

        public taskConvert()
        { }

        public int taskId { get; set; }
        public string taskDesc { get; set; }
        public int taskCourse { get; set; }
        public virtual ICollection<accomplish> accomplishes { get; set; }


    }
}
