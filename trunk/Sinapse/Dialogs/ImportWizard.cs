using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using WizardBase;

using cSouza.Framework.File.CSV;

using Sinapse.Data;

namespace Sinapse.Dialogs
{

    internal sealed partial class ImportWizard : Form
    {

        private DataTable m_dataTable;
        private NetworkSchema m_networkSchema;

        //---------------------------------------------

        #region Constructor
        public ImportWizard()
        {
            InitializeComponent();
        }
        #endregion

        //---------------------------------------------

        #region Public Methods
        internal NetworkData GetNetworkData()
        {
            return new NetworkData(m_networkSchema, m_dataTable);
        }

        internal DataTable GetDataTable()
        {
            return m_dataTable;
        }

        internal NetworkSchema GetSchema()
        {
            return m_networkSchema;
        }
        #endregion

        //---------------------------------------------

        #region Wizard Events
        private void wizardControl_NextButtonClick(WizardControl sender, WizardNextButtonClickEventArgs e)
        {
            switch (wizardControl.CurrentStepIndex)
            {
                case 0:
                    m_dataTable = null;
                    break;

                case 1:
                    if (File.Exists(tbDatapath.Text))
                    {
                        loadDataTable();
                        loadInputCombobox();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                    break;

                case 2:
                    loadOutputCombobox();
                    break;

                case 3:
                    break;

                default:
                    break;
            }
        }

        private void wizardControl_CancelButtonClick(object sender, EventArgs e)
        {
            this.m_dataTable = null;
            this.Close();
        }

        private void wizardControl_FinishButtonClick(object sender, EventArgs e)
        {

            List<String> inputColumns = new List<String>();
            foreach (string strColumn in clbInput.CheckedItems)
                inputColumns.Add(strColumn);

            List<String> outputColumns = new List<String>();
            foreach (string strColumn in clbOutput.CheckedItems)
                outputColumns.Add(strColumn);

            List<String> stringColumns = new List<String>();
            foreach (string strColumn in clbString.CheckedItems)
                stringColumns.Add(strColumn);


            //Remove unusable columns
            List<DataColumn> removeCols = new List<DataColumn>();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                if (!inputColumns.Contains(col.ColumnName) &&
                    !outputColumns.Contains(col.ColumnName))
                    removeCols.Add(col);
            }

            foreach(DataColumn col in removeCols)
                m_dataTable.Columns.Remove(col);
            

            //Create Network Schema
            this.m_networkSchema = new NetworkSchema(
                inputColumns.ToArray(),
                outputColumns.ToArray(),
                stringColumns.ToArray());
//            this.networkData = new NetworkData(schema, m_dataTable);
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        //---------------------------------------------

        #region Load Controls
        private void loadDataTable()
        {
            this.m_dataTable = CsvParser.Parse(tbDatapath.Text, Encoding.Default, true);
        }

        private void loadInputCombobox()
        {
            clbInput.Items.Clear();
            clbString.Items.Clear();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                clbInput.Items.Add(col.ColumnName, false);
                clbString.Items.Add(col.ColumnName, false);
            }
        }

        private void loadOutputCombobox()
        {
            clbOutput.Items.Clear();
            foreach (DataColumn col in m_dataTable.Columns)
            {
                if (!clbInput.CheckedItems.Contains(col.ColumnName))
                    clbOutput.Items.Add(col.ColumnName, false);
            }
        }
        #endregion

        //---------------------------------------------

        #region Buttons
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                tbDatapath.Text = openFileDialog.FileName;
        }
        #endregion


    }
}