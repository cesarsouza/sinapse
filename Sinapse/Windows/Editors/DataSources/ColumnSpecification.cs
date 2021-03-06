using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core;
using Sinapse.Core.Sources;
using Sinapse.WinForms.Dialogs;


namespace Sinapse.WinForms.Editors.DataSources
{
    public partial class ColumnSpecification : DockContent
    {
                private TableDataSource tableSource;

        public ColumnSpecification()
        {
            InitializeComponent();
        }


        public TableDataSource TableSource
        {
            get { return tableSource; }
            set
            {
                tableSource = value;
                updateBinding();
            }
        }

        private void updateBinding()
        {
            dgvColumns.DataSource = tableSource.Columns;
        }
        
    }
}