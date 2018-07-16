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
            this.LikesList = new System.Windows.Forms.ListBox();
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
            // LikesList
            // 
            this.LikesList.FormattingEnabled = true;
            this.LikesList.Location = new System.Drawing.Point(35, 95);
            this.LikesList.Name = "LikesList";
            this.LikesList.Size = new System.Drawing.Size(309, 264);
            this.LikesList.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 467);
            this.Controls.Add(this.LikesList);
            this.Controls.Add(this.FbLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FbLogin;
        private System.Windows.Forms.ListBox LikesList;
    }
}

