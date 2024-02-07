namespace TravelExpertsMaintenance
{
    partial class frmAddModifySuppliers
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
            txtSupplierName = new TextBox();
            txtSupplierID = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 44);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 0;
            label1.Text = "Supplier ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 87);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 1;
            label2.Text = "Supplier Name:";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(162, 84);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(125, 27);
            txtSupplierName.TabIndex = 2;
            // 
            // txtSupplierID
            // 
            txtSupplierID.Location = new Point(162, 41);
            txtSupplierID.Name = "txtSupplierID";
            txtSupplierID.Size = new Size(125, 27);
            txtSupplierID.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(47, 169);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(193, 169);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifySuppliers
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(375, 256);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtSupplierID);
            Controls.Add(txtSupplierName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAddModifySuppliers";
            Text = "frmAddModifySuppliers";
            Load += frmAddModifySuppliers_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtSupplierName;
        private TextBox txtSupplierID;
        private Button btnOk;
        private Button btnCancel;
    }
}