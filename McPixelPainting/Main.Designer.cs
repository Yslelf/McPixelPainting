namespace McPixelPainting
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.OpenPicture = new System.Windows.Forms.Button();
            this.CommandSend = new System.Windows.Forms.Button();
            this.GenerateCommand = new System.Windows.Forms.Button();
            this.ClearCommand = new System.Windows.Forms.Button();
            this.PreViewImage = new System.Windows.Forms.PictureBox();
            this.XTxt = new System.Windows.Forms.TextBox();
            this.YTxt = new System.Windows.Forms.TextBox();
            this.ZTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CommandsTxt = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.Function = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.MapPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PreViewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenPicture
            // 
            this.OpenPicture.Location = new System.Drawing.Point(284, 6);
            this.OpenPicture.Name = "OpenPicture";
            this.OpenPicture.Size = new System.Drawing.Size(75, 23);
            this.OpenPicture.TabIndex = 35;
            this.OpenPicture.Text = "打开图片";
            this.OpenPicture.UseVisualStyleBackColor = true;
            this.OpenPicture.Click += new System.EventHandler(this.OpenPicture_Click);
            // 
            // CommandSend
            // 
            this.CommandSend.Location = new System.Drawing.Point(410, 6);
            this.CommandSend.Name = "CommandSend";
            this.CommandSend.Size = new System.Drawing.Size(75, 23);
            this.CommandSend.TabIndex = 37;
            this.CommandSend.Text = "自动发送";
            this.CommandSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CommandSend.UseVisualStyleBackColor = true;
            this.CommandSend.Visible = false;
            this.CommandSend.Click += new System.EventHandler(this.CommandSend_Click);
            // 
            // GenerateCommand
            // 
            this.GenerateCommand.Location = new System.Drawing.Point(284, 79);
            this.GenerateCommand.Name = "GenerateCommand";
            this.GenerateCommand.Size = new System.Drawing.Size(125, 23);
            this.GenerateCommand.TabIndex = 38;
            this.GenerateCommand.Text = "生成指令";
            this.GenerateCommand.UseVisualStyleBackColor = true;
            this.GenerateCommand.Click += new System.EventHandler(this.GenerateCommand_Click);
            // 
            // ClearCommand
            // 
            this.ClearCommand.Location = new System.Drawing.Point(415, 79);
            this.ClearCommand.Name = "ClearCommand";
            this.ClearCommand.Size = new System.Drawing.Size(121, 23);
            this.ClearCommand.TabIndex = 39;
            this.ClearCommand.Text = "清屏";
            this.ClearCommand.UseVisualStyleBackColor = true;
            this.ClearCommand.Click += new System.EventHandler(this.ClearCommand_Click);
            // 
            // PreViewImage
            // 
            this.PreViewImage.Location = new System.Drawing.Point(150, 6);
            this.PreViewImage.Name = "PreViewImage";
            this.PreViewImage.Size = new System.Drawing.Size(128, 128);
            this.PreViewImage.TabIndex = 40;
            this.PreViewImage.TabStop = false;
            // 
            // XTxt
            // 
            this.XTxt.Location = new System.Drawing.Point(75, 20);
            this.XTxt.Name = "XTxt";
            this.XTxt.Size = new System.Drawing.Size(60, 21);
            this.XTxt.TabIndex = 41;
            // 
            // YTxt
            // 
            this.YTxt.Location = new System.Drawing.Point(75, 63);
            this.YTxt.Name = "YTxt";
            this.YTxt.Size = new System.Drawing.Size(60, 21);
            this.YTxt.TabIndex = 42;
            // 
            // ZTxt
            // 
            this.ZTxt.Location = new System.Drawing.Point(75, 102);
            this.ZTxt.Name = "ZTxt";
            this.ZTxt.Size = new System.Drawing.Size(60, 21);
            this.ZTxt.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 44;
            this.label1.Text = "起始X坐标：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 45;
            this.label2.Text = "起始Y坐标：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "起始Z坐标：";
            // 
            // CommandsTxt
            // 
            this.CommandsTxt.Location = new System.Drawing.Point(3, 168);
            this.CommandsTxt.Multiline = true;
            this.CommandsTxt.Name = "CommandsTxt";
            this.CommandsTxt.ReadOnly = true;
            this.CommandsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandsTxt.Size = new System.Drawing.Size(535, 233);
            this.CommandsTxt.TabIndex = 47;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(408, 45);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(431, 12);
            this.linkLabel1.TabIndex = 49;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "点击链接加入群聊【SL | 后花园】：https://jq.qq.com/?_wv=1027&k=5tcIZwO";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "bug反馈Q群：695734979";
            // 
            // Function
            // 
            this.Function.Location = new System.Drawing.Point(284, 108);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(257, 29);
            this.Function.TabIndex = 51;
            this.Function.Text = "压缩指令";
            this.Function.UseVisualStyleBackColor = true;
            this.Function.Click += new System.EventHandler(this.Function_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "客户端地图URL：";
            // 
            // MapPath
            // 
            this.MapPath.Location = new System.Drawing.Point(92, 141);
            this.MapPath.Name = "MapPath";
            this.MapPath.ReadOnly = true;
            this.MapPath.Size = new System.Drawing.Size(358, 21);
            this.MapPath.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(278, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 55;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 402);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MapPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Function);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.CommandsTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ZTxt);
            this.Controls.Add(this.YTxt);
            this.Controls.Add(this.XTxt);
            this.Controls.Add(this.PreViewImage);
            this.Controls.Add(this.ClearCommand);
            this.Controls.Add(this.GenerateCommand);
            this.Controls.Add(this.CommandSend);
            this.Controls.Add(this.OpenPicture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "McPixelPainting v2.3 95种方块";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PreViewImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OpenPicture;
        private System.Windows.Forms.Button CommandSend;
        private System.Windows.Forms.Button GenerateCommand;
        private System.Windows.Forms.Button ClearCommand;
        private System.Windows.Forms.PictureBox PreViewImage;
        private System.Windows.Forms.TextBox XTxt;
        private System.Windows.Forms.TextBox YTxt;
        private System.Windows.Forms.TextBox ZTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CommandsTxt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Function;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MapPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}

