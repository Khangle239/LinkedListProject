using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedListConsoleApp.Utility;


namespace UnitTestProject
{
    internal class SLLTest
    {
        private SLL<User> list;
        public void TestInitialize()
        {
            list = new SLL<User>();
        }

    }
}
