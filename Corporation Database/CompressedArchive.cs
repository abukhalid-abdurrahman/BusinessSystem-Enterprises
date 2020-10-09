using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Corporation_Database
{
    class CompressedArchive
    {
        public static void CreateTempFiles(params string[] Data)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                string[] cData = Data[i].Split('|');
                string FileName = cData[0];
                string wData = cData[1];
                if (!File.Exists(Application.StartupPath + "//tempData//" + FileName))
                {
                    StreamWriter SWriter = new StreamWriter(Application.StartupPath + "//tempData//" + FileName);
                    SWriter.Write(wData);
                    SWriter.Flush();
                    SWriter.Close();
                }
            }
        }

        public static void CreateTempSubDirectories(params string[] DirNames)
        {
            if(DirNames.Length > 0)
            {
                if(Directory.Exists(Application.StartupPath + "//tempData"))
                {
                    foreach (string item in DirNames)
                    {
                        Directory.CreateDirectory(Application.StartupPath + "//tempData//" + item);
                    }
                }
            }
        }

        public static void CreateTempDirectory()
        {
            if (!Directory.Exists(Application.StartupPath + "//tempData"))
                Directory.CreateDirectory(Application.StartupPath + "//tempData");
        }

        public static void DeleteTempDirectory()
        {
            if (Directory.Exists(Application.StartupPath + "//tempData"))
            {
                try
                {
                    Directory.Delete(Application.StartupPath + "//tempData");
                }
                catch (IOException)
                {
                    DirectoryInfo DirInfo = new DirectoryInfo(Application.StartupPath + "//tempData");
                    FileInfo[] info = DirInfo.GetFiles("*.*");
                    if(info != null)
                    {
                        foreach (FileInfo finf in info)
                        {
                            if (File.Exists(finf.FullName))
                                File.Delete(finf.FullName);
                        }
                    }

                    DirectoryInfo[] dNames = DirInfo.GetDirectories();
                    if (dNames != null)
                    {
                        DirectoryInfo SubDirInfo = null;
                        FileInfo[] SubFileInfo = null;

                        foreach (DirectoryInfo item in dNames)
                        {
                            SubDirInfo = new DirectoryInfo(Application.StartupPath + "//tempData//" + item);
                            SubFileInfo = SubDirInfo.GetFiles("*.*");
                            if (SubFileInfo != null)
                            {
                                foreach (FileInfo fitem in SubFileInfo)
                                {
                                    if (File.Exists(fitem.FullName))
                                        File.Delete(fitem.FullName);
                                }
                            }
                            Directory.Delete(item.FullName);
                        }
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
    }
}
