using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchiveTesting
{
    public partial class Form1 : Form
    {
        string fileName = "/archive.bisyarchive";
        public Form1()
        {
            InitializeComponent();
        }

        public static void CreateTempFiles(params string[] Data)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                string[] cData = Data[i].Split('|');
                string FileName = cData[0];
                string wData = cData[1];
                if (!File.Exists("tempData//" + FileName))
                {
                    StreamWriter SWriter = new StreamWriter("tempData//" + FileName);
                    SWriter.Write(wData);
                    SWriter.Flush();
                    SWriter.Close();
                }
            }
        }

        public static void CreateTempDirectory()
        {
            if(!Directory.Exists(Application.StartupPath + "//tempData"))
                Directory.CreateDirectory(Application.StartupPath + "//tempData");
        }

        public static void DeleteTempDirectory()
        {
            if(Directory.Exists(Application.StartupPath + "//tempData"))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "//tempData");
                }
                catch (IOException)
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + "//tempData");
                    FileInfo[] info = DirInfo.GetFiles("*.*");
                    foreach (FileInfo finf in info)
                    {
                        File.Delete(finf.FullName);
                    }
                    Directory.Delete(Application.StartupPath + "//tempData");
                }
            }
        }

        public static void SaveArchiveData()
        {
            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            sfg.Filter = "BiSyArchive (*.bisyarchive)|*.bisyarchive";
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Application.StartupPath + "//tempData"))
                    ZipFile.CreateFromDirectory(Application.StartupPath + "//tempData", sfg.FileName);
            }
        }

        public static void LoadArchiveData()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "BiSyArchive (*.bisyarchive)|*.bisyarchive";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(Application.StartupPath + "//tempData"))
                    ZipFile.ExtractToDirectory(ofd.FileName, Application.StartupPath + "//tempData");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "FILE 1";
            richTextBox2.Text = "FILE 2";
            richTextBox3.Text = "FILE 3";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateTempDirectory();
            CreateTempFiles("file1.data|DataForFile1", "file2.data|DataForFile2");
            SaveArchiveData();
            System.Threading.Thread.Sleep(2);
            DeleteTempDirectory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateTempDirectory();
            LoadArchiveData();
            this.Cursor = Cursors.WaitCursor;
            System.Threading.Thread.Sleep(5000);
            DeleteTempDirectory();
            this.Cursor = Cursors.Arrow;
        }
    }
}
