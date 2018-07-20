using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiabaryForTest;
namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        private FileHelper fh=new FileHelper();

        [Test(Description ="测试创建FileLog")]
        public void TestCreatLogFile()
        {
            bool bRet=fh.CreatLogFile("C:\\Log","22.txt");
            Assert.True(bRet);
        }

        [Test(Description = "测试Log")]
        public void TestLog()
        {
            fh.CreatLogFile("C:\\Log", "22.txt");
            fh.Log("ABCDEFG");
            Assert.True(fh.Read() == "ABCDEFG");
        }


    }
}
