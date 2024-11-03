namespace QUANLYCHITIEU
{
    partial class Form2
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
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtsotienthunhap = new System.Windows.Forms.TextBox();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.txtchichuthunhap = new System.Windows.Forms.RichTextBox();
            this.btnXoathunhap = new System.Windows.Forms.Button();
            this.btnSuathunhap = new System.Windows.Forms.Button();
            this.btnLuuthunhap = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtttn = new System.Windows.Forms.RichTextBox();
            this.txtstcl = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txttst = new System.Windows.Forms.RichTextBox();
            this.btne = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgv2.Location = new System.Drawing.Point(326, 2);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(477, 321);
            this.dgv2.TabIndex = 23;
            this.dgv2.UseWaitCursor = true;
            this.dgv2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Số tiền";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ngày thu";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ghi chú";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // txtsotienthunhap
            // 
            this.txtsotienthunhap.Location = new System.Drawing.Point(120, 29);
            this.txtsotienthunhap.Name = "txtsotienthunhap";
            this.txtsotienthunhap.Size = new System.Drawing.Size(109, 22);
            this.txtsotienthunhap.TabIndex = 22;
            this.txtsotienthunhap.UseWaitCursor = true;
            // 
            // dtp2
            // 
            this.dtp2.Location = new System.Drawing.Point(118, 68);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(200, 22);
            this.dtp2.TabIndex = 21;
            this.dtp2.UseWaitCursor = true;
            // 
            // txtchichuthunhap
            // 
            this.txtchichuthunhap.Location = new System.Drawing.Point(118, 111);
            this.txtchichuthunhap.Name = "txtchichuthunhap";
            this.txtchichuthunhap.Size = new System.Drawing.Size(200, 48);
            this.txtchichuthunhap.TabIndex = 20;
            this.txtchichuthunhap.Text = "";
            this.txtchichuthunhap.UseWaitCursor = true;
            // 
            // btnXoathunhap
            // 
            this.btnXoathunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoathunhap.Location = new System.Drawing.Point(237, 165);
            this.btnXoathunhap.Name = "btnXoathunhap";
            this.btnXoathunhap.Size = new System.Drawing.Size(83, 27);
            this.btnXoathunhap.TabIndex = 19;
            this.btnXoathunhap.Text = "Xóa";
            this.btnXoathunhap.UseVisualStyleBackColor = true;
            this.btnXoathunhap.UseWaitCursor = true;
            // 
            // btnSuathunhap
            // 
            this.btnSuathunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuathunhap.Location = new System.Drawing.Point(120, 165);
            this.btnSuathunhap.Name = "btnSuathunhap";
            this.btnSuathunhap.Size = new System.Drawing.Size(86, 27);
            this.btnSuathunhap.TabIndex = 17;
            this.btnSuathunhap.Text = "Sửa";
            this.btnSuathunhap.UseVisualStyleBackColor = true;
            this.btnSuathunhap.UseWaitCursor = true;
            // 
            // btnLuuthunhap
            // 
            this.btnLuuthunhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuthunhap.Location = new System.Drawing.Point(11, 164);
            this.btnLuuthunhap.Name = "btnLuuthunhap";
            this.btnLuuthunhap.Size = new System.Drawing.Size(86, 27);
            this.btnLuuthunhap.TabIndex = 18;
            this.btnLuuthunhap.Text = "Lưu";
            this.btnLuuthunhap.UseVisualStyleBackColor = true;
            this.btnLuuthunhap.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Số tiền";
            this.label7.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ngày nhập";
            this.label2.UseWaitCursor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = "Ghi chú";
            this.label10.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "-Thu Nhập-";
            this.label6.UseWaitCursor = true;
            // 
            // txtttn
            // 
            this.txtttn.Location = new System.Drawing.Point(145, 249);
            this.txtttn.Name = "txtttn";
            this.txtttn.Size = new System.Drawing.Size(175, 48);
            this.txtttn.TabIndex = 20;
            this.txtttn.Text = "";
            this.txtttn.UseWaitCursor = true;
            this.txtttn.TextChanged += new System.EventHandler(this.txtttn_TextChanged);
            // 
            // txtstcl
            // 
            this.txtstcl.Location = new System.Drawing.Point(143, 303);
            this.txtstcl.Name = "txtstcl";
            this.txtstcl.Size = new System.Drawing.Size(175, 48);
            this.txtstcl.TabIndex = 20;
            this.txtstcl.Text = "";
            this.txtstcl.UseWaitCursor = true;
            this.txtstcl.TextChanged += new System.EventHandler(this.txtstcl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Số tiền đã dùng";
            this.label1.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số tiền còn lại";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tổng số tiền";
            this.label4.UseWaitCursor = true;
            // 
            // txttst
            // 
            this.txttst.Location = new System.Drawing.Point(145, 194);
            this.txttst.Name = "txttst";
            this.txttst.Size = new System.Drawing.Size(175, 48);
            this.txttst.TabIndex = 20;
            this.txttst.Text = "";
            this.txttst.UseWaitCursor = true;
            // 
            // btne
            // 
            this.btne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btne.Location = new System.Drawing.Point(646, 324);
            this.btne.Name = "btne";
            this.btne.Size = new System.Drawing.Size(83, 27);
            this.btne.TabIndex = 19;
            this.btne.Text = "Chi tiêu";
            this.btne.UseVisualStyleBackColor = true;
            this.btne.UseWaitCursor = true;
            this.btne.Click += new System.EventHandler(this.btne_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(554, 324);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 27);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.UseWaitCursor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1055);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.txtsotienthunhap);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.txtstcl);
            this.Controls.Add(this.txttst);
            this.Controls.Add(this.txtttn);
            this.Controls.Add(this.txtchichuthunhap);
            this.Controls.Add(this.btne);
            this.Controls.Add(this.btnXoathunhap);
            this.Controls.Add(this.btnSuathunhap);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuuthunhap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.TextBox txtsotienthunhap;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.RichTextBox txtchichuthunhap;
        private System.Windows.Forms.Button btnXoathunhap;
        private System.Windows.Forms.Button btnSuathunhap;
        private System.Windows.Forms.Button btnLuuthunhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtttn;
        private System.Windows.Forms.RichTextBox txtstcl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txttst;
        private System.Windows.Forms.Button btne;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnThoat;
    }
}