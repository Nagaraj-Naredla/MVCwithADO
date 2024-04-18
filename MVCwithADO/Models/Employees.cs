using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithADO.Models
{
    //POCO class/Entity Class//Model
    public class Employees
    {
        public int EmpID { get; set; }
        public string EmpName {  get; set; }
        public double Salary { get; set; }
        public string Job {  get; set; }
        public int DeptID {  get; set; }
    }
}