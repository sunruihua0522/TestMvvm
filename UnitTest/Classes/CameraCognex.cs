using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Interface;
namespace UnitTest.Classes
{
    class CameraCognex : ICamera
    {
        public string Name { get { return "Cognex"; } }
    }
}
