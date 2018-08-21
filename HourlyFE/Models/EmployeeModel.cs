using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HourlyFE.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string gender { get; set; }
        public int salary { get; set; }
    }
}