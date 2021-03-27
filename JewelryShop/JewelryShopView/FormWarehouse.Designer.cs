
namespace JewelryShopView
{
    partial class FormWarehouse
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxResponsible = new System.Windows.Forms.TextBox();
            this.labelResponsible = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(384, 359);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(275, 359);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBoxResponsible
            // 
            this.textBoxResponsible.Location = new System.Drawing.Point(133, 51);
            this.textBoxResponsible.Name = "textBoxResponsible";
            this.textBoxResponsible.Size = new System.Drawing.Size(144, 20);
            this.textBoxResponsible.TabIndex = 16;
            // 
            // labelResponsible
            // 
            this.labelResponsible.AutoSize = true;
            this.labelResponsible.Location = new System.Drawing.Point(26, 51);
            this.labelResponsible.Name = "labelResponsible";
            this.labelResponsible.Size = new System.Drawing.Size(87, 13);
            this.labelResponsible.TabIndex = 15;
            this.labelResponsible.Text = "Ответсвенный: ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 20);
            this.textBoxName.TabIndex = 14;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(26, 9);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(63, 13);
            this.LabelName.TabIndex = 13;
            this.LabelName.Text = "Название: ";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(29, 80);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(448, 260);
            this.dataGridView.TabIndex = 12;
            // 
            // Component
            // 
            this.Component.HeaderText = "Компонент";
            this.Component.Name = "Component";
            this.Component.Width = 280;
            // 
            // Count
            // 
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.Width = 130;
            // 
            // FormWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 398);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxResponsible);
            this.Controls.Add(this.labelResponsible);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormWarehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxResponsible;
        private System.Windows.Forms.Label labelResponsible;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}