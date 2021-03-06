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
using Sinapse.Data.Network;
using Sinapse.Forms.Dialogs;


namespace Sinapse.Controls.MainTabControl
{

    internal sealed partial class TabPageTesting : Sinapse.Controls.MainTabControl.Base.TabPageDataControlBase
    {

        //----------------------------------------


        #region Constructor
        public TabPageTesting()
        {
            InitializeComponent();
            SetUp(NetworkSet.Testing, "Testing Set");
        }
        #endregion


        //----------------------------------------


        #region Properties
        #endregion


        //----------------------------------------


        #region Control Events
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnCurrentDatabaseChanged()
        {
            base.OnCurrentDatabaseChanged();

            this.setTabPageEnabled(this.NetworkDatabase != null);

            if (this.NetworkDatabase != null)
            {
             //   DataGridViewColumn column;

                foreach (String colName in this.NetworkDatabase.Schema.OutputColumns)
                {

                    this.dataGridView.Columns.Add(this.CreateColumn(
                        colName + " (network)", 
                        NetworkDatabase.ColumnComputedPrefix + colName,
                        panelNetworkCaption.BackColor));

                    this.dataGridView.Columns.Add(this.CreateColumn(
                        colName + " (deviation)",
                        NetworkDatabase.ColumnDeltaPrefix + colName,
                        panelDeltaCaption.BackColor));

                }
            }
        }

        protected override void OnCurrentNetworkChanged()
        {
            base.OnCurrentNetworkChanged();

            btnCompare.Enabled = (this.NetworkContainer != null);
            btnQuery.Enabled = (this.NetworkContainer != null);
        }
        #endregion


        //----------------------------------------


        #region Buttons
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Compute();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            this.Compare();
        }

        private void btnRound_Click(object sender, EventArgs e)
        {
            this.EndEdit();
            this.NetworkDatabase.Round(true);
        }
        #endregion


        //----------------------------------------


        #region Public Methods
        public void Compute()
        {
            this.EndEdit();
            this.NetworkDatabase.ComputeTable(this.NetworkContainer, true);
        }

        public void Compare()
        {
            new NetworkReportDialog(this.NetworkContainer, this.NetworkDatabase).ShowDialog(this);
        }
        #endregion


        //----------------------------------------


        #region Private Methods



        #endregion


    }
}
