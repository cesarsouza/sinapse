/***************************************************************************
 *   Sinapse Neural Networking Tool         http://sinapse.googlecode.com  *
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

using Sinapse.Data.Network;


namespace Sinapse.Controls.SideTabControl
{
    internal sealed partial class SidePageSchema : Sinapse.Controls.Base.TabPageControlBase
    {

        private NetworkDatabase networkDatabase;
        private bool readOnly;


        //---------------------------------------------


        #region Constructor
        public SidePageSchema()
        {
            InitializeComponent();
        }
        #endregion


        //---------------------------------------------


        #region Properties
        internal NetworkDatabase NetworkDatabase
        {
            get { return this.networkDatabase; }
            set
            {
                if (value != null)
                {
                    this.Enabled = true;
                    this.networkDatabase = value;
                    this.dataGridView.DataSource = this.networkDatabase.Schema.DataRanges.Table;
                    this.networkDatabase.DatabaseChanged += new EventHandler(database_DatabaseChanged);
                    this.networkDatabase.Schema.DataRanges.FunctionRangeChanged += new EventHandler(database_FunctionRangeChanged);

                    this.database_FunctionRangeChanged(this, EventArgs.Empty);
                }
                else
                {
                    this.Enabled = false;
                    this.dataGridView.DataSource = null;
                    this.networkDatabase = null;
                }
            }
        }

        public bool ReadOnly
        {
            get { return this.readOnly; }
            set
            {
                this.readOnly = value;
                this.dataGridView.ReadOnly = value;
                this.numRangeHigh.Enabled = !value;
                this.numRangeLow.Enabled = !value;
                this.btnAutodetect.Enabled = !value;
            }
        }
        #endregion


        //---------------------------------------------


        #region Object Events
        private void database_DatabaseChanged(object sender, EventArgs e)
        {
        }

        private void database_FunctionRangeChanged(object sender, EventArgs e)
        {
            this.numRangeLow.Value = (decimal)this.networkDatabase.Schema.DataRanges.ActivationFunctionRange.Min;
            this.numRangeHigh.Value = (decimal)this.networkDatabase.Schema.DataRanges.ActivationFunctionRange.Max;
        }
        #endregion


        //---------------------------------------------


        #region Control Events
        private void btnAutodetect_Click(object sender, EventArgs e)
        {
            this.networkDatabase.Schema.DataRanges.AutodetectRanges(this.networkDatabase.DataTable);
        }

        private void numRangeLow_Validating(object sender, CancelEventArgs e)
        {
            if (numRangeLow.Value >= numRangeHigh.Value)
            {
                e.Cancel = true;
            }
        }

        private void numRangeHigh_Validating(object sender, CancelEventArgs e)
        {
            if (numRangeHigh.Value <= numRangeLow.Value)
            {
                e.Cancel = true;
            }
        }

        private void numRangeLow_ValueChanged(object sender, EventArgs e)
        {
            this.networkDatabase.Schema.DataRanges.ActivationFunctionRange.Min = (double)numRangeLow.Value;
        }

        private void numRangeHigh_ValueChanged(object sender, EventArgs e)
        {
            this.networkDatabase.Schema.DataRanges.ActivationFunctionRange.Max = (double)numRangeHigh.Value;
        }
        #endregion


    }
}
