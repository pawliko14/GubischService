namespace AplikacjaGubisch
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tenonMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chipBreakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenonVisiorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sawUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unloadStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profileMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbeamTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalSpindlePOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spindle1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spindle2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spindle3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grooveSpindleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guidensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ConnectionBox = new System.Windows.Forms.TextBox();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tenonMachineToolStripMenuItem,
            this.profileMachineToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tenonMachineToolStripMenuItem
            // 
            this.tenonMachineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chipBreakerToolStripMenuItem,
            this.tenonVisiorToolStripMenuItem,
            this.sawUnitToolStripMenuItem,
            this.unloadStationToolStripMenuItem});
            this.tenonMachineToolStripMenuItem.Name = "tenonMachineToolStripMenuItem";
            this.tenonMachineToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.tenonMachineToolStripMenuItem.Text = "Tenon Machine";
            // 
            // chipBreakerToolStripMenuItem
            // 
            this.chipBreakerToolStripMenuItem.Name = "chipBreakerToolStripMenuItem";
            this.chipBreakerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.chipBreakerToolStripMenuItem.Text = "Chip Breaker";
            this.chipBreakerToolStripMenuItem.Click += new System.EventHandler(this.chipBreakerToolStripMenuItem_Click);
            // 
            // tenonVisiorToolStripMenuItem
            // 
            this.tenonVisiorToolStripMenuItem.Name = "tenonVisiorToolStripMenuItem";
            this.tenonVisiorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tenonVisiorToolStripMenuItem.Text = "Tenon Visior";
            this.tenonVisiorToolStripMenuItem.Click += new System.EventHandler(this.tenonVisiorToolStripMenuItem_Click);
            // 
            // sawUnitToolStripMenuItem
            // 
            this.sawUnitToolStripMenuItem.Name = "sawUnitToolStripMenuItem";
            this.sawUnitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sawUnitToolStripMenuItem.Text = "Saw Unit";
            this.sawUnitToolStripMenuItem.Click += new System.EventHandler(this.sawUnitToolStripMenuItem_Click);
            // 
            // unloadStationToolStripMenuItem
            // 
            this.unloadStationToolStripMenuItem.Name = "unloadStationToolStripMenuItem";
            this.unloadStationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unloadStationToolStripMenuItem.Text = "Unload Station";
            this.unloadStationToolStripMenuItem.Click += new System.EventHandler(this.unloadStationToolStripMenuItem_Click);
            // 
            // profileMachineToolStripMenuItem
            // 
            this.profileMachineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanTableToolStripMenuItem,
            this.feedbeamTableToolStripMenuItem,
            this.horizontalSpindlePOSToolStripMenuItem,
            this.guidensToolStripMenuItem});
            this.profileMachineToolStripMenuItem.Name = "profileMachineToolStripMenuItem";
            this.profileMachineToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.profileMachineToolStripMenuItem.Text = "Profile Machine";
            // 
            // cleanTableToolStripMenuItem
            // 
            this.cleanTableToolStripMenuItem.Name = "cleanTableToolStripMenuItem";
            this.cleanTableToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cleanTableToolStripMenuItem.Text = "Clean table";
            this.cleanTableToolStripMenuItem.Click += new System.EventHandler(this.cleanTableToolStripMenuItem_Click);
            // 
            // feedbeamTableToolStripMenuItem
            // 
            this.feedbeamTableToolStripMenuItem.Name = "feedbeamTableToolStripMenuItem";
            this.feedbeamTableToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.feedbeamTableToolStripMenuItem.Text = "Feedbeam table";
            this.feedbeamTableToolStripMenuItem.Click += new System.EventHandler(this.feedbeamTableToolStripMenuItem_Click);
            // 
            // horizontalSpindlePOSToolStripMenuItem
            // 
            this.horizontalSpindlePOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spindle1ToolStripMenuItem,
            this.spindle2ToolStripMenuItem,
            this.spindle3ToolStripMenuItem,
            this.grooveSpindleToolStripMenuItem});
            this.horizontalSpindlePOSToolStripMenuItem.Name = "horizontalSpindlePOSToolStripMenuItem";
            this.horizontalSpindlePOSToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.horizontalSpindlePOSToolStripMenuItem.Text = "Horizontal spindle POS";
            // 
            // spindle1ToolStripMenuItem
            // 
            this.spindle1ToolStripMenuItem.Name = "spindle1ToolStripMenuItem";
            this.spindle1ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.spindle1ToolStripMenuItem.Text = "Spindle 1";
            this.spindle1ToolStripMenuItem.Click += new System.EventHandler(this.spindle1ToolStripMenuItem_Click);
            // 
            // spindle2ToolStripMenuItem
            // 
            this.spindle2ToolStripMenuItem.Name = "spindle2ToolStripMenuItem";
            this.spindle2ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.spindle2ToolStripMenuItem.Text = "Spindle 2";
            this.spindle2ToolStripMenuItem.Click += new System.EventHandler(this.spindle2ToolStripMenuItem_Click);
            // 
            // spindle3ToolStripMenuItem
            // 
            this.spindle3ToolStripMenuItem.Name = "spindle3ToolStripMenuItem";
            this.spindle3ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.spindle3ToolStripMenuItem.Text = "Spindle 3";
            this.spindle3ToolStripMenuItem.Click += new System.EventHandler(this.spindle3ToolStripMenuItem_Click);
            // 
            // grooveSpindleToolStripMenuItem
            // 
            this.grooveSpindleToolStripMenuItem.Name = "grooveSpindleToolStripMenuItem";
            this.grooveSpindleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.grooveSpindleToolStripMenuItem.Text = "Groove Spindle";
            this.grooveSpindleToolStripMenuItem.Click += new System.EventHandler(this.grooveSpindleToolStripMenuItem_Click);
            // 
            // guidensToolStripMenuItem
            // 
            this.guidensToolStripMenuItem.Name = "guidensToolStripMenuItem";
            this.guidensToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.guidensToolStripMenuItem.Text = "Guidens";
            this.guidensToolStripMenuItem.Click += new System.EventHandler(this.guidensToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ConnectionBox
            // 
            this.ConnectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionBox.Enabled = false;
            this.ConnectionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ConnectionBox.Location = new System.Drawing.Point(643, 4);
            this.ConnectionBox.Name = "ConnectionBox";
            this.ConnectionBox.ReadOnly = true;
            this.ConnectionBox.Size = new System.Drawing.Size(145, 21);
            this.ConnectionBox.TabIndex = 1;
            this.ConnectionBox.Text = "Verbindung";
            this.ConnectionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeBox
            // 
            this.TimeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeBox.Enabled = false;
            this.TimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TimeBox.Location = new System.Drawing.Point(530, 5);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.ReadOnly = true;
            this.TimeBox.Size = new System.Drawing.Size(107, 20);
            this.TimeBox.TabIndex = 2;
            this.TimeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.ConnectionBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tenonMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chipBreakerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenonVisiorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sawUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unloadStationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbeamTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalSpindlePOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spindle1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spindle2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spindle3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grooveSpindleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guidensToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox ConnectionBox;
        private System.Windows.Forms.TextBox TimeBox;
    }
}