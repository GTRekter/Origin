namespace OriginStudio.Forms
{
    partial class FormDetail
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
            this.lbFormName = new System.Windows.Forms.Label();
            this.tbFormName = new System.Windows.Forms.TextBox();
            this.lbFormType = new System.Windows.Forms.Label();
            this.cbFormType = new System.Windows.Forms.ComboBox();
            this.btnExecuteForm = new System.Windows.Forms.Button();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.lbInput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.SuspendLayout();
            // 
            // lbFormName
            // 
            this.lbFormName.AutoSize = true;
            this.lbFormName.Location = new System.Drawing.Point(13, 78);
            this.lbFormName.Name = "lbFormName";
            this.lbFormName.Size = new System.Drawing.Size(134, 25);
            this.lbFormName.TabIndex = 0;
            this.lbFormName.Text = "lbFormName";
            // 
            // tbFormName
            // 
            this.tbFormName.Location = new System.Drawing.Point(174, 78);
            this.tbFormName.Name = "tbFormName";
            this.tbFormName.Size = new System.Drawing.Size(346, 31);
            this.tbFormName.TabIndex = 1;
            this.tbFormName.Text = "tbFormName";
            // 
            // lbFormType
            // 
            this.lbFormType.AutoSize = true;
            this.lbFormType.Location = new System.Drawing.Point(605, 78);
            this.lbFormType.Name = "lbFormType";
            this.lbFormType.Size = new System.Drawing.Size(126, 25);
            this.lbFormType.TabIndex = 2;
            this.lbFormType.Text = "lbFormType";
            // 
            // cbFormType
            // 
            this.cbFormType.FormattingEnabled = true;
            this.cbFormType.Items.AddRange(new object[] {
            "Add",
            "Edit"});
            this.cbFormType.Location = new System.Drawing.Point(766, 78);
            this.cbFormType.Name = "cbFormType";
            this.cbFormType.Size = new System.Drawing.Size(346, 33);
            this.cbFormType.TabIndex = 3;
            // 
            // btnExecuteForm
            // 
            this.btnExecuteForm.Location = new System.Drawing.Point(989, 788);
            this.btnExecuteForm.Name = "btnExecuteForm";
            this.btnExecuteForm.Size = new System.Drawing.Size(123, 59);
            this.btnExecuteForm.TabIndex = 8;
            this.btnExecuteForm.Text = "btnExecuteForm";
            this.btnExecuteForm.UseVisualStyleBackColor = true;
            this.btnExecuteForm.Click += new System.EventHandler(this.btnExecuteForm_Click);
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInput.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Location = new System.Drawing.Point(17, 208);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowTemplate.Height = 33;
            this.dataGridViewInput.Size = new System.Drawing.Size(1095, 547);
            this.dataGridViewInput.TabIndex = 9;
            this.dataGridViewInput.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewInput_UserAddedRow);
            this.dataGridViewInput.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewInput_UserDeletingRow);
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Location = new System.Drawing.Point(13, 165);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(76, 25);
            this.lbInput.TabIndex = 10;
            this.lbInput.Text = "lbInput";
            // 
            // FormDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 859);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.dataGridViewInput);
            this.Controls.Add(this.btnExecuteForm);
            this.Controls.Add(this.cbFormType);
            this.Controls.Add(this.lbFormType);
            this.Controls.Add(this.tbFormName);
            this.Controls.Add(this.lbFormName);
            this.Name = "FormDetail";
            this.Text = "DetailForm";
            this.Load += new System.EventHandler(this.DetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFormName;
        private System.Windows.Forms.TextBox tbFormName;
        private System.Windows.Forms.Label lbFormType;
        private System.Windows.Forms.ComboBox cbFormType;
        private System.Windows.Forms.Button btnExecuteForm;
        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.Label lbInput;
    }
}