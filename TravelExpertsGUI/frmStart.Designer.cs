using System.Runtime.CompilerServices;

namespace TravelExpertsMaintenance
{
    partial class frmStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            btnPackages = new Button();
            btnProducts = new Button();
            btnSuppliers = new Button();
            btnProductsSupplier = new Button();
            label1 = new Label();
            label2 = new Label();
            dgvStartfrm = new DataGridView();
            btnStartAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStartfrm).BeginInit();
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(528, 86);
            btnPackages.Margin = new Padding(3, 2, 3, 2);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(95, 38);
            btnPackages.TabIndex = 0;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(27, 86);
            btnProducts.Margin = new Padding(3, 2, 3, 2);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(108, 38);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            //btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.BackColor = Color.Tan;
            btnSuppliers.FlatStyle = FlatStyle.Popup;
            btnSuppliers.Location = new Point(179, 86);
            btnSuppliers.Margin = new Padding(3, 2, 3, 2);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(116, 38);
            btnSuppliers.TabIndex = 2;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = false;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnProductsSupplier
            // 
            btnProductsSupplier.BackColor = Color.Tan;
            btnProductsSupplier.FlatStyle = FlatStyle.Popup;
            btnProductsSupplier.Location = new Point(366, 86);
            btnProductsSupplier.Margin = new Padding(3, 2, 3, 2);
            btnProductsSupplier.Name = "btnProductsSupplier";
            btnProductsSupplier.Size = new Size(129, 38);
            btnProductsSupplier.TabIndex = 3;
            btnProductsSupplier.Text = "Products/Suppliers";
            btnProductsSupplier.UseVisualStyleBackColor = false;
            btnProductsSupplier.Click += btnProductsSupplier_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(609, 32);
            label1.TabIndex = 4;
            label1.Text = "Welcome to Travel Experts data management tool.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(200, 52);
            label2.Name = "label2";
            label2.Size = new Size(254, 32);
            label2.TabIndex = 5;
            label2.Text = "Please select a table.";
            // 
            // dgvStartfrm
            // 
            dgvStartfrm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStartfrm.Location = new Point(12, 129);
            dgvStartfrm.Name = "dgvStartfrm";
            dgvStartfrm.RowHeadersWidth = 51;
            dgvStartfrm.Size = new Size(649, 253);
            dgvStartfrm.TabIndex = 6;
            // 
            // btnStartAdd
            // 
            btnStartAdd.Location = new Point(52, 404);
            btnStartAdd.Name = "btnStartAdd";
            btnStartAdd.Size = new Size(94, 29);
            btnStartAdd.TabIndex = 7;
            btnStartAdd.Text = "&Add";
            btnStartAdd.UseVisualStyleBackColor = true;
            // 
            // frmStart
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(761, 463);
            Controls.Add(btnStartAdd);
            Controls.Add(dgvStartfrm);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnProductsSupplier);
            Controls.Add(btnSuppliers);
            Controls.Add(btnProducts);
            Controls.Add(btnPackages);
            Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Travel Experts";
            TransparencyKey = Color.Black;
            Load += frmStart_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStartfrm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPackages;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnProductsSupplier;
        private Label label1;
        private Label label2;
        private DataGridView dgvStartfrm;
        private Button btnStartAdd;
    }
}