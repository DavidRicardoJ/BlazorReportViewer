using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorReportViewer.Data
{
    public class EmployeeService
    {
        public DataTable GetEmployeeInfo()
        {
            var dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Departament");
            dt.Columns.Add("Designation");
            dt.Columns.Add("JoinDate");

            DataRow dr;
            for (int i = 0; i <= 50; i++)
            {
                dr = dt.NewRow();
                dr["Id"] = i;
                dr["Name"] = "David - " +i;
                dr["Departament"] = "Accounts";
                dr["Designation"] = "Sr. Officer";
                dr["JoinDate"] = DateTime.Now.AddYears(-5).AddDays(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
