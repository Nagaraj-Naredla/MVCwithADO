using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContoViewDatshar.Models
{
    public static class EmpDataContext
    {
        public static List<Emp> GetEmployees()
        {
            return new List<Emp>()
            {
                new Emp() { EmpId = 33, EmpName = "Nagaraj", EmpSalary = 85858 },
                new Emp() { EmpId = 34, EmpName = "Arun", EmpSalary = 65757 },
                new Emp() { EmpId = 37, EmpName = "Uday", EmpSalary = 85658 },
                new Emp() { EmpId = 10, EmpName = "Tanishq", EmpSalary = 76767 },
                new Emp() { EmpId = 9, EmpName = "Ashok", EmpSalary = 76756 },
            };
        }
        public static Emp GetEmployee(int empId)
        {
            List<Emp> emps = GetEmployees();
            foreach (var item in emps)
            {
                if(item.EmpId == empId)
                {
                    return item;
                }
            }
            return new Emp();
        }
    }
}