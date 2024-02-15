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
            SuspendLayout();
            // 
            // btnPackages
            // 
            btnPackages.Location = new Point(520, 21);
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
            btnProducts.Location = new Point(12, 21);
            btnProducts.Margin = new Padding(3, 2, 3, 2);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(108, 38);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnSuppliers
            // 
            btnSuppliers.BackColor = Color.Tan;
            btnSuppliers.FlatStyle = FlatStyle.Popup;
            btnSuppliers.Location = new Point(166, 21);
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
            btnProductsSupplier.Location = new Point(338, 21);
            btnProductsSupplier.Margin = new Padding(3, 2, 3, 2);
            btnProductsSupplier.Name = "btnProductsSupplier";
            btnProductsSupplier.Size = new Size(129, 38);
            btnProductsSupplier.TabIndex = 3;
            btnProductsSupplier.Text = "Products/Suppliers";
            btnProductsSupplier.UseVisualStyleBackColor = false;
            btnProductsSupplier.Click += btnProductsSupplier_Click;
            // 
            // frmStart
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(673, 394);
            Controls.Add(btnProductsSupplier);
            Controls.Add(btnSuppliers);
            Controls.Add(btnProducts);
            Controls.Add(btnPackages);
            Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmStart";
            TransparencyKey = Color.Black;
            Load += frmStart_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnPackages;
        private Button btnProducts;
        private Button btnSuppliers;
        private Button btnProductsSupplier;

        public static Image TravelExpertsAppLogo { get; private set; }

        //public static Image matthew_brodeur_DH_u2aV3nGM_unsplash { get; private set; }

    }
}