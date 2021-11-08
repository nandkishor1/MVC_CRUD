using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DAL
{
    public class City
    {
        string ConStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public List<BO.City> GetCities(int StateID)
        {
            List<BO.City> lstCity = new List<BO.City>(); 

            using (SqlConnection cn = new SqlConnection(ConStr))
            {
                try {
                    SqlCommand cmd = new SqlCommand("prc_GetCities", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("StateID", SqlDbType.Int).Value = StateID;
                    cn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BO.City objCity = new BO.City();
                        objCity.CityID = Convert.ToInt32(dr["N_CityID"]);
                        objCity.CityName = Convert.ToString(dr["VC_CityName"]);

                        lstCity.Add(objCity);
                    }
                
                dr.Close();
                cn.Close();
            }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();

                }
                finally
                {
                    if (cn.State == ConnectionState.Open)
                        cn.Close();

                }
            }
            return lstCity;
        }
    }
}
