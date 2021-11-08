using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL
{
    public class Department
    {

        string conStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


        public List<SelectListItem> GetDepartments()

        {
            List<SelectListItem> lstDepartment = new List<SelectListItem>();
            using (SqlConnection scn = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("prc_GetDepartment", scn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        scn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            // BO.Department objDepartment = new BO.Department();
                            SelectListItem obj = new SelectListItem();

                            obj.Value = Convert.ToString(dr["PID"]);
                            obj.Text = Convert.ToString(dr["VC_DepartmentName"]);
                            lstDepartment.Add(obj);
                        }
                        dr.Close();
                        scn.Close();

                    }
                    catch(Exception ex)
                    {
                        string msg = ex.Message;
                    }
                    finally
                    {
                        if (scn.State == System.Data.ConnectionState.Open)
                            scn.Close();
                    }
                }
                return lstDepartment;
            }
        }

    }
}
