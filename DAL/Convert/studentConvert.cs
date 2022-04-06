using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Convert
{
    class studentConvert
    {
        public studentConvert()
        { }

        public int studentId { get; set; }
        public string studentTz { get; set; }
        public string studentName { get; set; }
        public string studentPassword { get; set; }
        public Nullable<int> studentAge { get; set; }


    }
}
