namespace HeThongBanLeVLXD
{
    partial class FrmGiaoDienChinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiaoDienChinh));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInFile = new System.Windows.Forms.Button();
            this.imlXuatFile = new System.Windows.Forms.ImageList(this.components);
            this.btnBieuDoDT = new System.Windows.Forms.Button();
            this.imlBieuDo = new System.Windows.Forms.ImageList(this.components);
            this.btnQlyCongNoKH = new System.Windows.Forms.Button();
            this.imlCongNoKhachHang = new System.Windows.Forms.ImageList(this.components);
            this.btnQlyLichSu = new System.Windows.Forms.Button();
            this.imlLichSuMuaBan = new System.Windows.Forms.ImageList(this.components);
            this.btnQlyKho = new System.Windows.Forms.Button();
            this.imlQuanLiKho = new System.Windows.Forms.ImageList(this.components);
            this.btnQlySanPham = new System.Windows.Forms.Button();
            this.imlDanhMucQuanLiSanPham = new System.Windows.Forms.ImageList(this.components);
            this.btnQlyNguoiDung = new System.Windows.Forms.Button();
            this.imlQuanLiNguoiDung = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người dùng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            // 
            // btnInFile
            // 
            this.btnInFile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInFile.ImageIndex = 0;
            this.btnInFile.ImageList = this.imlXuatFile;
            this.btnInFile.Location = new System.Drawing.Point(16, 695);
            this.btnInFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnInFile.Name = "btnInFile";
            this.btnInFile.Size = new System.Drawing.Size(160, 160);
            this.btnInFile.TabIndex = 12;
            this.btnInFile.Text = "Xuất danh sách hàng tồn kho ra file vật lý";
            this.btnInFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnInFile.UseVisualStyleBackColor = true;
            // 
            // imlXuatFile
            // 
            this.imlXuatFile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlXuatFile.ImageStream")));
            this.imlXuatFile.TransparentColor = System.Drawing.Color.Transparent;
            this.imlXuatFile.Images.SetKeyName(0, "printer.png");
            // 
            // btnBieuDoDT
            // 
            this.btnBieuDoDT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBieuDoDT.ImageIndex = 0;
            this.btnBieuDoDT.ImageList = this.imlBieuDo;
            this.btnBieuDoDT.Location = new System.Drawing.Point(207, 471);
            this.btnBieuDoDT.Margin = new System.Windows.Forms.Padding(4);
            this.btnBieuDoDT.Name = "btnBieuDoDT";
            this.btnBieuDoDT.Size = new System.Drawing.Size(160, 160);
            this.btnBieuDoDT.TabIndex = 11;
            this.btnBieuDoDT.Text = "Hiển thị biểu đồ doanh thu";
            this.btnBieuDoDT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBieuDoDT.UseVisualStyleBackColor = true;
            // 
            // imlBieuDo
            // 
            this.imlBieuDo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlBieuDo.ImageStream")));
            this.imlBieuDo.TransparentColor = System.Drawing.Color.Transparent;
            this.imlBieuDo.Images.SetKeyName(0, "revenue.png");
            // 
            // btnQlyCongNoKH
            // 
            this.btnQlyCongNoKH.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyCongNoKH.ImageIndex = 0;
            this.btnQlyCongNoKH.ImageList = this.imlCongNoKhachHang;
            this.btnQlyCongNoKH.Location = new System.Drawing.Point(16, 471);
            this.btnQlyCongNoKH.Margin = new System.Windows.Forms.Padding(4);
            this.btnQlyCongNoKH.Name = "btnQlyCongNoKH";
            this.btnQlyCongNoKH.Size = new System.Drawing.Size(160, 160);
            this.btnQlyCongNoKH.TabIndex = 10;
            this.btnQlyCongNoKH.Text = "Quản lý công nợ khách hàng \n\n";
            this.btnQlyCongNoKH.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQlyCongNoKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQlyCongNoKH.UseVisualStyleBackColor = true;
            // 
            // imlCongNoKhachHang
            // 
            this.imlCongNoKhachHang.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCongNoKhachHang.ImageStream")));
            this.imlCongNoKhachHang.TransparentColor = System.Drawing.Color.Transparent;
            this.imlCongNoKhachHang.Images.SetKeyName(0, "borrow.png");
            // 
            // btnQlyLichSu
            // 
            this.btnQlyLichSu.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyLichSu.ImageIndex = 0;
            this.btnQlyLichSu.ImageList = this.imlLichSuMuaBan;
            this.btnQlyLichSu.Location = new System.Drawing.Point(207, 250);
            this.btnQlyLichSu.Margin = new System.Windows.Forms.Padding(4);
            this.btnQlyLichSu.Name = "btnQlyLichSu";
            this.btnQlyLichSu.Size = new System.Drawing.Size(160, 160);
            this.btnQlyLichSu.TabIndex = 9;
            this.btnQlyLichSu.Text = "Quản lý lịch sử mua bán\n\n";
            this.btnQlyLichSu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQlyLichSu.UseVisualStyleBackColor = true;
            // 
            // imlLichSuMuaBan
            // 
            this.imlLichSuMuaBan.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlLichSuMuaBan.ImageStream")));
            this.imlLichSuMuaBan.TransparentColor = System.Drawing.Color.Transparent;
            this.imlLichSuMuaBan.Images.SetKeyName(0, "order-history.png");
            // 
            // btnQlyKho
            // 
            this.btnQlyKho.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyKho.ImageIndex = 0;
            this.btnQlyKho.ImageList = this.imlQuanLiKho;
            this.btnQlyKho.Location = new System.Drawing.Point(16, 250);
            this.btnQlyKho.Margin = new System.Windows.Forms.Padding(4);
            this.btnQlyKho.Name = "btnQlyKho";
            this.btnQlyKho.Size = new System.Drawing.Size(160, 160);
            this.btnQlyKho.TabIndex = 8;
            this.btnQlyKho.Text = "Quản lý kho\n\n";
            this.btnQlyKho.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQlyKho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQlyKho.UseVisualStyleBackColor = true;
            // 
            // imlQuanLiKho
            // 
            this.imlQuanLiKho.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlQuanLiKho.ImageStream")));
            this.imlQuanLiKho.TransparentColor = System.Drawing.Color.Transparent;
            this.imlQuanLiKho.Images.SetKeyName(0, "inventory-management.png");
            // 
            // btnQlySanPham
            // 
            this.btnQlySanPham.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlySanPham.ImageIndex = 0;
            this.btnQlySanPham.ImageList = this.imlDanhMucQuanLiSanPham;
            this.btnQlySanPham.Location = new System.Drawing.Point(207, 26);
            this.btnQlySanPham.Margin = new System.Windows.Forms.Padding(4);
            this.btnQlySanPham.Name = "btnQlySanPham";
            this.btnQlySanPham.Size = new System.Drawing.Size(160, 160);
            this.btnQlySanPham.TabIndex = 7;
            this.btnQlySanPham.Text = "Quản lý danh mục sản phẩm";
            this.btnQlySanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQlySanPham.UseVisualStyleBackColor = true;
            // 
            // imlDanhMucQuanLiSanPham
            // 
            this.imlDanhMucQuanLiSanPham.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlDanhMucQuanLiSanPham.ImageStream")));
            this.imlDanhMucQuanLiSanPham.TransparentColor = System.Drawing.Color.Transparent;
            this.imlDanhMucQuanLiSanPham.Images.SetKeyName(0, "product-catalog.png");
            // 
            // btnQlyNguoiDung
            // 
            this.btnQlyNguoiDung.FlatAppearance.BorderColor = System.Drawing.Color.LightCyan;
            this.btnQlyNguoiDung.FlatAppearance.BorderSize = 5;
            this.btnQlyNguoiDung.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnQlyNguoiDung.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.btnQlyNguoiDung.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQlyNguoiDung.ImageIndex = 0;
            this.btnQlyNguoiDung.ImageList = this.imlQuanLiNguoiDung;
            this.btnQlyNguoiDung.Location = new System.Drawing.Point(16, 26);
            this.btnQlyNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.btnQlyNguoiDung.Name = "btnQlyNguoiDung";
            this.btnQlyNguoiDung.Size = new System.Drawing.Size(160, 160);
            this.btnQlyNguoiDung.TabIndex = 6;
            this.btnQlyNguoiDung.Text = "Quản Lý Người Dùng";
            this.btnQlyNguoiDung.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQlyNguoiDung.UseVisualStyleBackColor = true;
            // 
            // imlQuanLiNguoiDung
            // 
            this.imlQuanLiNguoiDung.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlQuanLiNguoiDung.ImageStream")));
            this.imlQuanLiNguoiDung.TransparentColor = System.Drawing.Color.Transparent;
            this.imlQuanLiNguoiDung.Images.SetKeyName(0, "management.png");
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(156, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.txtMaNV);
            this.panel1.Controls.Add(this.txtRole);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1903, 98);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.Location = new System.Drawing.Point(391, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1511, 886);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Azure;
            this.panel3.Controls.Add(this.btnInFile);
            this.panel3.Controls.Add(this.btnQlyNguoiDung);
            this.panel3.Controls.Add(this.btnBieuDoDT);
            this.panel3.Controls.Add(this.btnQlyCongNoKH);
            this.panel3.Controls.Add(this.btnQlySanPham);
            this.panel3.Controls.Add(this.btnQlyKho);
            this.panel3.Controls.Add(this.btnQlyLichSu);
            this.panel3.Location = new System.Drawing.Point(-1, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(386, 886);
            this.panel3.TabIndex = 8;
            // 
            // txtRole
            // 
            this.txtRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.Location = new System.Drawing.Point(291, 10);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(184, 30);
            this.txtRole.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã NV:";
            this.label3.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(291, 51);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(184, 30);
            this.txtMaNV.TabIndex = 6;
            // 
            // FrmGiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1902, 983);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGiaoDienChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGiaoDienChinh";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FrmGiaoDienChinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnInFile;
        private System.Windows.Forms.Button btnBieuDoDT;
        private System.Windows.Forms.Button btnQlyCongNoKH;
        private System.Windows.Forms.Button btnQlyLichSu;
        private System.Windows.Forms.Button btnQlyKho;
        private System.Windows.Forms.Button btnQlySanPham;
        private System.Windows.Forms.Button btnQlyNguoiDung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imlQuanLiNguoiDung;
        private System.Windows.Forms.ImageList imlDanhMucQuanLiSanPham;
        private System.Windows.Forms.ImageList imlQuanLiKho;
        private System.Windows.Forms.ImageList imlLichSuMuaBan;
        private System.Windows.Forms.ImageList imlCongNoKhachHang;
        private System.Windows.Forms.ImageList imlBieuDo;
        private System.Windows.Forms.ImageList imlXuatFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label3;
    }
}