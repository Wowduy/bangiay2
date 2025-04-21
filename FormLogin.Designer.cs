namespace quanlibangiay2
{
    partial class FormLogin
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
            btnLOGIN = new Button();
            btnTHOAT = new Button();
            label1 = new Label();
            label2 = new Label();
            txtTAIKHOAN = new TextBox();
            txtMATKHAU = new TextBox();
            label3 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            linkLabel1 = new LinkLabel();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLOGIN
            // 
            btnLOGIN.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnLOGIN.ForeColor = SystemColors.ActiveCaptionText;
            btnLOGIN.Location = new Point(377, 207);
            btnLOGIN.Name = "btnLOGIN";
            btnLOGIN.Size = new Size(109, 37);
            btnLOGIN.TabIndex = 0;
            btnLOGIN.Text = "Đăng nhập";
            btnLOGIN.UseVisualStyleBackColor = true;
            btnLOGIN.Click += btnLOGIN_Click;
            // 
            // btnTHOAT
            // 
            btnTHOAT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnTHOAT.ForeColor = SystemColors.ActiveCaptionText;
            btnTHOAT.Location = new Point(514, 207);
            btnTHOAT.Name = "btnTHOAT";
            btnTHOAT.Size = new Size(77, 37);
            btnTHOAT.TabIndex = 1;
            btnTHOAT.Text = "Thoát";
            btnTHOAT.UseVisualStyleBackColor = true;
            btnTHOAT.Click += btnTHOAT_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(300, 104);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(303, 153);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtTAIKHOAN
            // 
            txtTAIKHOAN.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            txtTAIKHOAN.ForeColor = SystemColors.ActiveCaptionText;
            txtTAIKHOAN.Location = new Point(377, 101);
            txtTAIKHOAN.Name = "txtTAIKHOAN";
            txtTAIKHOAN.Size = new Size(214, 25);
            txtTAIKHOAN.TabIndex = 4;
            // 
            // txtMATKHAU
            // 
            txtMATKHAU.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            txtMATKHAU.ForeColor = SystemColors.ActiveCaptionText;
            txtMATKHAU.Location = new Point(377, 150);
            txtMATKHAU.Name = "txtMATKHAU";
            txtMATKHAU.Size = new Size(214, 25);
            txtMATKHAU.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.WindowFrame;
            label3.Location = new Point(182, 36);
            label3.Name = "label3";
            label3.Size = new Size(257, 30);
            label3.TabIndex = 6;
            label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(33, 85);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(234, 219);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.vecteezy_creative_abstract_black_silhouette_running_shoe_design_logo_8956590;
            pictureBox1.Location = new Point(3, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(228, 197);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            linkLabel1.ForeColor = SystemColors.ActiveCaptionText;
            linkLabel1.LinkColor = Color.MediumSlateBlue;
            linkLabel1.Location = new Point(377, 272);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(109, 17);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quên mật khẩu?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 372);
            Controls.Add(linkLabel1);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(txtMATKHAU);
            Controls.Add(txtTAIKHOAN);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTHOAT);
            Controls.Add(btnLOGIN);
            Name = "FormLogin";
            Text = "FormLogin";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLOGIN;
        private Button btnTHOAT;
        private Label label1;
        private Label label2;
        private TextBox txtTAIKHOAN;
        private TextBox txtMATKHAU;
        private Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
    }
}