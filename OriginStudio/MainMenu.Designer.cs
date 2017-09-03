namespace OriginStudio
{
    partial class MainMenu
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
            this.btnForm = new System.Windows.Forms.Button();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnItemType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm
            // 
            this.btnForm.Location = new System.Drawing.Point(27, 30);
            this.btnForm.Name = "btnForm";
            this.btnForm.Size = new System.Drawing.Size(304, 91);
            this.btnForm.TabIndex = 0;
            this.btnForm.Text = "btnForm";
            this.btnForm.UseVisualStyleBackColor = true;
            this.btnForm.Click += new System.EventHandler(this.btnForm_Click);
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(27, 148);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(304, 91);
            this.btnLookup.TabIndex = 1;
            this.btnLookup.Text = "btnLookup";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // btnItemType
            // 
            this.btnItemType.Location = new System.Drawing.Point(27, 268);
            this.btnItemType.Name = "btnItemType";
            this.btnItemType.Size = new System.Drawing.Size(304, 91);
            this.btnItemType.TabIndex = 2;
            this.btnItemType.Text = "btnItemType";
            this.btnItemType.UseVisualStyleBackColor = true;
            this.btnItemType.Click += new System.EventHandler(this.btnItemType_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 506);
            this.Controls.Add(this.btnItemType);
            this.Controls.Add(this.btnLookup);
            this.Controls.Add(this.btnForm);
            this.Name = "MainMenu";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnForm;
        private System.Windows.Forms.Button btnLookup;
        private System.Windows.Forms.Button btnItemType;
    }
}