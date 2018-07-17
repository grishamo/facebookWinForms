namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    partial class Form1
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
            this.FbLogin = new System.Windows.Forms.Button();
            this.NewsList = new System.Windows.Forms.ListBox();
            this.FbLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FbLogin
            // 
            this.FbLogin.Location = new System.Drawing.Point(238, 26);
            this.FbLogin.Name = "FbLogin";
            this.FbLogin.Size = new System.Drawing.Size(134, 23);
            this.FbLogin.TabIndex = 0;
            this.FbLogin.Text = "Facebook Connect";
            this.FbLogin.UseVisualStyleBackColor = true;
            this.FbLogin.Click += new System.EventHandler(this.FbLogin_Click);
            // 
            // NewsList
            // 
            this.NewsList.FormattingEnabled = true;
            this.NewsList.Location = new System.Drawing.Point(35, 95);
            this.NewsList.Name = "NewsList";
            this.NewsList.Size = new System.Drawing.Size(309, 264);
            this.NewsList.TabIndex = 1;
            // 
            // FbLogout
            // 
            this.FbLogout.Location = new System.Drawing.Point(387, 26);
            this.FbLogout.Name = "FbLogout";
            this.FbLogout.Size = new System.Drawing.Size(134, 23);
            this.FbLogout.TabIndex = 2;
            this.FbLogout.Text = "Facebook Logout";
            this.FbLogout.UseVisualStyleBackColor = true;
            this.FbLogout.Click += new System.EventHandler(this.FbLogout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 467);
            this.Controls.Add(this.FbLogout);
            this.Controls.Add(this.NewsList);
            this.Controls.Add(this.FbLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FbLogin;
        private System.Windows.Forms.ListBox NewsList;
        private System.Windows.Forms.Button FbLogout;
    }
}

