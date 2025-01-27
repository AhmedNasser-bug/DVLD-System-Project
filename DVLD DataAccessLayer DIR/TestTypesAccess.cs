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
        /// <summary>
        /// Gets the Test Type with the given TestTypeID and fills the given ref parameters with the TestType details.
        /// </summary>
        /// <returns>True if the TestType is found, false otherwise</returns>
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

        /// <summary>
        /// Updates the test type with the given test type ID.
        /// </summary>
        /// <returns>True if the test type is found and successfully updated, false otherwise.</returns>
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDesc,decimal NewFee)
        {
            string query = "UPDATE TestTypes " +
                            "SET TestTypeFees = @TestTypeFees, TestTypeTitle = @TestTypeName, TestTypeDescription = @TestTypeDesc " +
                            "WHERE TestTypeID = @TestTypeID";

            bool result = ConnectionUtils.UpdateTableRow(query, NewFee, TestTypeTitle, TestTypeDesc, TestTypeID); 

            return result;
        }

        /// <summary>
        /// Gets a table contining all test types
        /// </summary>
        /// <returns>A DataTable object containing all test typesa</returns>
        public static DataTable GetAllTestTypes()
        {
            string query = "SELECT * FROM TestTypes";

            DataTable dtTestTypes = ConnectionUtils.GetTable(query);

            return dtTestTypes;
        }

    }
}
