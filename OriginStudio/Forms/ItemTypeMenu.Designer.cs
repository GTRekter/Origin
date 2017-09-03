namespace OriginStudio.Forms
{
    partial class ItemTypeMenu
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
            this.btnAddItemType = new System.Windows.Forms.Button();
            this.dataGridViewItemType = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddItemType
            // 
            this.btnAddItemType.Location = new System.Drawing.Point(1275, 86);
            this.btnAddItemType.Name = "btnAddItemType";
            this.btnAddItemType.Size = new System.Drawing.Size(177, 58);
            this.btnAddItemType.TabIndex = 3;
            this.btnAddItemType.Text = "btnAddItemType";
            this.btnAddItemType.UseVisualStyleBackColor = true;
            this.btnAddItemType.Click += new System.EventHandler(this.btnAddItemType_Click);
            // 
            // dataGridViewItemType
            // 
            this.dataGridViewItemType.AllowUserToAddRows = false;
            this.dataGridViewItemType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewItemType.Location = new System.Drawing.Point(12, 168);
            this.dataGridViewItemType.Name = "dataGridViewItemType";
            this.dataGridViewItemType.ReadOnly = true;
            this.dataGridViewItemType.RowTemplate.Height = 33;
            this.dataGridViewItemType.Size = new System.Drawing.Size(1440, 675);
            this.dataGridViewItemType.TabIndex = 2;
            this.dataGridViewItemType.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewItemType_CellContentDoubleClick);
            // 
            // ItemTypeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 855);
            this.Controls.Add(this.btnAddItemType);
            this.Controls.Add(this.dataGridViewItemType);
            this.Name = "ItemTypeMenu";
            this.Text = "ItemTypeMenu";
            this.Load += new System.EventHandler(this.ItemTypeMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddItemType;
        private System.Windows.Forms.DataGridView dataGridViewItemType;
    }
}