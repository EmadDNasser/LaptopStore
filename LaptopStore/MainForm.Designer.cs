namespace LaptopStore
{
    partial class MainForm
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
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.lblEmailID = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblCart = new System.Windows.Forms.Label();
            this.btnItemCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(12, 10);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(103, 30);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Sign in";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.IndianRed;
            this.btnSignOut.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(12, 12);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(103, 30);
            this.btnSignOut.TabIndex = 2;
            this.btnSignOut.Text = "Sign out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEmailID
            // 
            this.lblEmailID.AutoSize = true;
            this.lblEmailID.BackColor = System.Drawing.Color.White;
            this.lblEmailID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailID.Location = new System.Drawing.Point(121, 16);
            this.lblEmailID.Name = "lblEmailID";
            this.lblEmailID.Size = new System.Drawing.Size(0, 24);
            this.lblEmailID.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 556);
            this.panel1.TabIndex = 4;
            // 
            // LblCart
            // 
            this.LblCart.AutoSize = true;
            this.LblCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCart.Location = new System.Drawing.Point(744, 13);
            this.LblCart.Name = "LblCart";
            this.LblCart.Size = new System.Drawing.Size(53, 20);
            this.LblCart.TabIndex = 7;
            this.LblCart.Text = "Cart: ";
            // 
            // btnItemCount
            // 
            this.btnItemCount.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnItemCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemCount.Enabled = false;
            this.btnItemCount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnItemCount.FlatAppearance.BorderSize = 0;
            this.btnItemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemCount.Image = global::LaptopStore.Properties.Resources.icons_301;
            this.btnItemCount.Location = new System.Drawing.Point(797, 3);
            this.btnItemCount.Name = "btnItemCount";
            this.btnItemCount.Size = new System.Drawing.Size(38, 33);
            this.btnItemCount.TabIndex = 6;
            this.btnItemCount.UseVisualStyleBackColor = false;
            this.btnItemCount.Click += new System.EventHandler(this.ItemCount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.LblCart);
            this.Controls.Add(this.btnItemCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEmailID);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnSignIn);
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lptop Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignOut;
        public System.Windows.Forms.Label lblEmailID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCart;
        public System.Windows.Forms.Button btnItemCount;
    }
}