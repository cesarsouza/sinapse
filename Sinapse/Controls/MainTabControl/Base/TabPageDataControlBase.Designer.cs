namespace Sinapse.Controls.MainTabControl.Base
{
    partial class TabPageDataControlBase
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelOutputCaption = new System.Windows.Forms.Panel();
            this.panelInputCaption = new System.Windows.Forms.Panel();
            this.lbOutput = new System.Windows.Forms.Label();
            this.dataGridView = new Sinapse.Forms.Controls.DataGridViewEx();
            this.lbInput = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeRowsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopyTraining = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopyValidation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopyTesting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCopyQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuCopyClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSetTitle = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOutputCaption
            // 
            this.panelOutputCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOutputCaption.BackColor = System.Drawing.Color.AliceBlue;
            this.panelOutputCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOutputCaption.Location = new System.Drawing.Point(72, 377);
            this.panelOutputCaption.Name = "panelOutputCaption";
            this.panelOutputCaption.Size = new System.Drawing.Size(14, 12);
            this.panelOutputCaption.TabIndex = 25;
            // 
            // panelInputCaption
            // 
            this.panelInputCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInputCaption.BackColor = System.Drawing.Color.Honeydew;
            this.panelInputCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputCaption.Location = new System.Drawing.Point(3, 377);
            this.panelInputCaption.Name = "panelInputCaption";
            this.panelInputCaption.Size = new System.Drawing.Size(14, 12);
            this.panelInputCaption.TabIndex = 26;
            // 
            // lbOutput
            // 
            this.lbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbOutput.AutoSize = true;
            this.lbOutput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.Location = new System.Drawing.Point(89, 378);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(53, 11);
            this.lbOutput.TabIndex = 23;
            this.lbOutput.Text = "Output";
            // 
            // lbInput
            // 
            this.lbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(21, 378);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(45, 11);
            this.lbInput.TabIndex = 24;
            this.lbInput.Text = "Input";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridView.Location = new System.Drawing.Point(3, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(582, 337);
            this.dataGridView.TabIndex = 22;
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeRowsToToolStripMenuItem,
            this.MenuTraining,
            this.MenuValidation,
            this.MenuTesting,
            this.toolStripSeparator1,
            this.MenuCopy,
            this.MenuPaste});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 164);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // changeRowsToToolStripMenuItem
            // 
            this.changeRowsToToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeRowsToToolStripMenuItem.Name = "changeRowsToToolStripMenuItem";
            this.changeRowsToToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.changeRowsToToolStripMenuItem.Text = "Mark rows as";
            // 
            // MenuTraining
            // 
            this.MenuTraining.Name = "MenuTraining";
            this.MenuTraining.Size = new System.Drawing.Size(160, 22);
            this.MenuTraining.Text = "Training data";
            this.MenuTraining.Click += new System.EventHandler(this.MenuTraining_Click);
            // 
            // MenuValidation
            // 
            this.MenuValidation.Name = "MenuValidation";
            this.MenuValidation.Size = new System.Drawing.Size(160, 22);
            this.MenuValidation.Text = "Validation data";
            this.MenuValidation.Click += new System.EventHandler(this.MenuValidation_Click);
            // 
            // MenuTesting
            // 
            this.MenuTesting.Name = "MenuTesting";
            this.MenuTesting.Size = new System.Drawing.Size(160, 22);
            this.MenuTesting.Text = "Testing data";
            this.MenuTesting.Click += new System.EventHandler(this.MenuTesting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // MenuCopy
            // 
            this.MenuCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCopyTraining,
            this.MenuCopyValidation,
            this.MenuCopyTesting,
            this.MenuCopyQuery,
            this.toolStripSeparator2,
            this.MenuCopyClipboard});
            this.MenuCopy.Image = global::Sinapse.Properties.Resources.edit_copy;
            this.MenuCopy.Name = "MenuCopy";
            this.MenuCopy.Size = new System.Drawing.Size(160, 22);
            this.MenuCopy.Text = "Copy To...";
            // 
            // MenuCopyTraining
            // 
            this.MenuCopyTraining.Name = "MenuCopyTraining";
            this.MenuCopyTraining.Size = new System.Drawing.Size(169, 22);
            this.MenuCopyTraining.Text = "Training";
            this.MenuCopyTraining.Click += new System.EventHandler(this.MenuCopyTraining_Click);
            // 
            // MenuCopyValidation
            // 
            this.MenuCopyValidation.Name = "MenuCopyValidation";
            this.MenuCopyValidation.Size = new System.Drawing.Size(169, 22);
            this.MenuCopyValidation.Text = "Validation";
            this.MenuCopyValidation.Click += new System.EventHandler(this.MenuCopyValidation_Click);
            // 
            // MenuCopyTesting
            // 
            this.MenuCopyTesting.Name = "MenuCopyTesting";
            this.MenuCopyTesting.Size = new System.Drawing.Size(169, 22);
            this.MenuCopyTesting.Text = "Testing";
            this.MenuCopyTesting.Click += new System.EventHandler(this.MenuCopyTesting_Click);
            // 
            // MenuCopyQuery
            // 
            this.MenuCopyQuery.Enabled = false;
            this.MenuCopyQuery.Name = "MenuCopyQuery";
            this.MenuCopyQuery.Size = new System.Drawing.Size(169, 22);
            this.MenuCopyQuery.Text = "Query";
            this.MenuCopyQuery.Click += new System.EventHandler(this.MenuCopyQuery_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // MenuCopyClipboard
            // 
            this.MenuCopyClipboard.Image = global::Sinapse.Properties.Resources.edit_copy;
            this.MenuCopyClipboard.Name = "MenuCopyClipboard";
            this.MenuCopyClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.MenuCopyClipboard.Size = new System.Drawing.Size(169, 22);
            this.MenuCopyClipboard.Text = "Clipboard";
            this.MenuCopyClipboard.Click += new System.EventHandler(this.MenuCopyClipboard_Click);
            // 
            // MenuPaste
            // 
            this.MenuPaste.Image = global::Sinapse.Properties.Resources.edit_paste;
            this.MenuPaste.Name = "MenuPaste";
            this.MenuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.MenuPaste.Size = new System.Drawing.Size(160, 22);
            this.MenuPaste.Text = "Paste";
            this.MenuPaste.Click += new System.EventHandler(this.MenuPaste_Click);
            // 
            // lbSetTitle
            // 
            this.lbSetTitle.AutoSize = true;
            this.lbSetTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetTitle.Location = new System.Drawing.Point(7, 5);
            this.lbSetTitle.Name = "lbSetTitle";
            this.lbSetTitle.Size = new System.Drawing.Size(102, 23);
            this.lbSetTitle.TabIndex = 28;
            this.lbSetTitle.Text = "Set Name";
            // 
            // openFileDialog
            // 
            this.openFileDialog.ReadOnlyChecked = true;
            this.openFileDialog.ShowReadOnly = true;
            this.openFileDialog.Title = "Import Data";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Image = global::Sinapse.Properties.Resources.network_22;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.Location = new System.Drawing.Point(515, 372);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 23);
            this.btnImport.TabIndex = 27;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // TabPageDataControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSetTitle);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.panelInputCaption);
            this.Controls.Add(this.panelOutputCaption);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.dataGridView);
            this.DoubleBuffered = true;
            this.Name = "TabPageDataControlBase";
            this.Size = new System.Drawing.Size(588, 398);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel panelOutputCaption;
        private System.Windows.Forms.Panel panelInputCaption;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label lbInput;
        protected Sinapse.Forms.Controls.DataGridViewEx dataGridView;
        protected internal System.Windows.Forms.Label lbSetTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        protected internal System.Windows.Forms.BindingSource BindingSource;
        private System.Windows.Forms.ToolStripMenuItem changeRowsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuTraining;
        private System.Windows.Forms.ToolStripMenuItem MenuValidation;
        private System.Windows.Forms.ToolStripMenuItem MenuTesting;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuCopyTraining;
        private System.Windows.Forms.ToolStripMenuItem MenuCopyValidation;
        private System.Windows.Forms.ToolStripMenuItem MenuCopyTesting;
        private System.Windows.Forms.ToolStripMenuItem MenuCopyQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuCopyClipboard;
        private System.Windows.Forms.ToolStripMenuItem MenuPaste;
    }
}
