using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class City
    {
        public List<BO.City> GetCities(int StateID)
        {

            List<BO.City> lstCity = new List<BO.City>();

            DAL.City objCity = new DAL.City();

            lstCity= objCity.GetCities(StateID);
            return lstCity;

        }
    }
}
