using System;
using KTPO4310.Khairullin.Lib.src.LogAn;
using NUnit.Framework;
namespace KTPO4310.Khairullin.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TearDown]
        public void AfterEachTest()
        {
            ExtensionManagerFactory.SetManager(null);
        }
    

    ///<summary>Поддельный менеджер расширений</summary>


        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;

            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            bool result = log.IsValidLogFileName("short.ext");

            Assert.IsTrue(result);

        }
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            bool result = log.IsValidLogFileName("short.ext");

            Assert.IsFalse(result);
        }
        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = null;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer();

            bool result = log.IsValidLogFileName("test.log");

            // Проверка ожидаемого результата
            Assert.IsFalse(result);
        }
    }
    internal class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid = false;
        public Exception WillThrow = null;
        public bool IsValid(string fileName)
            {
                return WillBeValid;
            }
    }
}
