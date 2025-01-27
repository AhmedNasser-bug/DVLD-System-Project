using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.Utils
{
    internal class dgvUtils
    {
        public static int GetSelectedPK(ref DataGridView dgv)
        {
            int selectedRowIdx = dgv.SelectedCells[0].RowIndex;
            return Convert.ToInt32(dgv.Rows[selectedRowIdx].Cells[0].Value);
        }

        public static object GetSelectedCell(ref DataGridView dgv, int CellIdx)
        {
            int selectedRowIdx = dgv.SelectedCells[0].RowIndex;
            return dgv.Rows[selectedRowIdx].Cells[CellIdx].Value;
        }

        public static DataGridViewRow GetSelectedRow(ref DataGridView dgv)
        {
            int selectedRowIdx = dgv.SelectedCells[0].RowIndex;
            return dgv.Rows[selectedRowIdx];
        }
    }
}
