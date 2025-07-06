namespace CoffeeCafeProject
{
    partial class FrmMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMember));
            this.label1 = new System.Windows.Forms.Label();
            this.lvShowAllMember = new System.Windows.Forms.ListView();
            this.tbMemberName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMemberPhone = new System.Windows.Forms.TextBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMemberId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SaddleBrown;
            this.label1.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(120, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 55);
            this.label1.TabIndex = 28;
            this.label1.Text = "จัดการข้อมูลสมาชิก";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvShowAllMember
            // 
            this.lvShowAllMember.HideSelection = false;
            this.lvShowAllMember.Location = new System.Drawing.Point(29, 177);
            this.lvShowAllMember.Name = "lvShowAllMember";
            this.lvShowAllMember.Size = new System.Drawing.Size(422, 312);
            this.lvShowAllMember.TabIndex = 46;
            this.lvShowAllMember.UseCompatibleStateImageBehavior = false;
            // 
            // tbMemberName
            // 
            this.tbMemberName.Location = new System.Drawing.Point(301, 139);
            this.tbMemberName.Name = "tbMemberName";
            this.tbMemberName.Size = new System.Drawing.Size(150, 20);
            this.tbMemberName.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 43;
            this.label3.Text = "ชื่อสมาชิก";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 42;
            this.label2.Text = "เบอร์โทรสมาชิก";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMemberPhone
            // 
            this.tbMemberPhone.Location = new System.Drawing.Point(125, 139);
            this.tbMemberPhone.Name = "tbMemberPhone";
            this.tbMemberPhone.Size = new System.Drawing.Size(150, 20);
            this.tbMemberPhone.TabIndex = 40;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::CoffeeCafeProject.Properties.Resources.cofffeelogo;
            this.pictureBox12.Location = new System.Drawing.Point(484, 22);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(55, 55);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 30;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::CoffeeCafeProject.Properties.Resources.cofffeelogo;
            this.pictureBox11.Location = new System.Drawing.Point(28, 22);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(55, 55);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 29;
            this.pictureBox11.TabStop = false;
            // 
            // btClose
            // 
            this.btClose.Image = global::CoffeeCafeProject.Properties.Resources.cancel;
            this.btClose.Location = new System.Drawing.Point(470, 420);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(87, 68);
            this.btClose.TabIndex = 58;
            this.btClose.Text = "ปิด";
            this.btClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Image = global::CoffeeCafeProject.Properties.Resources.delete;
            this.btDelete.Location = new System.Drawing.Point(470, 270);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(87, 68);
            this.btDelete.TabIndex = 57;
            this.btDelete.Text = "ลบ";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::CoffeeCafeProject.Properties.Resources.update;
            this.btUpdate.Location = new System.Drawing.Point(470, 196);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(87, 68);
            this.btUpdate.TabIndex = 56;
            this.btUpdate.Text = "แก้ไข";
            this.btUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btUpdate.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Image = global::CoffeeCafeProject.Properties.Resources.save;
            this.btSave.Location = new System.Drawing.Point(470, 122);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(87, 68);
            this.btSave.TabIndex = 55;
            this.btSave.Text = "บันทึก";
            this.btSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Image = global::CoffeeCafeProject.Properties.Resources.reset;
            this.btCancel.Location = new System.Drawing.Point(470, 346);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 68);
            this.btCancel.TabIndex = 59;
            this.btCancel.Text = "ยกเลิก";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 23);
            this.label4.TabIndex = 61;
            this.label4.Text = "รหัสสมาชิก";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMemberId
            // 
            this.tbMemberId.Location = new System.Drawing.Point(29, 139);
            this.tbMemberId.Name = "tbMemberId";
            this.tbMemberId.ReadOnly = true;
            this.tbMemberId.Size = new System.Drawing.Size(68, 20);
            this.tbMemberId.TabIndex = 60;
            // 
            // FrmMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 514);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMemberId);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lvShowAllMember);
            this.Controls.Add(this.tbMemberName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMemberPhone);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Member - SAU Coffee Cafe V.1.0";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvShowAllMember;
        private System.Windows.Forms.TextBox tbMemberName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMemberPhone;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMemberId;
    }
}