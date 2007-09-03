using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using cSouza.Framework.File.CSV;

using Sinapse.Data;
using AForge;

namespace Sinapse.Controls
{
    internal partial class NetworkDataQueryControl : Sinapse.Controls.NetworkDataControl
    {

        #region Constructor
        public NetworkDataQueryControl()
        {
            InitializeComponent();
        }
        #endregion

        //----------------------------------------

        #region Properties
        #endregion

        //----------------------------------------

        #region Public Methods
        internal void Compute(NeuralNetwork neuralNetwork)
        {
            this.dataGridView.EndEdit();
            this.dataGridView.CurrentCell = null;

            double[] input;
            double[] output;

            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                input = this.m_networkData.NormalizeRow(row, this.m_networkData.NetworkSchema.InputColumns);
                output = neuralNetwork.ActivationNetwork.Compute(input);
                this.m_networkData.RevertRow(row, this.m_networkData.NetworkSchema.OutputColumns, output);
            }
        }


        /// <summary>
        /// Iterates the DataTable and validates categorical input fields
        /// </summary>
        /// <returns>Returns true in case of success, false otherwise</returns>
        internal bool ValidateInput()
        {
            bool success = true;

            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                foreach (string columnName in this.m_networkData.NetworkSchema.InputColumns)
                {
                    //Check if field is indeed a category
                    if (Array.IndexOf(this.m_networkData.NetworkSchema.StringColumns, columnName) >= 0)
                    {
                        string strData = (string)row[columnName];
                        if (this.m_networkData.NetworkSchema.DataCategories.GetID(columnName, strData) < 0)
                        {
                            row.RowError = "Invalid data at column " + columnName;
                            return false;
                        }
                    }
                }
         
            }
            return success;
        }

        /// <summary>
        /// Interates the DataTable and rounds non-categorical output fields
        /// </summary>
        internal void Round()
        {
            foreach (DataRow row in this.m_networkData.DataTable.Rows)
            {
                foreach (string columnName in this.m_networkData.NetworkSchema.OutputColumns)
                {
                    //Check if field isn't a category
                    if (Array.IndexOf(this.m_networkData.NetworkSchema.StringColumns, columnName) == -1)
                    {
                        double value = Double.Parse((string)row[columnName]);
                        row[columnName] = Math.Round(value).ToString();
                    }
                }
            }
        }
        #endregion

        //----------------------------------------

        #region Private Methods
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            CsvFileParserOptions options = new CsvFileParserOptions(openFileDialog.FileName);
            options.AutoDetectCsvDelimiter = true;
            options.HeadersAction = HeadersAction.UseAsColumnNames;
            try
            {
                DataTable table = CsvParser.Parse(options);

                this.m_networkData.DataTable.Clear();
                this.m_networkData.DataTable.Merge(table, true, MissingSchemaAction.Ignore);
            }
            catch
            {
                MessageBox.Show("Erro ao abrir arquivo");
            }
        }
        #endregion

    }
}

