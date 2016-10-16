namespace QuoteClient
{
    partial class FormQuoteClient
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxTicker = new System.Windows.Forms.ComboBox();
            this.buttonGetStock = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewXMLInNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonGetPortfolio = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxTicker
            // 
            this.comboBoxTicker.FormattingEnabled = true;
            this.comboBoxTicker.Items.AddRange(new object[] {
            "MSFT",
            "INTU",
            "GOOG",
            "IBM"});
            this.comboBoxTicker.Location = new System.Drawing.Point(163, 3);
            this.comboBoxTicker.Name = "comboBoxTicker";
            this.comboBoxTicker.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTicker.TabIndex = 7;
            // 
            // buttonGetStock
            // 
            this.buttonGetStock.Location = new System.Drawing.Point(83, 3);
            this.buttonGetStock.Name = "buttonGetStock";
            this.buttonGetStock.Size = new System.Drawing.Size(75, 23);
            this.buttonGetStock.TabIndex = 6;
            this.buttonGetStock.Text = "Get Stock";
            this.buttonGetStock.UseVisualStyleBackColor = true;
            this.buttonGetStock.Click += new System.EventHandler(this.buttonGetStock_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonGetPortfolio, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 316);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 32);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(405, 281);
            this.dataGridView.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewXMLToolStripMenuItem,
            this.viewXMLInNotepadToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 70);
            // 
            // viewXMLToolStripMenuItem
            // 
            this.viewXMLToolStripMenuItem.Name = "viewXMLToolStripMenuItem";
            this.viewXMLToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.viewXMLToolStripMenuItem.Text = "View XML";
            this.viewXMLToolStripMenuItem.Click += new System.EventHandler(this.viewXMLToolStripMenuItem_Click);
            // 
            // viewXMLInNotepadToolStripMenuItem
            // 
            this.viewXMLInNotepadToolStripMenuItem.Name = "viewXMLInNotepadToolStripMenuItem";
            this.viewXMLInNotepadToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.viewXMLInNotepadToolStripMenuItem.Text = "View XML in Notepad";
            this.viewXMLInNotepadToolStripMenuItem.Click += new System.EventHandler(this.viewXMLInNotepadToolStripMenuItem_Click);
            // 
            // buttonGetPortfolio
            // 
            this.buttonGetPortfolio.Location = new System.Drawing.Point(3, 3);
            this.buttonGetPortfolio.Name = "buttonGetPortfolio";
            this.buttonGetPortfolio.Size = new System.Drawing.Size(75, 23);
            this.buttonGetPortfolio.TabIndex = 7;
            this.buttonGetPortfolio.Text = "Get Portfolio";
            this.buttonGetPortfolio.UseVisualStyleBackColor = true;
            this.buttonGetPortfolio.Click += new System.EventHandler(this.buttonGetPortfolio_Click);
            // 
            // FormQuoteClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 316);
            this.Controls.Add(this.comboBoxTicker);
            this.Controls.Add(this.buttonGetStock);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormQuoteClient";
            this.Text = "Quote Client";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTicker;
        private System.Windows.Forms.Button buttonGetStock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonGetPortfolio;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewXMLInNotepadToolStripMenuItem;




    }
}

