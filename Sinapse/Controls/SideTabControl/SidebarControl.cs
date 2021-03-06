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

using Dotnetrix.Controls;
using Sinapse.Data.Network;


namespace Sinapse.Controls.SideTabControl
{

    internal sealed partial class SidebarControl : Control
    {

        
        private SidePageDisplay sidePageDisplay;
        private SidePageSchema sidePageRanges;
        private SidePageTrainer sidePageTrainer;
        private SidePageWorkplace sidePageWorkplace;
        private SidePageSolutionExplorer sidePageExplorer;
        private SidePageReport tabReport;
        

        //---------------------------------------------


        #region Constructor
        public SidebarControl()
        {
            InitializeComponent();



            this.setTab(sidePageDisplay, tabContext);

        }
        #endregion


        //----------------------------------------


        #region Control Events
        #endregion


        //---------------------------------------------


        #region Properties
        internal NetworkContainer NetworkContainer
        {
            set
            {
                this.sidePageTrainer.NetworkContainer = value;
                this.sidePageDisplay.NetworkContainer = value;
            }
        }

        internal NetworkDatabase NetworkDatabase
        {
            set 
            {
                this.sidePageTrainer.NetworkDatabase = value;
                this.sidePageRanges.NetworkDatabase = value;
            }
        }

        internal TrainingSession TrainingSession
        {
            set
            {
                this.sidePageTrainer.TrainingSession = value;
            }
        }

        internal NetworkWorkplace Workplace
        {
            set
            {
                this.sidePageExplorer.Workplace = value;
            }
        }
        #endregion


        //---------------------------------------------


        #region TabPages
        internal SidePageDisplay DisplayControl
        {
            get { return this.sidePageDisplay; }
        }

        internal SidePageSchema RangesControl
        {
            get { return this.sidePageRanges; }
        }

        internal SidePageTrainer TrainerControl
        {
            get { return this.sidePageTrainer; }
        }

        internal SidePageWorkplace WorkplaceControl
        {
            get { return this.sidePageWorkplace; }
        }

        internal SidePageSolutionExplorer ExplorerControl
        {
            get { return this.sidePageExplorer; }
        }
        #endregion


        //---------------------------------------------


        #region Private Methods
        private void setTab(UserControl userControl, TabPageEX tabPage)
        {
            userControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add(userControl);
        }
        #endregion



    }
}
