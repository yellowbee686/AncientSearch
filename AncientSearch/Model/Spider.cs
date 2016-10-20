using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AncientSearch.Model
{
    class Spider
    {
        public Spider(string seedPath, string dirPath, int num)
        {
            this.seedFilePath = seedPath;
            this.dataDirPath = dirPath;
            limitNum = num;
            this.dataFileList = new List<string>();
            this.keys = new HashSet<string>();
            this.getDataFileList();
            this.getKeys();
        }
        public Spider(string dirPath)
        {
            this.dataDirPath = dirPath;
            this.dataFileList = new List<string>();
        }
        private int limitNum;

        public int LimitNum
        {
            get { return limitNum; }
            set { limitNum = value; }
        }
        
        //存储检测结果的文件名
        public const string SRFN = "_检测结果.txt";
        //待测文档path
        private string seedFilePath;

        public string SeedFilePath
        {
            get { return seedFilePath; }
            set { seedFilePath = value; }
        }
        //语料库文件夹path
        private string dataDirPath;

        public string DataDirPath
        {
            get { return dataDirPath; }
            set { dataDirPath = value; }
        }
        //语料库filepath list
        private List<string> dataFileList;

        public List<string> DataFileList
        {
            get { return dataFileList; }
            set { dataFileList = value; }
        }

        private HashSet<string> keys;

        public HashSet<string> Keys
        {
            get { return keys; }
            set { keys = value; }
        }

        protected void getKeys()
        {
            FileInfo seedFile = new FileInfo(seedFilePath);
            if (seedFile.Exists)
            {
                string keyString = File.ReadAllText(seedFilePath, Encoding.Default);
                string[] rawKeys = keyString.Split('/');
                HashSet<string> rawSet = new HashSet<string>(rawKeys);
                //中文标点集
                const string chinese= "，。？！；：“”";
                foreach (string item in rawSet)
                {
                    string tmpStr = "";
                    foreach (char c in item)
                    {
                        if ((int)c > 127 && !chinese.Contains(c))
                        {
                            tmpStr += c;
                        }
                    }
                    if (tmpStr.Length > 0)
                        keys.Add(tmpStr);
                }
            }
            else
            {
                throw new FileNotFoundException("指定的待测文档未找到：" + seedFilePath);
            }
        }

        /// <summary>
        /// 将语料库文件夹及其子文件夹中的filepath存入List中
        /// </summary>
        protected void getDataFileList()
        {
            Queue<DirectoryInfo> que = new Queue<DirectoryInfo>();
            DirectoryInfo dataDir = new DirectoryInfo(dataDirPath);
            que.Enqueue(dataDir);
            DirectoryInfo tmpDir;
            while (que.Count != 0)
            {
                tmpDir = que.Dequeue();
                if (tmpDir.Exists)
                {
                    foreach (DirectoryInfo nextFolder in tmpDir.GetDirectories())
                        que.Enqueue(nextFolder);

                    foreach (FileInfo nextFile in tmpDir.GetFiles())
                        dataFileList.Add(nextFile.FullName);
                }
                else
                {
                    throw new DirectoryNotFoundException("指定的语料库未找到：" + tmpDir.FullName);
                }
            }
        }

        public void Search()
        {
            FileInfo seedFile = new FileInfo(seedFilePath);
            //统计每个词出现次数
            int count;
            string[] ss = seedFile.Name.Split('.');
            string resultFileName = ss[0] + SRFN;
            //每个searchkey的搜索结果
            string writeBuffer;
            FileInfo resultFile = new FileInfo(resultFileName);
            if (resultFile.Exists)
                resultFile.Delete();
            StreamWriter sw = new StreamWriter(resultFileName, true, Encoding.Default);
            bool limitFlag;         
            //seedFile中每个词占一行 因此可以直接分开
            //string[] keyString = File.ReadAllLines(seedFilePath, Encoding.Default);
            //用HashSet去除重复的词
            //HashSet<string> keys = new HashSet<string>(keyString);
            foreach (string nextKey in keys)
            {
                count = 0;
                writeBuffer = nextKey + "\r\n";
                limitFlag = true;
                foreach (string nextPath in dataFileList)
                {
                    string[] fileLines = File.ReadAllLines(nextPath, Encoding.Default);
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                        if (fileLines[i].Contains(nextKey))
                        {
                            count++;
                            string pathParser = nextPath.Replace(dataDirPath+"\\","");
                            writeBuffer += count.ToString() + " " + pathParser
                                + "第" + i.ToString() + "行 " + fileLines[i] + "\r\n";
                        }
                    }                     
                    if (count > limitNum)
                    {
                        writeBuffer = "";
                        limitFlag = false;
                        break;
                    }
                }
                if (limitFlag)
                {
                    writeBuffer += "总共出现" + count.ToString() + "次\r\n";
                    sw.WriteLine(writeBuffer);
                }
            }           
            sw.Close();
        }

        public void RenameFileName()
        {
            Queue<DirectoryInfo> que = new Queue<DirectoryInfo>();
            DirectoryInfo dataDir = new DirectoryInfo(dataDirPath);
            que.Enqueue(dataDir);
            DirectoryInfo tmpDir;
            string txtDirName = dataDirPath.Remove(dataDirPath.LastIndexOf("\\")) + @"\TXT\";
            if (!Directory.Exists(txtDirName))
            {
                Directory.CreateDirectory(txtDirName);
            }
            while (que.Count != 0)
            {
                tmpDir = que.Dequeue();
                if (tmpDir.Exists)
                {
                    foreach (DirectoryInfo nextFolder in tmpDir.GetDirectories())
                        que.Enqueue(nextFolder);

                    foreach (FileInfo nextFile in tmpDir.GetFiles())
                    {
                        string name = nextFile.Name;
                        if (name.Contains(@"xml"))
                        {
                            name = name.Replace(@"xml",@"txt");
                            nextFile.CopyTo(txtDirName + name);
                        }
                    }
                       
                }
                else
                {
                    throw new DirectoryNotFoundException("指定的文件夹未找到：" + tmpDir.FullName);
                }
            }
        }

        // 特殊需求，删除html中无用的部分
        string trimFileHeader(string content)
        {
            int index = content.IndexOf("<BR>\r\n<BR>\r\n<BR>\r\n<BR>\r\n\r\n");
            return content.Substring(index + 28);   //28是上面的部分加三个换行符的值
        }

        string trimHtmlMark(string content)
        {
            return content.Replace("<BR>", "").Replace("</font>", "").Replace("</body>", "").Replace("</html>", "");
        }

        void transferOneFile(string path)
        {
            string content = File.ReadAllText(path, Encoding.UTF8);
            content = trimFileHeader(content);
            content = trimHtmlMark(content);
            string fileName = path.Substring(path.LastIndexOf('\\')).Replace(".htm", ".txt");
            writeToFile(resultDirPath+fileName, content);
        }

        void writeToFile(string resultFileName, string content)
        {
            FileInfo resultFile = new FileInfo(resultFileName);
            if (resultFile.Exists)
                resultFile.Delete();
            StreamWriter sw = new StreamWriter(resultFileName, false, Encoding.UTF8);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }
        private string resultDirPath;
        public void TransferFormat()
        {
            getDataFileList();
            resultDirPath = dataDirPath + "\\result";
            DirectoryInfo dirInfo = new DirectoryInfo(resultDirPath);
            if (!dirInfo.Exists)
                dirInfo.Create();
            foreach (string nextPath in dataFileList)
            {
                transferOneFile(nextPath);
            }
        }
    }
}
