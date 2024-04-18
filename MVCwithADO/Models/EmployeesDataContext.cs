using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCwithADO.Models
{
    // DataContext Class
    public class EmployeesDataContext
    {
        SqlConnection _connection;
        SqlCommand _command;
        SqlDataReader _reader;
        public EmployeesDataContext()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CompanyDBConn"].ConnectionString);
        }
        public List<Employees> GetEmployees()
        {
            List<Employees> employees = new List<Employees>();

            _command = new SqlCommand("sp_SelectEmps", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            _reader = _command.ExecuteReader();
            if( _reader.HasRows )
            {
                while( _reader.Read())
                {
                    Employees emps = new Employees();
                    emps.EmpID = Convert.ToInt32(_reader["EmpID"]);
                    emps.EmpName = Convert.ToString(_reader["EmpName"]);
                    emps.Salary = Convert.ToDouble(_reader["Salary"]);
                    emps.Job = Convert.ToString(_reader["Job"]);
                    emps.DeptID = Convert.ToInt32(_reader["DeptID"]);
                    employees.Add(emps);
                }
            }
            _reader.Close();
            _connection.Close();
            return employees;

        }
        public int InsertEmployees(Employees emps)
        {
            _command = new SqlCommand("sp_InsertEmps", _connection);
            _command.CommandType= CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empID",emps.EmpID);
            _command.Parameters.AddWithValue("@empName",emps.EmpName);
            _command.Parameters.AddWithValue("@salary", emps.Salary);
            _command.Parameters.AddWithValue("@job", emps.Job);
            _command.Parameters.AddWithValue("@deptID", emps.DeptID);
            _connection.Open();
            int recCount = _command.ExecuteNonQuery();
            _connection.Close();
            return recCount;
            
        }
        public Employees GetEmployee(int empID)
        {
            Employees emps = new Employees();
            _command = new SqlCommand("sp_SelectEmp", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("empID", empID); 
            _connection.Open();
            _reader = _command.ExecuteReader();
            if (_reader.HasRows)
            {
                if (_reader.Read())
                {
                    
                    emps.EmpID = Convert.ToInt32(_reader["EmpID"]);
                    emps.EmpName = Convert.ToString(_reader["EmpName"]);
                    emps.Salary = Convert.ToDouble(_reader["Salary"]);
                    emps.Job = Convert.ToString(_reader["Job"]);
                    emps.DeptID = Convert.ToInt32(_reader["DeptID"]);
                    
                }
            }
            _reader.Close();
            _connection.Close();
            return emps;
        }
        public int UpdateEmps(Employees emps)
        {
            _command = new SqlCommand("sp_UpdateEmps", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empID", emps.EmpID);
            _command.Parameters.AddWithValue("@empName", emps.EmpName);
            _command.Parameters.AddWithValue("@salary", emps.Salary);
            _command.Parameters.AddWithValue("@job", emps.Job);
            _command.Parameters.AddWithValue("@deptID", emps.DeptID);
            _connection.Open();
            int recCount = _command.ExecuteNonQuery();
            _connection.Close();
            return recCount;
        }
        public int DeleteEmployee(int empID)
        {
            _command = new SqlCommand("sp_DeleteEmps", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.AddWithValue("@empID", empID);
            _connection.Open();
            int recCount = _command.ExecuteNonQuery();
            _connection.Close();
            return recCount;
        }

    }
}