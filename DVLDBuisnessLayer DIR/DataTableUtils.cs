using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class DataTableUtils
    {
        
        public static void AddRowsToCollection(ref DataRowCollection collection, DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {
                collection.Add(row.ItemArray);
            }
        }

        public static void AddRowsToCollection(ref DataTable collection, DataRow[] rows)
        {
            foreach (DataRow row in rows)
            {
                collection.Rows.Add(row.ItemArray);
            }
        }

        public static DataTable GetFilteredTable(DataTable table, string FilterColumn, string FilterValue, bool isLikeStatement = false)
        {
            DataRow[] filteredRows;
            DataTable tempTable = table.Clone();
            try
            {
                filteredRows = isLikeStatement ? table.Select($"{FilterColumn} like '{FilterValue}%' ") : table.Select($"{FilterColumn} = {FilterValue}");
                AddRowsToCollection(ref tempTable, filteredRows);
            }
            catch (Exception ex)
            {
;               ////////////////////////
            }
            

            

            return tempTable;

        }
    }
}
