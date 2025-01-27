using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class TestTypesAccess
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeName, ref string TestTypeDesc, ref decimal TestTypeFees)
        {
            string query = "SELECT TestTypeTitle, TestTypeDescription, TestTypeFees from TestTypes where TestTypeID = @TestTypeID";

            List<object> testType = ConnectionUtils.GetRow(query, TestTypeID);

            bool isFound = testType != null;

            if (isFound)
            {
                TestTypeName = testType.ElementAt(0).ToString();
                TestTypeDesc = testType.ElementAt(1).ToString();
                TestTypeFees = Convert.ToDecimal(testType.ElementAt(2));

                return isFound;
            }

            return false;
        }

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDesc,decimal NewFee)
        {
            string query = "UPDATE TestTypes " +
                            "SET TestTypeFees = @TestTypeFees, TestTypeTitle = @TestTypeName, TestTypeDescription = @TestTypeDesc " +
                            "WHERE TestTypeID = @TestTypeID";

            bool result = ConnectionUtils.UpdateTableRow(query, NewFee, TestTypeTitle, TestTypeDesc, TestTypeID); 

            return result;
        }

        public static DataTable GetAllTestTypes()
        {
            string query = "SELECT * FROM TestTypes";

            DataTable dtTestTypes = ConnectionUtils.GetTable(query);

            return dtTestTypes;
        }

    }
}
