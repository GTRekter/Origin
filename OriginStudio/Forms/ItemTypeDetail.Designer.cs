namespace OriginStudio.Forms
{
    partial class ItemTypeDetail
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
            this.lbItemAction = new System.Windows.Forms.Label();
            this.dataGridViewItemAction = new System.Windows.Forms.DataGridView();
            this.tbItemTypeName = new System.Windows.Forms.TextBox();
            this.lbItemTypeName = new System.Windows.Forms.Label();
            this.btnExecuteItemType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemAction)).BeginInit();
            this.SuspendLayout();
            // 
            // lbItemAction
            // 
            this.lbItemAction.AutoSize = true;
            this.lbItemAction.Location = new System.Drawing.Point(12, 127);
            this.lbItemAction.Name = "lbItemAction";
            this.lbItemAction.Size = new System.Drawing.Size(89, 25);
            this.lbItemAction.TabIndex = 14;
            this.lbItemAction.Text = "lbAction";
            // 
            // dataGridViewItemAction
            // 
            this.dataGridViewItemAction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemAction.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewItemAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemAction.Location = new System.Drawing.Point(16, 170);
            this.dataGridViewItemAction.Name = "dataGridViewItemAction";
            this.dataGridViewItemAction.RowTemplate.Height = 33;
            this.dataGridViewItemAction.Size = new System.Drawing.Size(1095, 547);
            this.dataGridViewItemAction.TabIndex = 13;
            this.dataGridViewItemAction.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewItemAction_UserAddedRow);
            this.dataGridViewItemAction.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewItemAction_UserDeletingRow);
            // 
            // tbItemTypeName
            // 
            this.tbItemTypeName.Location = new System.Drawing.Point(191, 40);
            this.tbItemTypeName.Name = "tbItemTypeName";
            this.tbItemTypeName.Size = new System.Drawing.Size(346, 31);
            this.tbItemTypeName.TabIndex = 12;
            this.tbItemTypeName.Text = "tbItemTypeName";
            // 
            // lbItemTypeName
            // 
            this.lbItemTypeName.AutoSize = true;
            this.lbItemTypeName.Location = new System.Drawing.Point(12, 40);
            this.lbItemTypeName.Name = "lbItemTypeName";
            this.lbItemTypeName.Size = new System.Drawing.Size(173, 25);
            this.lbItemTypeName.TabIndex = 11;
            this.lbItemTypeName.Text = "lbItemTypeName";
            // 
            // btnExecuteItemType
            // 
            this.btnExecuteItemType.Location = new System.Drawing.Point(988, 723);
            this.btnExecuteItemType.Name = "btnExecuteItemType";
            this.btnExecuteItemType.Size = new System.Drawing.Size(123, 59);
            this.btnExecuteItemType.TabIndex = 15;
            this.btnExecuteItemType.Text = "btnExecuteItemType";
            this.btnExecuteItemType.UseVisualStyleBackColor = true;
            this.btnExecuteItemType.Click += new System.EventHandler(this.btnExecuteItemType_Click);
            // 
            // ItemTypeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 792);
            this.Controls.Add(this.btnExecuteItemType);
            this.Controls.Add(this.lbItemAction);
            this.Controls.Add(this.dataGridViewItemAction);
            this.Controls.Add(this.tbItemTypeName);
            this.Controls.Add(this.lbItemTypeName);
            this.Name = "ItemTypeDetail";
            this.Text = "ItemTypeDetail";
            this.Load += new System.EventHandler(this.ItemTypeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbItemAction;
        private System.Windows.Forms.DataGridView dataGridViewItemAction;
        private System.Windows.Forms.TextBox tbItemTypeName;
        private System.Windows.Forms.Label lbItemTypeName;
        private System.Windows.Forms.Button btnExecuteItemType;
    }
}