namespace AncientSearch
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderlabel = new System.Windows.Forms.Label();
            this.folderbutton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.filebutton = new System.Windows.Forms.Button();
            this.filelabel = new System.Windows.Forms.Label();
            this.searchbutton = new System.Windows.Forms.Button();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.renamebutton = new System.Windows.Forms.Button();
            this.formatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // folderlabel
            // 
            this.folderlabel.BackColor = System.Drawing.Color.White;
            this.folderlabel.Location = new System.Drawing.Point(56, 198);
            this.folderlabel.Name = "folderlabel";
            this.folderlabel.Size = new System.Drawing.Size(150, 25);
            this.folderlabel.TabIndex = 2;
            this.folderlabel.Text = "语料库文件夹路径";
            this.folderlabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // folderbutton
            // 
            this.folderbutton.Location = new System.Drawing.Point(242, 198);
            this.folderbutton.Name = "folderbutton";
            this.folderbutton.Size = new System.Drawing.Size(90, 25);
            this.folderbutton.TabIndex = 3;
            this.folderbutton.Text = "选择语料库";
            this.folderbutton.UseVisualStyleBackColor = true;
            this.folderbutton.Click += new System.EventHandler(this.folderbutton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // filebutton
            // 
            this.filebutton.Location = new System.Drawing.Point(242, 107);
            this.filebutton.Name = "filebutton";
            this.filebutton.Size = new System.Drawing.Size(90, 25);
            this.filebutton.TabIndex = 1;
            this.filebutton.Text = "选择待测文档";
            this.filebutton.UseVisualStyleBackColor = true;
            this.filebutton.Click += new System.EventHandler(this.filebutton_Click);
            // 
            // filelabel
            // 
            this.filelabel.BackColor = System.Drawing.Color.White;
            this.filelabel.Location = new System.Drawing.Point(56, 107);
            this.filelabel.Name = "filelabel";
            this.filelabel.Size = new System.Drawing.Size(150, 25);
            this.filelabel.TabIndex = 0;
            this.filelabel.Text = "选择待测文档位置";
            this.filelabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(242, 291);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(90, 25);
            this.searchbutton.TabIndex = 5;
            this.searchbutton.Text = "检索";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // numTextBox
            // 
            this.numTextBox.Location = new System.Drawing.Point(58, 294);
            this.numTextBox.Name = "numTextBox";
            this.numTextBox.Size = new System.Drawing.Size(150, 21);
            this.numTextBox.TabIndex = 4;
            this.numTextBox.Text = "请输入数字阈值";
            // 
            // renamebutton
            // 
            this.renamebutton.Location = new System.Drawing.Point(242, 247);
            this.renamebutton.Name = "renamebutton";
            this.renamebutton.Size = new System.Drawing.Size(90, 23);
            this.renamebutton.TabIndex = 6;
            this.renamebutton.Text = "修改";
            this.renamebutton.UseVisualStyleBackColor = true;
            this.renamebutton.Click += new System.EventHandler(this.renamebutton_Click);
            // 
            // formatButton
            // 
            this.formatButton.Location = new System.Drawing.Point(118, 247);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(90, 23);
            this.formatButton.TabIndex = 7;
            this.formatButton.Text = "转TXT";
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AncientSearch.Properties.Resources._200904291042599831;
            this.ClientSize = new System.Drawing.Size(384, 462);
            this.Controls.Add(this.formatButton);
            this.Controls.Add(this.renamebutton);
            this.Controls.Add(this.numTextBox);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.filelabel);
            this.Controls.Add(this.filebutton);
            this.Controls.Add(this.folderbutton);
            this.Controls.Add(this.folderlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "古籍检索";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label folderlabel;
        private System.Windows.Forms.Button folderbutton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button filebutton;
        private System.Windows.Forms.Label filelabel;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.TextBox numTextBox;
        private System.Windows.Forms.Button renamebutton;
        private System.Windows.Forms.Button formatButton;
    }
}

