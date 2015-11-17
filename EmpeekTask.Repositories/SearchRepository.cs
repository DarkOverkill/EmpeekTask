using EmpeekTask.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpeekTask.Repositories
{
    public class SearchRepository
    {
        private Array drivers;
        private List<FolderData> folders = new List<FolderData>();
        public SearchRepository()
        {
            drivers = DriveInfo.GetDrives();
        }
        public Array GetDrivers()
        {
            return drivers;
        }
        public List<FolderData> SearchFolders(string path, int level)
        {
            try
            {
                if (level == 0)
                {
                    FolderData tmpFolder = new FolderData();
                    tmpFolder.Name = path;
                    tmpFolder.FullPath = path;
                    tmpFolder.Level = level;
                    tmpFolder.Files = SearchFiles(path, level);
                    folders.Add(tmpFolder);
                }
                Array _folders = new DirectoryInfo(path).GetDirectories();
                foreach (DirectoryInfo f in _folders)
                {
                    FolderData tmpFolder = new FolderData();
                    tmpFolder.Name = f.Name;
                    tmpFolder.FullPath = f.FullName;
                    tmpFolder.Level = level+1;
                    tmpFolder.Files = SearchFiles(f.FullName, level + 1);
                    folders.Add(tmpFolder);
                    SearchFolders(f.FullName, level + 1);                 
                }
                return folders;
            }
            catch { }
            return null;
        }
        public List<FileData> SearchFiles(string path, int level)
        {
            try
            {
                List<FileData> filesList = new List<FileData>();
                Array files = new DirectoryInfo(path).GetFiles();
                foreach (FileInfo file in files)
                {
                    FileData tmpFile = new FileData();
                    tmpFile.Name = file.Name;
                    tmpFile.Size = file.Length;
                    tmpFile.Level = level;

                    filesList.Add(tmpFile);
                }
                return filesList;
            }
            catch { }
            return new List<FileData>();
        }
        public int[] FilesCount()
        {
            int[] filesCount = new int[3] { 0,0,0 };
            foreach (var folder in folders)
            {
                foreach (var file in folder.Files)
                {
                    if ((file.Size / 1024 / 1024) < 10)
                    {
                        filesCount[0]++;
                    }
                    else if ((file.Size / 1024 / 1024) > 100)
                    {
                        filesCount[2]++;
                    }
                    else
                    {
                        filesCount[1]++;
                    }
                }
            }
            return filesCount;
        }
    }
}
