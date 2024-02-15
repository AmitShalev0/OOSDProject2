namespace TravelExpertsMaintenance
{
    partial class frmAddModifyPS
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
            label5 = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            txtProductSupplierID = new TextBox();
            cboProduct = new ComboBox();
            cboSupplier = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 43);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Supplier ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 144);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 4;
            label5.Text = "Supplier Name:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(44, 203);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(271, 203);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtProductSupplierID
            // 
            txtProductSupplierID.Location = new Point(209, 43);
            txtProductSupplierID.Name = "txtProductSupplierID";
            txtProductSupplierID.Size = new Size(125, 27);
            txtProductSupplierID.TabIndex = 7;
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(209, 94);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(151, 28);
            cboProduct.TabIndex = 12;
            // 
            // cboSupplier
            // 
            cboSupplier.FormattingEnabled = true;
            cboSupplier.Location = new Point(209, 144);
            cboSupplier.Name = "cboSupplier";
            cboSupplier.Size = new Size(151, 28);
            cboSupplier.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 94);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 2;
            label3.Text = "Product Name:";
            // 
            // frmAddModifyPS
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(428, 273);
            Controls.Add(cboSupplier);
            Controls.Add(cboProduct);
            Controls.Add(txtProductSupplierID);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "frmAddModifyPS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add/Modify";
            Load += frmAddModify_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label5;
        private Button btnOK;
        private Button btnCancel;
        private TextBox txtProductSupplierID;
        private ComboBox cboProduct;
        private ComboBox cboSupplier;
        private Label label3;
    }
}