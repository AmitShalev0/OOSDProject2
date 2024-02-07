namespace TravelExpertsMaintenance
{
    partial class frmAddMofidyPackages
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dgvCurrentProducts = new DataGridView();
            dgvProductsToAdd = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            btnAddProduct = new Button();
            txtPackageID = new TextBox();
            txtPackageName = new TextBox();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            txtDescription = new TextBox();
            txtBasePrice = new TextBox();
            txtCommission = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductsToAdd).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 69);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Package ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 69);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 1;
            label2.Text = "Package Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(134, 173);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Start Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(140, 229);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 3;
            label4.Text = "End Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(128, 127);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 4;
            label5.Text = "Description:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(583, 173);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 5;
            label6.Text = "Base Price:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(516, 232);
            label7.Name = "label7";
            label7.Size = new Size(146, 20);
            label7.TabIndex = 6;
            label7.Text = "Agency Commission:";
            // 
            // dgvCurrentProducts
            // 
            dgvCurrentProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentProducts.Location = new Point(12, 334);
            dgvCurrentProducts.Name = "dgvCurrentProducts";
            dgvCurrentProducts.RowHeadersWidth = 51;
            dgvCurrentProducts.Size = new Size(498, 201);
            dgvCurrentProducts.TabIndex = 7;
            // 
            // dgvProductsToAdd
            // 
            dgvProductsToAdd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductsToAdd.Location = new Point(589, 334);
            dgvProductsToAdd.Name = "dgvProductsToAdd";
            dgvProductsToAdd.RowHeadersWidth = 51;
            dgvProductsToAdd.Size = new Size(498, 201);
            dgvProductsToAdd.TabIndex = 8;
            dgvProductsToAdd.CellClick += dgvProductsToAdd_CellClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 300);
            label8.Name = "label8";
            label8.Size = new Size(225, 20);
            label8.TabIndex = 9;
            label8.Text = "Current products in this package:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(583, 300);
            label9.Name = "label9";
            label9.Size = new Size(223, 20);
            label9.TabIndex = 10;
            label9.Text = "Other available products to add:";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(515, 380);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(68, 29);
            btnAddProduct.TabIndex = 11;
            btnAddProduct.Text = "<";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // txtPackageID
            // 
            txtPackageID.Location = new Point(219, 62);
            txtPackageID.Name = "txtPackageID";
            txtPackageID.Size = new Size(125, 27);
            txtPackageID.TabIndex = 12;
            // 
            // txtPackageName
            // 
            txtPackageName.Location = new Point(526, 62);
            txtPackageName.Name = "txtPackageName";
            txtPackageName.Size = new Size(276, 27);
            txtPackageName.TabIndex = 13;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(219, 173);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(186, 27);
            dtpStartDate.TabIndex = 14;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(219, 224);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(186, 27);
            dtpEndDate.TabIndex = 15;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(219, 120);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(583, 27);
            txtDescription.TabIndex = 16;
            // 
            // txtBasePrice
            // 
            txtBasePrice.Location = new Point(677, 166);
            txtBasePrice.Name = "txtBasePrice";
            txtBasePrice.Size = new Size(125, 27);
            txtBasePrice.TabIndex = 17;
            // 
            // txtCommission
            // 
            txtCommission.Location = new Point(677, 229);
            txtCommission.Name = "txtCommission";
            txtCommission.Size = new Size(125, 27);
            txtCommission.TabIndex = 18;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(838, 62);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 19;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(838, 118);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddMofidyPackages
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(1095, 556);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtCommission);
            Controls.Add(txtBasePrice);
            Controls.Add(txtDescription);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(txtPackageName);
            Controls.Add(txtPackageID);
            Controls.Add(btnAddProduct);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dgvProductsToAdd);
            Controls.Add(dgvCurrentProducts);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAddMofidyPackages";
            Text = "frmAddMofidyPackages";
            Load += frmAddMofidyPackages_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCurrentProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductsToAdd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvCurrentProducts;
        private DataGridView dgvProductsToAdd;
        private Label label8;
        private Label label9;
        private Button btnAddProduct;
        private TextBox txtPackageID;
        private TextBox txtPackageName;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private TextBox txtDescription;
        private TextBox txtBasePrice;
        private TextBox txtCommission;
        private Button btnOk;
        private Button btnCancel;
    }
}