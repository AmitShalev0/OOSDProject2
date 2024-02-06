namespace TravelExpertsMaintenance
{
    partial class frmAddModifyProducts
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
            txtProductID = new TextBox();
            txtProductName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 65);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Product ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 131);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "Product Name:";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(155, 58);
            txtProductID.Name = "txtProductID";
            txtProductID.ReadOnly = true;
            txtProductID.Size = new Size(125, 27);
            txtProductID.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(155, 128);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(235, 27);
            txtProductName.TabIndex = 3;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(69, 206);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(141, 29);
            btnOk.TabIndex = 4;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(216, 206);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmAddModifyProducts
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(402, 292);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtProductName);
            Controls.Add(txtProductID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmAddModifyProducts";
            Text = "frmAddModifyProducts";
            Load += frmAddModifyProducts_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtProductID;
        private TextBox txtProductName;
        private Button btnOk;
        private Button btnCancel;
    }
}