namespace Sinapse.WinForms.Editors.AdaptiveSystems.Controls
{
    partial class ActivationNetworkOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivationNetworkOptions));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.cbActivationFunction = new System.Windows.Forms.ComboBox();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.activationFunctionView = new Sinapse.WinForms.Controls.Controls.ActivationFunctionView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.networkLayersEditor = new Sinapse.WinForms.Editors.AdaptiveSystems.Controls.LayersControl();
            this.networkDiagram1 = new Sinapse.Diagramming.NetworkDiagram();
            this.groupBox2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPlot);
            this.groupBox2.Controls.Add(this.cbActivationFunction);
            this.groupBox2.Controls.Add(this.propertyGrid);
            this.groupBox2.Controls.Add(this.activationFunctionView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 221);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Activation Function";
            // 
            // btnPlot
            // 
            this.btnPlot.Location = new System.Drawing.Point(189, 17);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(48, 23);
            this.btnPlot.TabIndex = 3;
            this.btnPlot.Text = "Plot";
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // cbActivationFunction
            // 
            this.cbActivationFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivationFunction.FormattingEnabled = true;
            this.cbActivationFunction.Location = new System.Drawing.Point(6, 19);
            this.cbActivationFunction.Name = "cbActivationFunction";
            this.cbActivationFunction.Size = new System.Drawing.Size(177, 21);
            this.cbActivationFunction.TabIndex = 0;
            this.cbActivationFunction.SelectedIndexChanged += new System.EventHandler(this.cbActivationFunction_SelectedIndexChanged);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.propertyGrid.Location = new System.Drawing.Point(6, 46);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(231, 169);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.Validated += new System.EventHandler(this.propertyGrid_Validated);
            // 
            // activationFunctionView
            // 
            this.activationFunctionView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.activationFunctionView.Derivative = Sinapse.WinForms.Controls.Controls.ActivationFunctionView.FunctionDerivative.None;
            this.activationFunctionView.Domain = ((AForge.DoubleRange)(resources.GetObject("activationFunctionView.Domain")));
            this.activationFunctionView.Function = null;
            this.activationFunctionView.Location = new System.Drawing.Point(243, 19);
            this.activationFunctionView.Name = "activationFunctionView";
            this.activationFunctionView.Size = new System.Drawing.Size(349, 196);
            this.activationFunctionView.Steps = ((uint)(1u));
            this.activationFunctionView.TabIndex = 2;
            this.activationFunctionView.Text = "activationFunctionView1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(598, 448);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.networkDiagram1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(115, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Diagram";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.networkLayersEditor);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(115, 223);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hidden Layers";
            // 
            // networkLayersEditor
            // 
            this.networkLayersEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkLayersEditor.Layers = new int[0];
            this.networkLayersEditor.Location = new System.Drawing.Point(3, 16);
            this.networkLayersEditor.Name = "networkLayersEditor";
            this.networkLayersEditor.Size = new System.Drawing.Size(109, 204);
            this.networkLayersEditor.TabIndex = 5;
            // 
            // networkDiagram1
            // 
            this.networkDiagram1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkDiagram1.Location = new System.Drawing.Point(3, 16);
            this.networkDiagram1.Name = "networkDiagram1";
            this.networkDiagram1.Size = new System.Drawing.Size(477, 204);
            this.networkDiagram1.TabIndex = 0;
            // 
            // ActivationNetworkOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ActivationNetworkOptions";
            this.Size = new System.Drawing.Size(598, 448);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbActivationFunction;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private Sinapse.WinForms.Controls.Controls.ActivationFunctionView activationFunctionView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private LayersControl networkLayersEditor;
        private System.Windows.Forms.Button btnPlot;
        private Sinapse.Diagramming.NetworkDiagram networkDiagram1;

    }
}
