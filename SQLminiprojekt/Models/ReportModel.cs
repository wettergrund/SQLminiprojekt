using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLminiprojekt.Models
{
    internal class ReportModel
    {
        public int Id { get; set; }
        public int Project_Id { get; set; }
        public int Person_Id { get; set; }
        public int hours { get; set;}
        

    }
}
