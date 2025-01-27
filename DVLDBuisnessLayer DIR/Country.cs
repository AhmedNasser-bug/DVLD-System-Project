using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class Country
    {

        public int CountryID { get;  }
        public string Name { get;  }

        private Country(int CountryID, string CountryName)
        { 
            this.CountryID = CountryID;
            this.Name = CountryName;
        }

        public static Country Find(int countryID)
        {
            string countryName = "";
            
            bool result = DVLD_DataAccessLayer.CountriesAccess.GetCountryByID(countryID, ref countryName);

            if (result)
            {
                return new Country(countryID, countryName);
            }

            return null; 
            
        }
        public static Country Find(string name)
        {
            int countryID = -1;

            bool result = CountriesAccess.GetCountryByName(name, ref countryID);

            if (result) {
                return new Country(countryID, name);
            }

            return null;
        }

        public static DataTable CountriesTable()
        {
            DataTable countries = CountriesAccess.GetCountriesTable();

            return countries;
        }

    }
}
