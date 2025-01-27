using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLDBuisnessLayer
{
    public class TestType
    {
        
        public int TestTypeID { get; set; }
        public string TestTypeName { get; set; }
        public string TestTypeDesc { get; set; }
        public decimal TestTypeFee { get; set; }

        private TestType(int TestTypeID, string TestTypeName, string TestTypeDesc, decimal TestTypeFee)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeName = TestTypeName;   
            this.TestTypeFee = TestTypeFee;
            this.TestTypeDesc = TestTypeDesc;
        }


        private bool _Update()
        {
            bool result = TestTypesAccess.UpdateTestType(TestTypeID, TestTypeName, TestTypeDesc, TestTypeFee);

            return result;
        }

        public bool Save()
        {
            return _Update();
        }
        
        
        public static TestType Find(int TestTypeID)
        {
            string testTypeName = "", testTypeDesc = "";
            decimal testTypeFee = -1;

            bool result = TestTypesAccess.GetTestTypeByID(TestTypeID, ref testTypeName, ref testTypeDesc, ref testTypeFee);

             if(result is true)
             {
                return new TestType(TestTypeID, testTypeName, testTypeDesc, testTypeFee);
             }

             return null;
        }

        public static DataTable GetAllTestTypes()
        {
            return TestTypesAccess.GetAllTestTypes();
        }
    }
}
