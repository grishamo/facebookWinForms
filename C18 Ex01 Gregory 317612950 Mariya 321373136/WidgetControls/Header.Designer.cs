namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    partial class Header
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
            this.UserName = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.userPic = new System.Windows.Forms.PictureBox();
            this.HeaderPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UserName.AutoSize = true;
            this.UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.UserName.Location = new System.Drawing.Point(727, 21);
            this.UserName.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(0, 13);
            this.UserName.TabIndex = 2;
            this.UserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Logo.Image = global::C18_Ex01_Gregory_317612950_Mariya_321373136.Properties.Resources.Logo;
            this.Logo.Location = new System.Drawing.Point(20, 21);
            this.Logo.Margin = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(124, 18);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // userPic
            // 
            this.userPic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.userPic.Location = new System.Drawing.Point(732, 10);
            this.userPic.Margin = new System.Windows.Forms.Padding(0);
            this.userPic.Name = "userPic";
            this.userPic.Size = new System.Drawing.Size(34, 34);
            this.userPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userPic.TabIndex = 1;
            this.userPic.TabStop = false;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.ColumnCount = 3;
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.4918F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.50819F));
            this.HeaderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.HeaderPanel.Controls.Add(this.UserName, 1, 0);
            this.HeaderPanel.Controls.Add(this.userPic, 2, 0);
            this.HeaderPanel.Controls.Add(this.Logo, 0, 0);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.RowCount = 1;
            this.HeaderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.HeaderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.HeaderPanel.Size = new System.Drawing.Size(782, 55);
            this.HeaderPanel.TabIndex = 4;
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            this.Controls.Add(this.HeaderPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Header";
            this.Size = new System.Drawing.Size(782, 55);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userPic)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.PictureBox userPic;
        private System.Windows.Forms.TableLayoutPanel HeaderPanel;
    }
}
