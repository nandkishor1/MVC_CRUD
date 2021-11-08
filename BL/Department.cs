using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL
{
    public class Department
    {
        public List<SelectListItem> GetDepartments()
        {
            List<SelectListItem> lstDepartment = new List<SelectListItem>();
            DAL.Department objDepartment = new DAL.Department();
            lstDepartment = objDepartment.GetDepartments();
            return lstDepartment;
        }
    }
}
