namespace School
{
    partial class frmStudentEdit
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentEdit = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentPhone = new System.Windows.Forms.TextBox();
            this.txtStudentAddress = new System.Windows.Forms.TextBox();
            this.txtStudentClassID = new System.Windows.Forms.TextBox();
            this.txtStudentLname = new System.Windows.Forms.TextBox();
            this.txtStudentFname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.studentEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 237);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(720, 162);
            this.dataGridView1.TabIndex = 2;
            // 
            // studentEdit
            // 
            this.studentEdit.BackColor = System.Drawing.SystemColors.Control;
            this.studentEdit.Controls.Add(this.label11);
            this.studentEdit.Controls.Add(this.txtStudentID);
            this.studentEdit.Controls.Add(this.btnDelete);
            this.studentEdit.Controls.Add(this.btnSubmit);
            this.studentEdit.Controls.Add(this.label5);
            this.studentEdit.Controls.Add(this.label4);
            this.studentEdit.Controls.Add(this.label3);
            this.studentEdit.Controls.Add(this.label2);
            this.studentEdit.Controls.Add(this.label1);
            this.studentEdit.Controls.Add(this.txtStudentPhone);
            this.studentEdit.Controls.Add(this.txtStudentAddress);
            this.studentEdit.Controls.Add(this.txtStudentClassID);
            this.studentEdit.Controls.Add(this.txtStudentLname);
            this.studentEdit.Controls.Add(this.txtStudentFname);
            this.studentEdit.Location = new System.Drawing.Point(27, 11);
            this.studentEdit.Margin = new System.Windows.Forms.Padding(2);
            this.studentEdit.Name = "studentEdit";
            this.studentEdit.Padding = new System.Windows.Forms.Padding(2);
            this.studentEdit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.studentEdit.Size = new System.Drawing.Size(720, 222);
            this.studentEdit.TabIndex = 4;
            this.studentEdit.TabStop = false;
            this.studentEdit.Text = "ویرایش اطلاعات";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(302, 118);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "کد دانش آموز";
            // 
            // txtStudentID
            // 
            this.txtStudentID.BackColor = System.Drawing.SystemColors.Info;
            this.txtStudentID.Location = new System.Drawing.Point(141, 115);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(137, 20);
            this.txtStudentID.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(141, 156);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(286, 156);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(79, 30);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "ثبت";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(569, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "شماره";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "آدرس";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "کد کلاس";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(540, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام خاوادگی";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(580, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام";
            // 
            // txtStudentPhone
            // 
            this.txtStudentPhone.Location = new System.Drawing.Point(399, 156);
            this.txtStudentPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentPhone.Name = "txtStudentPhone";
            this.txtStudentPhone.Size = new System.Drawing.Size(137, 20);
            this.txtStudentPhone.TabIndex = 0;
            // 
            // txtStudentAddress
            // 
            this.txtStudentAddress.Location = new System.Drawing.Point(142, 31);
            this.txtStudentAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentAddress.Multiline = true;
            this.txtStudentAddress.Name = "txtStudentAddress";
            this.txtStudentAddress.Size = new System.Drawing.Size(137, 60);
            this.txtStudentAddress.TabIndex = 0;
            // 
            // txtStudentClassID
            // 
            this.txtStudentClassID.Location = new System.Drawing.Point(399, 115);
            this.txtStudentClassID.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentClassID.Name = "txtStudentClassID";
            this.txtStudentClassID.Size = new System.Drawing.Size(137, 20);
            this.txtStudentClassID.TabIndex = 0;
            // 
            // txtStudentLname
            // 
            this.txtStudentLname.Location = new System.Drawing.Point(399, 71);
            this.txtStudentLname.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentLname.Name = "txtStudentLname";
            this.txtStudentLname.Size = new System.Drawing.Size(137, 20);
            this.txtStudentLname.TabIndex = 0;
            // 
            // txtStudentFname
            // 
            this.txtStudentFname.Location = new System.Drawing.Point(399, 38);
            this.txtStudentFname.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentFname.Name = "txtStudentFname";
            this.txtStudentFname.Size = new System.Drawing.Size(137, 20);
            this.txtStudentFname.TabIndex = 0;
            // 
            // frmStudentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 410);
            this.Controls.Add(this.studentEdit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmStudentEdit";
            this.Text = "frmStudentEdit";
            this.Load += new System.EventHandler(this.frmStudentEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.studentEdit.ResumeLayout(false);
            this.studentEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox studentEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentPhone;
        private System.Windows.Forms.TextBox txtStudentAddress;
        private System.Windows.Forms.TextBox txtStudentClassID;
        private System.Windows.Forms.TextBox txtStudentLname;
        private System.Windows.Forms.TextBox txtStudentFname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtStudentID;
    }
}