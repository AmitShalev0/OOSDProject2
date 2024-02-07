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
            btnPackages = new Button();
            btnProducts = new Button();
            btnSuppliers = new Button();
            btnProductsSupplier = new Button();
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(60, 48);
            btnPackages.Name = "btnPackages";
            btnPackages.Size = new Size(159, 92);
            btnPackages.TabIndex = 0;
            btnPackages.Text = "Packages";
            btnPackages.UseVisualStyleBackColor = true;
            btnPackages.Click += btnPackages_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(60, 161);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(159, 92);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.Location = new Point(60, 283);
            btnSuppliers.Name = "btnSuppliers";
            btnSuppliers.Size = new Size(159, 92);
            btnSuppliers.TabIndex = 2;
            btnSuppliers.Text = "Suppliers";
            btnSuppliers.UseVisualStyleBackColor = true;
            btnSuppliers.Click += btnSuppliers_Click;
            // 
            // btnProductsSupplier
            // 
            btnProductsSupplier.Location = new Point(60, 398);
            btnProductsSupplier.Name = "btnProductsSupplier";
            btnProductsSupplier.Size = new Size(159, 92);
            btnProductsSupplier.TabIndex = 3;
            btnProductsSupplier.Text = "Products/Suppliers";
            btnProductsSupplier.UseVisualStyleBackColor = true;
            btnProductsSupplier.Click += btnProductsSupplier_Click;
            // 
            // frmStart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 525);
            Controls.Add(btnProductsSupplier);
            Controls.Add(btnSuppliers);
            Controls.Add(btnProducts);
            Controls.Add(btnPackages);
            Name = "frmStart";
            Text = "frmStart";
            ResumeLayout(false);
        }

        #endregion

        private Button btnPackages;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnProductsSupplier;
    }
}