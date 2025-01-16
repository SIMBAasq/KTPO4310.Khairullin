using System;

namespace KTPO4310.Khairullin.Lib.src.LogAn
{
    /// <summary>
    /// Анализатор лог файлов
    /// </summary>
    public class LogAnalyzer
    {
        

        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager extensionManager = ExtensionManagerFactory.Create();
            // Обращаемся к полю вместо создания нового объекта
            return extensionManager.IsValid(fileName);
        }
    }




}

