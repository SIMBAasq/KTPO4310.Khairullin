using System;

namespace KTPO4310.Khairullin.Lib.src.LogAn
{
    /// <summary>
    /// Менеджер Расширений файлов
    /// </summary>
    public class FileExtensionManager : IExtensionManager
    {
        public Exception WillThrow = null;

        public FileExtensionManager()
        {

        }  
        
        ///<summary> Проверка правильности расширения</summary>
        public bool IsValid(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}