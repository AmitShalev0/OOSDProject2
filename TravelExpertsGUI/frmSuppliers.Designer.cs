namespace TravelExpertsMaintenance
{
    partial class frmSuppliers
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
            dgvData = new DataGridView();
            btnExit = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Location = new Point(12, 71);
            dgvData.Name = "dgvData";
            dgvData.RowHeadersWidth = 51;
            dgvData.Size = new Size(777, 366);
            dgvData.TabIndex = 0;
            dgvData.CellClick += dgvData_CellClick;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(625, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(83, 27);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // frmSuppliers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(btnExit);
            Controls.Add(dgvData);
            Name = "frmSuppliers";
            Text = "frmSuppliers";
            Load += frmSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private Button btnExit;
        private Button btnAdd;
    }
}