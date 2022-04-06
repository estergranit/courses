using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Convert
{
    class coursConvert
    {

        public coursConvert()
        {

        }

        public int courseId { get; set; }
        public string courseName { get; set; }
        public Nullable<int> lessonsAmount { get; set; }
        public Nullable<int> maxParticipants { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<decimal> price { get; set; }


    }
}
