using System;

namespace Client_Documents
{
    partial class Client_Documents
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lblError = new System.Windows.Forms.Label();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(348, 277);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(378, 72);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(744, 450);
            this.webBrowser1.TabIndex = 4;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(786, 46);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(98, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "לא קיים סקר חוזה";
            this.lblError.Visible = false;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.lblHeader);
            this.radPanel1.Controls.Add(this.listBox1);
            this.radPanel1.Controls.Add(this.lblError);
            this.radPanel1.Controls.Add(this.webBrowser1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1165, 554);
            this.radPanel1.TabIndex = 6;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("David", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHeader.ForeColor = System.Drawing.Color.Blue;
            this.lblHeader.Location = new System.Drawing.Point(437, 21);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHeader.Size = new System.Drawing.Size(151, 21);
            this.lblHeader.TabIndex = 34;
            this.lblHeader.Text = "מסמכי סקר חוזה";
            // 
            // Client_Documents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel1);
            this.Name = "Client_Documents";
            this.Size = new System.Drawing.Size(1165, 554);
            this.Resize += new System.EventHandler(this.Client_Documents_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lblError;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.Label lblHeader;

    }
}
