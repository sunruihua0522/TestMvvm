using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiabaryForTest
{
    public class FileHelper
    {
        private string strPath = "";
        public bool CreatLogFile(string FilePath, string strFileName)
        {
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            strPath = FilePath + "\\" + strFileName;
            if (!File.Exists(strPath))
            {
                File.Create(strPath);
            }

            return File.Exists(strPath);
        }
        public void Log(string strText)
        {
            File.WriteAllText(strPath, strText);
        }
        public string Read()
        {
            return File.ReadAllText(strPath);
        }
    }
}
