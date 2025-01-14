using System;
using KTPO4310.Khairullin.Lib.src.LogAn;
using NUnit.Framework;
namespace KTPO4310.Khairullin.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]

        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.IsTrue(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            // Подготовка ткста
            LogAnalyzer analyzer = new LogAnalyzer();

            // Воздействие на тестерируемый объект
            bool result = analyzer.IsValidLogFileName("filewithbadextension.LOG");

            Assert.IsFalse(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            // Подготовка ткста
            LogAnalyzer analyzer = new LogAnalyzer();

            // Воздействие на тестерируемый объект
            bool result = analyzer.IsValidLogFileName("filewithbadextension.log");

            Assert.IsFalse(result);
        }
        [TestCase("filewithgoodextension.LOG")]
        [TestCase("filewithgoodextension.log")]
        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string file)
        { 
            LogAnalyzer analyzer = new LogAnalyzer();
            
            bool result = analyzer.IsValidLogFileName("file");

            Assert.True(result);
        }
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));

            StringAssert.Contains("имя файла должно быть задано", ex.Message);

        }
        [TestCase("badfile.log", false)]
        [TestCase("goodfile.foo", true)]

        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
    }
}
