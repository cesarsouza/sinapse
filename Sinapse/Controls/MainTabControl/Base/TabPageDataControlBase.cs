/***************************************************************************
 *   Sinapse Neural Network Tool         http://code.google.com/p/sinapse/ *
 *  ---------------------------------------------------------------------- *
 *   Copyright (C) 2006-2008 Cesar Roberto de Souza <cesarsouza@gmail.com> *
 *                                                                         *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 3 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Sinapse.Data;
using Sinapse.Data.CsvParser;

using Dotnetrix.Controls;

namespace Sinapse.Controls.MainTabControl.Base
{
    internal partial class TabPageDataControlBase : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkContainer m_networkContainer;
        private NetworkDatabase m_networkDatabase;
        
        private NetworkSet m_networkSet;


        public EventHandler DataSelectionChanged;

       
        //----------------------------------------


        #region Constructor
        protected TabPageDataControlBase()
        {
            InitializeComponent();

         
              this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer,
        //      ControlStyles.ResizeRedraw,
              true);
          
        }
        #endregion


        //----------------------------------------


        #region Properties
        internal NetworkContainer NetworkContainer
        {
            get { return this.m_networkContainer; }
            set
            {
                this.m_networkContainer = value;
                this.OnCurrentNetworkChanged();
            }
        }

        internal NetworkDatabase NetworkDatabase
        {
            get { return this.m_networkDatabase; }
            set
            {
                this.m_networkDatabase = value;
                this.OnCurrentDatabaseChanged();
            }
        }

        internal int ItemCount
        {
            get { return this.BindingSource.Count; }
        }

        internal int SelectedItemCount
        {
            get { return this.dataGridView.SelectedRows.Count; }
        }
        #endregion


        //----------------------------------------


        #region Virtual Methods
        protected virtual void OnDataImported(DataTable table)
        {
            this.NetworkDatabase.ImportData(table, GetNetworkSet(), 0);
        }

        protected virtual void OnCurrentDatabaseChanged()
        {
            if (this.NetworkDatabase != null)
            {
                DataView dv = new DataView(this.NetworkDatabase.DataTable);
                dv.RowFilter = this.GetFilterString();
              
                this.BindingSource.DataSource = dv;
                this.setColumns();

                this.UpdateTitle();
            }
        }

        protected virtual void OnCurrentNetworkChanged()
        {
            
        }

        protected virtual void OnRowValidating(DataRowView row)
        {
            row.Row[NetworkDatabase.ColumnRoleId] = (ushort)m_networkSet;
        }

        protected virtual void OnSelectionChanged()
        {
            if (this.DataSelectionChanged != null)
                this.DataSelectionChanged.Invoke(this, EventArgs.Empty);
        }
        #endregion


        //----------------------------------------


        #region Protected Methods
        protected NetworkSet GetNetworkSet()
        {
            return this.m_networkSet;
        }

        protected string GetFilterString()
        {
            return String.Format("{0}='{1}'", NetworkDatabase.ColumnRoleId, (ushort)this.m_networkSet);
        }

        protected void SetUp(NetworkSet networkSet, string displayName)
        {
            this.m_networkSet = networkSet;
            this.TabPageName = displayName;
            this.lbSetTitle.Text = displayName;
            this.UpdateTitle();
        }

        protected override void UpdateTitle()
        {
            if (this.getTabPage() != null)
                this.getTabPage().Text = String.Format("{0} [{1}]", this.TabPageName, ItemCount);
        }
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                this.dataGridView.AutoGenerateColumns = false;
                this.dataGridView.DataSource = this.BindingSource;
                this.dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
                this.dataGridView.Rows.CollectionChanged += new CollectionChangeEventHandler(Rows_CollectionChanged);
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            this.UpdateTitle();
        }
        #endregion


        //----------------------------------------


        #region Private Methods
        private void setSelections(NetworkSet networkSet, int trainingLayer)
        {
            if (this.dataGridView.SelectedRows.Count == 0)
            {
                this.setCurrent(this.dataGridView.CurrentRow, networkSet, trainingLayer);
            }
            else
            {
                foreach (DataGridViewRow viewRow in this.dataGridView.SelectedRows)
                {
                    this.setCurrent(viewRow, networkSet, trainingLayer);
                }
            }

            this.BindingSource.ResetBindings(false);
        }

        private void setCurrent(DataGridViewRow viewRow, NetworkSet networkSet, int trainingLayer)
        {
            DataRow row = (viewRow.DataBoundItem as DataRowView).Row;
            if (row != null)
            {
                row[NetworkDatabase.ColumnRoleId] = networkSet;
                row[NetworkDatabase.ColumnTrainingLayerId] = trainingLayer;
            }
        }

        private void setColumns()
        {
            this.dataGridView.SuspendLayout();
            this.dataGridView.Columns.Clear();

            DataGridViewColumn column;

            foreach (String colName in this.NetworkDatabase.Schema.InputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelInputCaption.BackColor;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.NetworkDatabase.Schema.OutputColumns)
            {
                column = new DataGridViewColumn();
                column.DataPropertyName = colName;
                column.HeaderText = colName;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DefaultCellStyle.BackColor = panelOutputCaption.BackColor;
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                this.dataGridView.Columns.Add(column);
            }

            foreach (String colName in this.NetworkDatabase.Schema.StringColumns)
            {
                if (this.dataGridView.Columns.Contains(colName))
                    this.dataGridView.Columns[colName].HeaderText = dataGridView.Columns[colName].DataPropertyName + " [C]";
            }

#if SHOW_HIDDEN_COLUMNS
            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnRoleId;
            column.HeaderText = NetworkDatabase.ColumnRoleId;
            column.CellTemplate = new DataGridViewTextBoxCell();
            this.dataGridView.Columns.Add(column);

            column = new DataGridViewColumn();
            column.DataPropertyName = NetworkDatabase.ColumnTrainingLayerId;
            column.HeaderText = NetworkDatabase.ColumnTrainingLayerId;
            column.CellTemplate = new DataGridViewTextBoxCell();
            this.dataGridView.Columns.Add(column);
#endif
            this.ResumeLayout(true);
        }
        #endregion


        //----------------------------------------


        #region Data Import
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                this.OnDataImported(CsvParser.Parse(openFileDialog.FileName, Encoding.Default, true, CsvDelimiter.Tabulation));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening file");
                throw ex;
            }

        }
        #endregion


        //----------------------------------------


        #region DataGridView Menus
        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {

            DataRowView drv = (BindingSource.Current as DataRowView);

            if (drv == null)
                return;

            this.MenuTesting.Checked = false;
            this.MenuTraining.Checked = false;
            this.MenuValidation.Checked = false;


            if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Testing)
                this.MenuTesting.Checked = true;
            else if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Training)
                this.MenuTraining.Checked = true;
            else if ((NetworkSet)drv.Row[NetworkDatabase.ColumnRoleId] == NetworkSet.Validation)
                this.MenuValidation.Checked = true;


            //Populate Training Menu

            ToolStripMenuItem[] items = new ToolStripMenuItem[5];
            int layerNumber;

            for (int i = 0; i < items.Length; ++i)
            {
                layerNumber = (UInt16)(i + 1);
                items[i] = new ToolStripMenuItem();
                items[i].Checked = drv.Row[NetworkDatabase.ColumnTrainingLayerId].Equals(layerNumber);
                items[i].Text = layerNumber.ToString();
                items[i].Tag = layerNumber;
                items[i].Click += new EventHandler(layerMenuItem_Click);
            }

            this.MenuTraining.DropDownItems.Clear();
            this.MenuTraining.DropDownItems.AddRange(items);

        }

        private void layerMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item.Tag is int)
            {
                this.setSelections(NetworkSet.Training, (int)item.Tag);
            }
        }

        private void MenuTraining_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Training, 1);
        }

        private void MenuValidation_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Validation, 0);
        }

        private void MenuTesting_Click(object sender, EventArgs e)
        {
            this.setSelections(NetworkSet.Testing, 0);
        }
        #endregion


        #region DataGridView Events
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged();
        }

        private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            this.UpdateTitle();
        }

        /// <summary>
        /// Provides paste support for the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                DataObject d = dataGridView.GetClipboardContent();
                Clipboard.SetDataObject(d);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int row = this.dataGridView.CurrentCell.RowIndex;
                int col = this.dataGridView.CurrentCell.ColumnIndex;

                foreach (string line in lines)
                {

                    if (row < dataGridView.RowCount && line.Length > 0)
                    {
                        string[] cells = line.Split('\t');

                        for (int i = 0; i < cells.GetLength(0); i++)
                        {
                            if (col + i < this.dataGridView.ColumnCount)
                            {
                                this.dataGridView[col + i, row].Value = Convert.ChangeType(cells[i], dataGridView[col + i, row].ValueType);
                            }
                        }
                        ++row;
                    }
                }
            }
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                DataRowView row = this.dataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;

                if (row != null)
                    this.OnRowValidating(row);
            }
            catch
            {
            }
        }

        #endregion

    }
}
