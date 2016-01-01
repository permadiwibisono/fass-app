using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASSProject
{
    public class EmployeeControl
    {
        public static Employee getEmployee(Employee emp)
        {
            return EmployeeModel.getEmployee(emp);
        }
    }
}