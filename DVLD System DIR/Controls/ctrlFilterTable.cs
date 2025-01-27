using DVLD_System.Utils;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_System.Controls
{
    public partial class ctrlFilterTable : UserControl
    {
        public KeyValuePair<string, bool>[] Choices;
        public DataTable dt;
        public ctrlFilterTable()
        {
            InitializeComponent();
        }

        public DataGridViewRow GetSelectedRow()
        {
            return dgvUtils.GetSelectedRow(ref dgvTable);
        }

        public int GetSelectedPK()
        {
            return dgvUtils.GetSelectedPK(ref dgvTable);    
        }

        /// <summary>
        /// Initializes the properties of the filter of the given table
        /// </summary>
        /// <param name="cmsDataTableActions">The context menu strip used for the given data grid view</param>
        /// <param name="dt">The data table used to initialize the data grid view</param>
        /// <param name="choices">The choices of the filters combo box ,the key represent the column name and the value reperesents wether the column uses an is like statement.</param>
        public void InitializeProperties(ContextMenuStrip cmsDataTableActions, DataTable dt, params KeyValuePair<string, bool>[] choices)
        {
            // Initialize variables
            this.Choices = choices;
            dgvTable.ContextMenuStrip = cmsDataTableActions;
            this.dt = dt;
            dgvTable.DataSource = dt;

            // Initialize ComboBox items
            foreach(KeyValuePair<string, bool> choice in choices)
            {
                cbFilter.Items.Add(choice.Key);
            }
            cbFilter.SelectedIndex = 0;
        }

        public void FilterTable(int Choice, string FilterValue)
        {
            string FilterColumn = Choices[Choice].Key;
            bool isLikeStatement = Choices[Choice].Value;
            dgvTable.DataSource = DataTableUtils.GetFilteredTable(dt, FilterColumn, FilterValue, isLikeStatement);
        }
        
        public void RefreshTable(DataTable dataTable)
        {
            this.dt = dataTable;
            dgvTable.DataSource = dt;
        }

        private void tbFilterParams_TextChanged(object sender, EventArgs e)
        {
            string FilterValue = tbFilterParams.Text;
            int Choice = cbFilter.SelectedIndex;

            if (tbFilterParams.Text.Length > 0 )
            {
                FilterTable(Choice, FilterValue);
            }
            else
            {
                dgvTable.DataSource = dt;
            }
        }
    }
}
