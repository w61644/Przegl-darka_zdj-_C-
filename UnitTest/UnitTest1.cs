using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PictureViewermasterpro;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            var file1Name = "img1.jpg";
            var file2Name = "img2.jpg";

            // act
            var plik1 = Stat.SprawdzPlik(file1Name);
            var plik2 = Stat.SprawdzPlik(file2Name);

            // assert
            Assert.IsTrue(plik1);
            Assert.IsFalse(plik2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            var file1Name = "img1.jpg";
            var file2Name = "UnitTest1.sh";

            // act
            var plik1 = Stat.SprawzCzyObraz(file1Name);
            var plik2 = Stat.SprawzCzyObraz(file2Name);

            // assert
            Assert.IsTrue(plik1);
            Assert.IsFalse(plik2);
        }
    }
}
