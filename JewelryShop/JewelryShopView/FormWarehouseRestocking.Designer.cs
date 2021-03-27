
namespace JewelryShopView
{
    partial class FormWarehouseRestocking
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
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(226, 185);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(130, 185);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(189, 138);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(121, 20);
            this.textBoxCount.TabIndex = 13;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(69, 138);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(62, 13);
            this.labelCount.TabIndex = 12;
            this.labelCount.Text = "Пополнить";
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(69, 83);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(63, 13);
            this.labelComponent.TabIndex = 11;
            this.labelComponent.Text = "Компонент";
            // 
            // labelWarehouse
            // 
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(69, 35);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(38, 13);
            this.labelWarehouse.TabIndex = 10;
            this.labelWarehouse.Text = "Склад";
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(189, 83);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(121, 21);
            this.comboBoxComponent.TabIndex = 9;
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(189, 32);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxWarehouse.TabIndex = 8;
            // 
            // FormWarehouseRestocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 229);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.labelWarehouse);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Name = "FormWarehouseRestocking";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelWarehouse;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
    }
}