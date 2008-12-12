using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sinapse.Core.Sources;

namespace Sinapse.Documents
{
    public partial class TableDataSourceEditor : DockContent, IDocument
    {

        private TableDataSource tableSource;


        public TableDataSourceEditor(TableDataSource source)
        {
            InitializeComponent();

            this.tableSource = source;
        //    this.tableSource.NameChanged += new EventHandler(tableSource_NameChanged);

            this.updateName();
        }

        private void tableSource_NameChanged(object sender, EventArgs e)
        {
            this.updateName();
        }

        private void updateName()
        {
            this.Text = String.Format("{0} - Data Source Editor", this.tableSource.Name);
        }


        private void TableDataSourceEditor_Load(object sender, EventArgs e)
        {
            if (this.tableSource != null)
            {
                this.dgvViewer.DataSource = this.tableSource.GetData(DataSourceSet.Training);
                this.dgvColumns.DataSource = this.tableSource.Columns;
            }
        }


        #region IDocument Members

        public void Save()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SaveAs()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ToolStripMenuItem[] MenuItems
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public ToolStrip[] ToolStrips
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

    }
}
