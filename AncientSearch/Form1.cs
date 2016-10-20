using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AncientSearch.Model;
namespace AncientSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void folderbutton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.Description = "请选择语料库文件夹";
            folderBrowserDialog1.ShowNewFolderButton = true;
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Personal;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                if (folderName != "")
                {
                    folderlabel.Text = folderName;
                }
            }
        }

        private void filebutton_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类 
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名 
                string extension = Path.GetExtension(fileDialog.FileName);
                //声明允许的后缀名 
                string[] strs = new string[] { ".txt",".TXT" };
                if (!strs.Contains(extension))
                {
                    MessageBox.Show("仅能验证txt格式的纯文本文档！");
                }
                else
                {
                    this.filelabel.Text = fileDialog.FileName;
                }
            }
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Int32.Parse(numTextBox.Text);
                if (filelabel.Text != "" && filelabel.Text != "待测文档位置" &&
                folderlabel.Text != "" && folderlabel.Text != "语料库文件夹路径")
                {
                    Spider searchSpider = new Spider(filelabel.Text, folderlabel.Text, num);
                    Action longAction = new Action(searchSpider.Search);
                    IAsyncResult re = longAction.BeginInvoke(null, null);
                    while (!re.IsCompleted)
                    {
                        folderbutton.Enabled = false;
                        filebutton.Enabled = false;
                        numTextBox.Enabled = false;
                        searchbutton.Enabled = false;
                    }
                    //dsearchSpider.Search();
                    longAction.EndInvoke(re);
                    folderbutton.Enabled = true;
                    filebutton.Enabled = true;
                    numTextBox.Enabled = true;
                    searchbutton.Enabled = true;
                    MessageBox.Show("啦啦啦，终于做完了...");
                }
                else
                {
                    MessageBox.Show("请补充完整待测文档及语料库位置");
                }
            }
            catch
            {
                MessageBox.Show("请输入数字阈值");
            }
            
        }

        private void renamebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderlabel.Text != "" && folderlabel.Text != "语料库文件夹路径")
                {
                    Spider searchSpider = new Spider(folderlabel.Text);
                    Action longAction = new Action(searchSpider.RenameFileName);
                    IAsyncResult re = longAction.BeginInvoke(null, null);
                    while (!re.IsCompleted)
                    {
                        folderbutton.Enabled = false;
                        filebutton.Enabled = false;
                        numTextBox.Enabled = false;
                        searchbutton.Enabled = false;
                        renamebutton.Enabled = false;
                    }
                    //searchSpider.RenameFileName();
                    longAction.EndInvoke(re);
                    folderbutton.Enabled = true;
                    filebutton.Enabled = true;
                    numTextBox.Enabled = true;
                    searchbutton.Enabled = true;
                    renamebutton.Enabled = true;
                    MessageBox.Show("啦啦啦，终于做完了...");
                }
                else
                {
                    MessageBox.Show("请选择要修改的文件夹");
                }
            }
            catch
            {
                MessageBox.Show("请输入数字阈值");
            }
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderlabel.Text != "" && folderlabel.Text != "语料库文件夹路径")
                {
                    Spider searchSpider = new Spider(folderlabel.Text);
                    Action longAction = new Action(searchSpider.TransferFormat);
                    IAsyncResult re = longAction.BeginInvoke(null, null);
                    while (!re.IsCompleted)
                    {
                        folderbutton.Enabled = false;
                        filebutton.Enabled = false;
                        numTextBox.Enabled = false;
                        searchbutton.Enabled = false;
                        renamebutton.Enabled = false;
                    }
                    longAction.EndInvoke(re);
                    folderbutton.Enabled = true;
                    filebutton.Enabled = true;
                    numTextBox.Enabled = true;
                    searchbutton.Enabled = true;
                    renamebutton.Enabled = true;
                    MessageBox.Show("啦啦啦，终于做完了...");
                }
                else
                {
                    MessageBox.Show("请选择要修改的文件夹");
                }
            }
            catch
            {
                MessageBox.Show("不知名错误");
            }
        }
    }
}
